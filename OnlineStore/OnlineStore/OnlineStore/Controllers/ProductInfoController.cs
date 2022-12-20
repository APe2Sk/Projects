using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Exceptions;
using OnlineStore.ViewModels.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInfoController : Controller
    {
        private readonly IProductInfoService productinfoService;

        public ProductInfoController(IProductInfoService productinfoService)
        {
            this.productinfoService = productinfoService;
        }

        // Cathegories

        [HttpPost("/addCathegory")]
        public ActionResult AddCathegory(ProductCathegoryViewModel newCathegory)
        {
            try
            {
                productinfoService.CreateCathegory(newCathegory);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/updateCathegoryById/{id}")]
        public ActionResult UpdateCathegoryById(ProductCathegoryViewModel updatedCathegory, int id)
        {
            try
            {
                var cathegory = productinfoService.UpdateCathegoryById(updatedCathegory, id);
                return Ok(cathegory);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("/updateCathegoryByName/{cathegoryName}")]
        public ActionResult UpdateCathegoryByName(ProductCathegoryViewModel updatedCathegory, string cathegoryName)
        {
            try
            {
                var cathegory = productinfoService.UpdateCathegoryByName(updatedCathegory, cathegoryName);
                return Ok(cathegory);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/deleteCathegoryById/{id}")]
        public ActionResult DeleteCathegoryById(int id)
        {
            try
            {
                productinfoService.DeleteCathegoryById(id);
                return Ok("The cathegory has been deleted.");
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/deleteCathegoryByName/{cathegoryName}")]
        public ActionResult DeleteCathegoryByName (string cathegoryName)
        {
            try
            {
                productinfoService.DeleteCathegoryByName(cathegoryName);
                return Ok("The cathegory has been deleted.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/getAllCathegories")]
        public ActionResult GetAllCathegories()
        {
            try
            {
                var cathegories = productinfoService.GetAllCathegories(); 
                return Ok(cathegories);
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("/getCathegoryById/{id:int}")]
        public ActionResult GetCathegoryById(int id)
        {
            try
            {
                var cathegory = productinfoService.GetCathegoryById(id);
                return Ok(cathegory);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("/getCathegoryByName/{name}")]
        public ActionResult GetCathegoryByName(string name)
        {
            try
            {
                var cathegory = productinfoService.GetCathegoryByName(name);
                return Ok(cathegory);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }





        // Statuses

        [HttpPost("/addStatus")]
        public ActionResult AddStatus(ProductStatusViewModel newStatus)
        {
            try
            {
                productinfoService.CreateStatus(newStatus);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/updateStatusById/{id}")]
        public ActionResult UpdateStatusById(ProductStatusViewModel updatedStatus, int id)
        {
            try
            {
                var status = productinfoService.UpdateStatusById(updatedStatus, id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("/updateStatusByName/{statusName}")]
        public ActionResult UpdateStatusByName(ProductStatusViewModel updatedStatus, string statusName)
        {
            try
            {
                var status = productinfoService.UpdateStatusByName(updatedStatus, statusName);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/deleteStatusById/{id}")]
        public ActionResult DeleteStatusById(int id)
        {
            try
            {
                productinfoService.DeleteStatusById(id);
                return Ok("The status has been deleted.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("/deleteStatusByName/{statusName}")]
        public ActionResult DeleteStatusByName(string statusName)
        {
            try
            {
                productinfoService.DeleteStatusByName(statusName);
                return Ok("The status has been deleted.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("/getAllStatuses")]
        public ActionResult GetAllStatuses()
        {
            try
            {
                var statuses = productinfoService.GetAllStatuses();
                return Ok(statuses);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("/getCStatusyById/{id:int}")]
        public ActionResult GetCStatusyById(int id)
        {
            try
            {
                var status = productinfoService.GetCStatusyById(id);
                return Ok(status);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("/getStatusByName/{statusName}")]
        public ActionResult GetStatusByName(string statusName)
        {
            try
            {
                var status = productinfoService.GetStatusByName(statusName);
                return Ok(status);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
