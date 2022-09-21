using LotoApplication.Application;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Services;
using LotoApplication.Application.Services.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LotoApplication.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly IUserService userService;


        public LogInController(IAdminService adminService, IUserService userService)
        {
            this.adminService = adminService;
            this.userService = userService;
        }

        [HttpPost("adminLogin")]
        public async Task<ActionResult> AdminLogin(AdminLoginDto model)
        {
            var user = adminService.PaswordLogin(model);
            var identities = new List<ClaimsIdentity>
            {
                new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, LotoAppRoles.Admin)
                },
                CookieAuthenticationDefaults.AuthenticationScheme)
            };
            var principal = new ClaimsPrincipal(identities);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok();
        }

        [HttpPost("userLogin")]
        public async Task<ActionResult> UserLogin(UserLoginDto model)
        {
            var user = userService.PaswordLogin(model);
            var identities = new List<ClaimsIdentity>
            {
                new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, LotoAppRoles.User)
                },
                CookieAuthenticationDefaults.AuthenticationScheme)
            };
            var principal = new ClaimsPrincipal(identities);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Ok();
        }
    }
}
