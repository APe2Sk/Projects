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

        //[TestMethod]
        //public void DeleteTicket_WithTicketIdAndUserId_Deletestiket()
        //{
        //    var userId = 1;
        //    var user = new User();
        //    repoUser.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);

        //    var ticketid = 1;
        //    var ticket = new Ticket()
        //    {
        //        Numbers = new List<CombinationNumbers>
        //        {
        //            new CombinationNumbers { Number = 1 },
        //            new CombinationNumbers { Number = 2 },
        //            new CombinationNumbers { Number = 3 },
        //            new CombinationNumbers { Number = 4 },
        //            new CombinationNumbers { Number = 5 },
        //            new CombinationNumbers { Number = 6 },
        //            new CombinationNumbers { Number = 7 },
        //            new CombinationNumbers { Number = 8 }
        //        },
        //        Player = user,
        //        Session = new Session(),
        //        TicketNumbers = "1, 2, 3, 4, 5, 6, 7, 8",
        //        WinningNumbers = "1, 2, 3, 4",
        //        WinningNums = 4,
        //        DateOfCreation = DateTime.Now,
        //    };

        //    repoTicket.Setup(x => x.GetAll().ToList()
        //                                .FirstOrDefault(x => x.Id == ticket.Id))
        //                                .Returns(ticket);

        //    var result = service.DeleteTicket(ticket.Id, user.Id);

        //    Assert.AreEqual(ticket, result);
        //}



        //[TestMethod]
        //public void GetById_TicketID_Ticket()
        //{
        //    // Arrange
        //    var userId = 1;
        //    var user = new User()
        //    {
        //        Id =userId,
        //    };
        //    repoUser.Setup(x => x.GetById(It.IsAny<int>())).Returns(user);

        //    var ticketId = 1;
        //    var ticket = new Ticket()
        //    {
        //        Id = ticketId,
        //        Player = user,
        //    };
        //    var a = new List<Ticket> { ticket };
        //    var b = a.AsQueryable();            

        //    repoTicket.Setup(x => x.GetAll().Where(x => x.Id == ticket.Id)).Returns(b);

        //    // Act
        //    var result = service.GetById(ticket.Id, user.Id);

        //    // Assert
        //    Assert.AreEqual(mapper.Map<TicketDto>(b.First()), result);
        //}
    }
}
