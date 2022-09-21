using AutoMapper;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Repositories;
using LotoApplication.Application.Services;
using LotoApplication.Application.Services.Implementation;
using LotoApplication.Domain.Exceptions;
using LotoApplication.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.UnitTests.ApplicationTests.ServicesTests
{
    [TestClass]

    public class TicketServiceTests
    {
        private readonly Mock<IRepository<Ticket>> repoTicket = new Mock<IRepository<Ticket>>();
        private readonly Mock<IRepository<User>> repoUser = new Mock<IRepository<User>>();
        private readonly Mock<IRepository<Session>> repoSession = new Mock<IRepository<Session>>();
        private readonly Mock<IMapper> mapper = new Mock<IMapper>();
        private readonly TicketService service = null;

        public TicketServiceTests()
        {
            service = new TicketService(repoTicket.Object, repoUser.Object, repoSession.Object, mapper.Object);
        }

        // MethodName_Scenario_ExpectedResult -> name of unit test
        // 3 A -> Arrange -> act -> Assert
        [TestMethod]
        public void GetAll_TicketForUser_ThrowsNotFoundException()
        {
            var userId = 1;
            var tickets = new List<Ticket>();

            Assert.ThrowsException<NotFoundException>(() => service.GetAll(userId));
        }

        [TestMethod]
        public void GetAll_TicketForUser_ReturnsAllTicketForUser()
        {
            var userId = 1;
            var user = new User()
            {
                Id = userId,
            };
            var ticket = new Ticket()
            {
                Player = user,
            };
            var tickets = new List<Ticket> { ticket };
            var ticketsQuerable = tickets.AsQueryable();

            repoTicket.Setup(x => x.GetAll())
                                    .Returns(ticketsQuerable);

            var ticketsResult = service.GetAll(userId);

            Assert.IsNotNull(ticketsResult);
        }

        [TestMethod]
        public void DeleteTicket_WithTicketIdAndUserId_Deletestiket()
        {
            var userId = 1;
            var user = new User();
            repoUser.Setup(x => x.GetById(userId)).Returns(user);

            var ticketid = 1;
            var ticket = new Ticket()
            {
                Player = user,
            };

            var ticketList = new List<Ticket>() { ticket };


            repoTicket.Setup(x => x.GetAll().ToList()).Returns(ticketList);

            var result = service.DeleteTicket(ticketid, userId);

            Assert.AreEqual(ticket, result);
        }
    }
}
