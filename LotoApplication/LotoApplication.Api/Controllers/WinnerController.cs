using LotoApplication.Application.Security;
using LotoApplication.Application.Services;
using LotoApplication.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LotoApplication.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService winnerService;
        private readonly Serilog.ILogger logger;

        public WinnerController(IWinnerService winnerService, Serilog.ILogger logger)
        {
            this.winnerService = winnerService;
            this.logger = logger;
            logger.Debug("");
            logger.Information("");
            logger.Warning("");
            logger.Error("");
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpGet]
        public ActionResult GetAllWinners()
        {
            try
            {
                var allWinners = winnerService.GetAllWinners();
                return Ok(allWinners);
            }
            catch (NotFoundException ex)
            {
                logger.Warning("There aren't any winners.", ex);
                return NotFound("There aren't any winners yet.");
            }
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpGet("user")]
        public ActionResult GetAllWinnersForUser([FromQuery] int userId)
        {
            try
            {
                var winners = winnerService.GetAllWinnersForUser(userId);
                return Ok(winners);
            }
            catch(NotFoundException ex)
            {
                logger.Warning($"This userId {userId} doesn't have winning tickets.", ex);
                return NotFound("This user doesn't have winning tickets.");
            }
        }

        [Authorize(Policy = SystemPolicies.RoleAdmin)]
        [HttpGet("ticket")]
        public ActionResult GetWinnerByTicketId([FromQuery] int ticketId)
        {
            try
            {
                var winningTicket = winnerService.GetWinnerByTicketId(ticketId);
                return Ok(winningTicket);
            }
            catch (NotFoundException)
            {
                return NotFound("This ticket ID is not winning ticket");
            }
        }

        [HttpGet("session")]
        public ActionResult GetAllWinnersForSession([FromQuery]int sessionId)
        {
            try
            {
                var winningTicketBySessionId = winnerService.GetAllWinnersForSession(sessionId);
                return Ok(winningTicketBySessionId);
            }
            catch (NotFoundException)
            {
                return NotFound("Invalid session ID.");
            }
        }
    }
}
