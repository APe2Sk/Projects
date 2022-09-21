using LotoApplication.Application.Dto;
using LotoApplication.Application.Security;
using LotoApplication.Application.Services;
using LotoApplication.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LotoApplication.Api.Controllers
{
    [Authorize(Policy = SystemPolicies.RoleAdmin)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly Serilog.ILogger logger;

        public AdminController(IAdminService adminService, Serilog.ILogger logger)
        {
            this.adminService = adminService;
            this.logger = logger;
            logger.Debug("");
            logger.Information("");
            logger.Warning("");
            logger.Error("");
        }

        [HttpPost]
        public ActionResult Register(CreateAdminDto model)
        {
            var admin = adminService.CreateAdmin(model);
            return Created("api/v1/admin/login", admin);
        }

        [HttpGet]
        public ActionResult GetAllAdmins()
        {
            try
            {
                var admins = adminService.GetAllAdmins();
                return Ok(admins);
            }
            catch (NotFoundException ex)
            {
                logger.Warning("There aren't any admins in the data base", ex);
                return NotFound("There aren't any admins in the data base");
            }

        }

        [HttpGet("{adminId:int}")]
        public ActionResult GetAdminById(int adminId)
        {
            try
            {
                var admin = adminService.GetAdmin(adminId);
                return Ok(admin);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"Admin do not exist by id {adminId}", ex);
                return NotFound("Admin do not exist by that Id");
            }
        }

        [HttpDelete("{adminId:int}")]
        public ActionResult DeleteAdminById(int adminId)
        {
            try
            {
                var deletedAdmin = adminService.DeleteAdmin(adminId);
                return Ok(deletedAdmin);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"Admin do not exist by id {adminId}", ex);
                return NotFound("Admin do not exist by that Id");
            }
        }

        [HttpPost("{adminId:int}/updateAdmin")]
        public ActionResult Update([FromBody] CreateAdminDto admin, int adminId)
        {
            try
            {
                adminService.UpdateAdmin(admin, adminId);
                return Ok(admin);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"Admin do not exist by id {adminId}", ex);
                return NotFound("Admin do not exist by that Id");
            }
        }
    }
}
