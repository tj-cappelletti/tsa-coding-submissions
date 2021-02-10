using Microsoft.AspNetCore.Mvc;
using Moq;
using Tsa.Coding.Submissions.Core.Repositories;
using Tsa.Coding.Submissions.Core.Security;
using Tsa.Coding.Submissions.WebApi.Controllers;
using Tsa.Coding.Submissions.WebApi.Model;

namespace Tsa.Coding.Submissions.Tests.WebApi.Controllers
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
