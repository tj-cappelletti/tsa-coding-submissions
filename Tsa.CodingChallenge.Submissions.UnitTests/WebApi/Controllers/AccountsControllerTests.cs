using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Tsa.CodingChallenge.Submissions.Core.Repositories;
using Tsa.CodingChallenge.Submissions.Core.Security;
using Tsa.CodingChallenge.Submissions.WebApi.Controllers;
using Tsa.CodingChallenge.Submissions.WebApi.Model;

namespace Tsa.CodingChallenge.Submissions.UnitTests.WebApi.Controllers
{
    public class AccountsControllerTests
    {
        public void TestAccountsControllerLogin(LoginModel loginModel, ObjectResult expectedObjectResult)
        {
            // Arrange
            var loginRepositoryMock = new Mock<ILoginRepository>();
            var passwordStorageMock = new Mock<IPasswordStorage>();

            var accountsController = new AccountsController(loginRepositoryMock.Object, passwordStorageMock.Object);

            // Act
            var objectResult = accountsController.Login(loginModel);
        }
    }
}