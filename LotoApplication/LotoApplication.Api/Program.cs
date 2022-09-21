using AutoMapper;
using LotoApplication.Api.Middlewares;
using LotoApplication.Application;
using LotoApplication.Application.Mapper;
using LotoApplication.Application.Repositories;
using LotoApplication.Application.Security;
using LotoApplication.Application.Services;
using LotoApplication.Application.Services.Implementation;
using LotoApplication.Domain.Models;
using LotoApplication.Infrastructure;
using LotoApplication.Infrastructure.EntityFramework;
using LotoApplication.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.Events.OnRedirectToLogin = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };

        opts.Events.OnRedirectToAccessDenied = (context) =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy(SystemPolicies.MustHaveId, builder => builder.RequireClaim(ClaimTypes.NameIdentifier));
    opts.AddPolicy(SystemPolicies.RoleAdmin, builder => builder.RequireRole(LotoAppRoles.Admin));
    opts.AddPolicy(SystemPolicies.RoleUser, builder => builder.RequireRole(LotoAppRoles.User));

});

builder.Services.AddSingleton(sp => ModelMapper.GetConfiguration());
builder.Services.AddScoped(sp =>
{
    MapperConfiguration config = sp.GetRequiredService<MapperConfiguration>();
    return config.CreateMapper();
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("LotoApplication.Infrastructure")));

// repositories
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<Admin>, AdminRepository>();
builder.Services.AddScoped<IRepository<Ticket>, TicketRepository>();
builder.Services.AddScoped<IRepository<Session>, SessionRepository>();
builder.Services.AddScoped<IRepository<Winner>, WinnerRepository>();
builder.Services.AddScoped<IRepository<Draw>, DrawRepository>();


// services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IDrawService, DrawService>();
builder.Services.AddScoped<IWinnerService, WinnerService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

Log.Logger = new LoggerConfiguration()
                    .ReadFrom
                    .Configuration(builder.Configuration)
                    .CreateLogger();
builder.Services.AddSingleton<Serilog.ILogger>(Log.Logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseLoggingMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
