using LotoApplication.Application;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Security;
using LotoApplication.Application.Services;
using LotoApplication.Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace LotoApplication.Api.Controllers
{
    [Authorize(Policy = SystemPolicies.RoleAdmin)]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService sessionService;
        private readonly IDrawService drawService;
        private readonly IWinnerService winnerService;
        private readonly Serilog.ILogger logger;



        public SessionController(ISessionService sessionService, IDrawService drawService, IWinnerService winnerService, Serilog.ILogger logger)
        {
            this.sessionService = sessionService;
            this.drawService = drawService;
            this.winnerService = winnerService;
            this.logger = logger;
            logger.Debug("");
            logger.Information("");
            logger.Warning("");
            logger.Error("");
        }

        [HttpPost]
        public ActionResult CreateSession()
        {
            //var session = sessionService.GenerateDrawNumbers(newSession, adminId);

            //var drawNumbers = drawService.GenerateDrawNumbers();  

            // new claimsprincipal wrapper i go zimame

            var adminIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(adminIdString, out int adminId))
            {
                 throw new Exception("");
            }

            try
            {   
                var a = sessionService.CreateSession(adminId);

                return Ok(a);
            }
            catch(CanNotCreateException ex)
            {
                logger.Warning("It is not possible to have more than one active sessions!", ex);

                return BadRequest("It is not possible to have more than one active sessions!");
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"There aren't any admins by ID {adminId}!", ex);

                return NotFound($"There aren't any admins by ID {adminId}!");
            }
        }

        [HttpGet]
        public ActionResult GetAllSessions()
        {
            try
            {
                var allSessions = sessionService.GetAllSessions();
                return Ok(allSessions);
            }
            catch(NotFoundException ex)
            {
                logger.Warning("There aren't any sessions!", ex);

                return NotFound("There aren't any sessions!");
            }
;
        }

        [HttpGet("{sessionId:int}")]
        public ActionResult GetById(int sessionId)
        {
            try
            {
                var session = sessionService.GetById(sessionId);
                return Ok(session);
            }
            catch(NotFoundException ex)
            {
                logger.Warning($"There aren't any session by id {sessionId}!", ex);

                return NotFound($"There aren't any session by id {sessionId}!");
            }
        }

        [HttpDelete]
        public ActionResult DeleteSession([FromQuery]int sessionId)
        {
            var adminIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(adminIdString, out int adminId))
            {
                throw new Exception("");
            }


            try
            {
                var session = sessionService.DeleteSession(sessionId, adminId);
                return Ok(session);
            }
            catch (NotFoundException ex)
            {
                logger.Warning($"There aren't any session by id {sessionId} by this admin id {adminId}!", ex);
                return NotFound($"There aren't any session by id {sessionId} by this admin id {adminId}!");
            }
        }

        [HttpPost("/generateAndEndSession")]
        public ActionResult GenerateNumbers()
        {
            var adminIdString = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

            if (!int.TryParse(adminIdString, out int adminId))
            {
                throw new Exception("");
            }


            try
            {
                var drawNumbers = drawService.GenerateDrawNumbers(adminId);

                //var drawNumbers = new DrawDto
                //{
                //    DrawNumbers = new List<DrawNumberDto>
                //    {
                //        new DrawNumberDto{ Number = 1 },
                //        new DrawNumberDto{ Number = 2 },
                //        new DrawNumberDto{ Number = 3 },
                //        new DrawNumberDto{ Number = 4 },
                //        new DrawNumberDto{ Number = 5 },
                //        new DrawNumberDto{ Number = 6 },
                //        new DrawNumberDto{ Number = 7 },
                //        new DrawNumberDto{ Number = 8 },
                //    },
                //    DrawedNumbers = "1, 2, 3, 4, 5, 6, 7,"
                //};

                var generateWinners = winnerService.GenerateWinners(drawNumbers);
                var activeSessionUpdate = sessionService.GetNumbers(adminId, drawNumbers);
                
                return Ok(activeSessionUpdate);
            }
            catch(NotFoundException ex)
            {
                logger.Warning("Session not found! There aren't any active sessions right now.", ex);

                return NotFound("Session not found! There aren't any active sessions right now.");
            }
            catch(NotCreateException ex)
            {
                logger.Warning("There aren't any active sessions right now.", ex);

                return NotFound("There aren't any active sessions right now.");
            }
            catch(CanNotCreateException ex)
            {
                logger.Warning("Only admin's can manipulate with sessions in the system.", ex);

                return BadRequest("Only admin's can manipulate with sessions in the system.");
            }
            catch(OutOfRangeException ex)
            {
                logger.Warning("There aren't tickets for this session.", ex);

                return BadRequest("There aren't tickets for this session.");
            }
        }
    }
}
