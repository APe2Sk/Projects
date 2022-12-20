using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Exceptions;
using OnlineStore.ViewModels.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        public readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost("/createNewRole")]
        public ActionResult CreateNewRole(RoleViewModel newRole)
        {
            try
            {
                var role = roleService.CreateRole(newRole);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("/update-role/{id}")]
        public ActionResult UpdateNewRole(RoleViewModel updatedRole, int id)
        {
            try
            {
                var role = roleService.UpdateRole(updatedRole, id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/deleteRole/{id}")]
        public ActionResult DeleteRole(int id)
        {
            try
            {
                roleService.DeleteRole(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("/getAllRoles")]
        public ActionResult GetAllRoles()
        {
            try
            {
                var allRoles = roleService.GetAllRole();
                return Ok(allRoles);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/getRoleByName/{name}")]
        public ActionResult GetRoleByName(string name)
        {
            try
            {
                var role = roleService.GetRoleByName(name);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/getRoleById/{id}")]
        public ActionResult GetRoleById(int id)
        {
            try
            {
                var role = roleService.GetRoleById(id);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}