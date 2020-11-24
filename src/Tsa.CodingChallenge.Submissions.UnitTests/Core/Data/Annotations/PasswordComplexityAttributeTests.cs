using System.ComponentModel.DataAnnotations;
using Tsa.CodingChallenge.Submissions.Core.Data.Annotations;
using Xunit;

namespace Tsa.CodingChallenge.Submissions.UnitTests.Core.Data.Annotations
{
    public class PasswordComplexityAttributeTests
    {
        [ClassData(typeof(PasswordComplexityAttributeTestData))]
        [Theory]
        [Trait("TestCategory", "UnitTest")]
        [Trait("AppLayer", "Core")]
        public void TestPasswordComplexityAttributeIsValid(string password, PasswordComplexityRules complexityRules, int minimumRulesToApply, ValidationResult expectedResult)
        {
            // Arrange
            var passwordComplexityAttributeFake = new PasswordComplexityAttributeFake(complexityRules, minimumRulesToApply);

            // Act
            var actualResult = passwordComplexityAttributeFake.TestIsValid(password, null);

            // Assert
            //TODO: Need to fix deep comparison
            Assert.Equal(expectedResult, actualResult);
        }
    }
}