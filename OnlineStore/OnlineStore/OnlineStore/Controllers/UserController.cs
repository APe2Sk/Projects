using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Exceptions;
using OnlineStore.ViewModels.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/register")]
        public ActionResult Register(UserViewModel model)
        {
            var user = userService.CreateUser(model);
            return Created("api/v1/user/login", user);
        }


        [HttpPost("/updateUser/{userId:int}")]
        public ActionResult UpdateUser(UserViewModel model, int userId)
        {
            var user = userService.UpdateUser(model, userId);
            return Created("api/v1/user/login", user);
        }

        [HttpGet("/getAllUsers")]
        public ActionResult GetAllUsers()
        {
            try
            {
                var users = userService.GetAll();
                return Ok(users);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("/getUser/{id:int}")]
        public ActionResult GetUserById(int id)
        {
            try
            {
                var user = userService.GetById(id);
                return Ok(user);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/deleteUser/{id:int}")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                userService.DeleteUser(id);
                return Ok();
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
