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
        private Mock<IAccountService> _accountService = new Mock<IAccountService>();
        private Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

        public AccountControllerTest()
        {
            controller = new AccountController(_userRepository.Object, _accountService.Object);
        }

        [Fact]
        public async Task Login_IsSuccess_ReturnOk()
        {
            _accountService
                .Setup(x => x.Login(It.Is<LoginDto>(x => x.Username == "username")))
                .ReturnsAsync(new UserDto { IsSuccess = true });

            var result = await controller.Login(new LoginDto { Username = "username" });

            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Register_IsSucces_Should_ReturnOk()
        {
            var registerDto = new RegisterDto()
            {
                Username = "trung1",
                Password = "Str1trung",
                ConfirmPassword = "Str1trung",
                FirstName = "Trung",
                LastName = "Phan Van",
                Email = "trung1@gmail.com",
                Gender = "Male",
                Phone = "0978785678",
                DateOfBirth = "19/04/2000",
                Avatar = "",
            };

            _accountService.Setup(controller => controller.Register(registerDto));

            var result = await controller.Resgister(registerDto);

            Assert.IsType<OkObjectResult>(result);
        }
    }
}
