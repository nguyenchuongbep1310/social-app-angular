using DatingApp.Application.Interfaces;
using DatingApp.Controllers;
using DatingApp.Core.DTO;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class AccountControllerTest
    {
        private AccountController controller;
        private Mock<ITokenService> tokenService;
        private Mock<IAccountService> accountService;

        public AccountControllerTest()
        {
            tokenService = new Mock<ITokenService>();
            accountService = new Mock<IAccountService>();
            

            controller = new AccountController(null, tokenService.Object, accountService.Object);
        }

        [Fact]
        public async Task Login_IsSuccess_ReturnOk()
        {
            accountService
                .Setup(x => x.Login(It.Is<LoginDto>(x => x.Username == "username")))
                .ReturnsAsync(new UserDto { IsSuccess = true });

            var result = await controller.Login(new LoginDto { Username = "username" });

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
