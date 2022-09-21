using LotoApplication.Application.Dto;
using LotoApplication.Application.Security;
using LotoApplication.Application.Services.Implementation;
using LotoApplication.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LotoApplication.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly Serilog.ILogger logger;

        public UserController(IUserService userService, Serilog.ILogger logger)
        {
            this.userService = userService;
            this.logger = logger;
            logger.Debug("");
            logger.Information("");
            logger.Warning("");
            logger.Error("");
        }

        [HttpPost]
        public ActionResult Register(CreateUserDto model)
        {
            var user = userService.CreateUser(model);
            return Created("api/v1/user/login", user);
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            try
            {
                var users = userService.GetAllUsers();
                return Ok(users);
            }
            catch(NotFoundException ex)
            {
                logger.Warning("There aren't any users in the data base.", ex);
                return NotFound("There aren't any users in the data base");
            }
            
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpGet("{userId:int}")]
        public ActionResult GetUserById (int userId)
        {
            try
            {
                var user = userService.GetUser(userId);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"User do not exist by id {userId}.", ex);
                return NotFound("User do not exist by that Id");
            }
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpDelete("{userId:int}")]
        public ActionResult DeleteUserById(int userId)
        {
            try
            {
                var deletedUser = userService.DeleteUser(userId);
                return Ok(deletedUser);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"User do not exist by id {userId}.", ex);
                return NotFound("User do not exist by that Id");
            }
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpPost("{userId:int}/updateUser")]
        public ActionResult Update([FromBody] CreateUserDto user, int userId)
        {
            try
            {
                userService.UpdateUser(user, userId);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"User do not exist by id {userId}.", ex);
                return NotFound("User do not exist by that Id");
            }
        }

        [Authorize(Policy = SystemPolicies.RoleUser)]
        [HttpGet("/getCurrentUser")]
        public ActionResult GetCurrentUserById()
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                logger.Warning($"User do not exist by id {userId}.");
                throw new Exception($"User do not exist by id {userId}.");
            }

            try
            {
                var user = userService.GetUser(userId);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"User do not exist by id {userId}.", ex);
                return NotFound("User do not exist by that Id");
            }
        }

        [Authorize(Policy = SystemPolicies.RoleUser)]
        [HttpDelete("/deleteCurrentUser")]
        public ActionResult DeleteCurrentUserById()
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                logger.Warning($"User do not exist by id {userId}.");
                throw new Exception($"User do not exist by id {userId}.");
            }

            try
            {
                var deletedUser = userService.DeleteUser(userId);
                return Ok(deletedUser);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"User do not exist by id {userId}.", ex);
                return NotFound("User do not exist by that Id");
            }
        }


        [Authorize(Policy = SystemPolicies.RoleUser)]
        [HttpPost("/updateCurrentUser")]
        public ActionResult UpdateCurrentUser ([FromBody] CreateUserDto user)
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                logger.Warning($"User do not exist by id {userId}.");
                throw new Exception($"User do not exist by id {userId}.");
            }

            try
            {
                userService.UpdateUser(user, userId);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"User do not exist by id {userId}.", ex);
                return NotFound("User do not exist by that Id");
            }
        }
    }
}
