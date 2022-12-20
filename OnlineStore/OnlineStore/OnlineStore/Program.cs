using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Application.AutoMapperConfig;
using OnlineStore.Application.Implementations;
using OnlineStore.Application.Interfaces;
using OnlineStore.DataAccess;
using OnlineStore.DataAccess.EntityFramework;
using OnlineStore.DataAccess.Implementations;
using OnlineStore.DataAccess.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Add Repositories to the container
builder.Services.AddInfrastracture(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
builder.Services.AddSingleton(sp => ModelMapper.GetConfiguration());
builder.Services.AddScoped(sp =>
{
    MapperConfiguration config = sp.GetRequiredService<MapperConfiguration>();
    return config.CreateMapper();
});

// Entityframework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"), b => b.MigrationsAssembly("OnlineStore.DataAccess")));

// repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCathegoryRepository, ProductCathegoryRepository>();
builder.Services.AddScoped<IProductStatusRepository, ProductStatusRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductInfoService, ProductInfoService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
