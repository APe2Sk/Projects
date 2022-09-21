using LotoApplication.Application.Dto;
using LotoApplication.Application.Security;
using LotoApplication.Application.Services;
using LotoApplication.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LotoApplication.Api.Controllers
{
    [Authorize(Policy = SystemPolicies.RoleUser)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService ticketService;
        private readonly Serilog.ILogger logger;


        public TicketController(ITicketService ticketService, Serilog.ILogger logger)
        {
            this.ticketService = ticketService;
            this.logger = logger;
            logger.Debug("");
            logger.Information("");
            logger.Warning("");
            logger.Error("");
        }

        [HttpGet]
        public ActionResult GetAllTickets()
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                logger.Warning($"There aren't any tickets id's for this user id {userId}!");
                throw new Exception($"There aren't any tickets id's for this user id {userId}!");
            }


            try
            {
                var tickets = ticketService.GetAll(userId);
                return Ok(tickets);
            }
            catch(NotFoundException ex)
            {
                logger.Warning($"There aren't any tickets id's for this user id {userId}!", ex);
                return NotFound("There aren't any tickets id's for this user!");
            }
        }

        [HttpGet("{ticketId:int}")]
        public ActionResult GetTicketById(int ticketId)
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                throw new Exception("");
            }

            try
            {
                var ticket = ticketService.GetById(ticketId, userId);
                return Ok(ticket);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"There aren't any tickets id's for this user id {userId}!", ex);
                return NotFound("There aren't any tickets id for this user id!");
            }
        }

        [HttpPost]
        public ActionResult CreateTicket(CreateTicketDto ticket)
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                throw new Exception("");
            }

            try
            {
                var ticketCreated = ticketService.CreateTicket(ticket, userId);

                return Ok(ticketCreated);
            }
            catch(NotFoundException ex)
            {
                logger.Warning($"Not found user (id {userId}) or session.", ex);
                return NotFound("Not found user or session.");
            }
            catch(OutOfRangeException ex)
            {
                logger.Warning($"The inputted numbers should be between 1 and 37, the inputted numbers exceed the range.", ex);

                return BadRequest("The inputted numbers should be between 1 and 37, the inputted numbers exceed the range.");
            }
            catch (CanNotCreateException ex)
            {
                logger.Warning($"The inputted numbers canno't be dubbled.", ex);

                return BadRequest("The inputted numbers canno't be dubbled.");
            }
            catch(NotCreateException ex)
            {
                logger.Warning($"You can't create new ticket, because there aren't any active sessions.", ex);

                return BadRequest("You can't create new ticket, because there aren't any active sessions.");
            }

        }

        [HttpDelete]
        public ActionResult DeleteTicket(int ticketId)
        {
            var userIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(userIdString, out int userId))
            {
                logger.Warning($"There aren't any tickets id's for this user id {userId}!");
                throw new Exception("There aren't any tickets id's for this user!");
            }

            try
            {
                var deletedTicket = ticketService.DeleteTicket(ticketId, userId);
                return Ok(deletedTicket);
            }
            catch(NotFoundException ex)
            {
                logger.Warning($"There aren't any tickets id's for this user id {userId}!", ex);
                return NotFound("There aren't any tickets id's for this user!");
            }
        }
    }
}
