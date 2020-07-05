using Tsa.CodingChallenge.Submissions.Core.Data.Annotations;
using Xunit;

namespace Tsa.CodingChallenge.Submissions.UnitTests.Core.Data.Annotations
{
    public class PasswordComplexityAttributeTests
    {
        [ClassData(typeof(PasswordComplexityAttributeTestData))]
        [Theory]
        [Trait("UnitTest", "Core")]
        public void TestPasswordComplexityAttributeIsValid(string password, PasswordComplexityRules complexityRules, int minimumRulesToApply, bool expectedResult)
        {
            // Arrange
            var passwordComplexityAttributeFake = new PasswordComplexityAttributeFake(complexityRules, minimumRulesToApply);

            // Act
            var actualResult = passwordComplexityAttributeFake.IsValid(password);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}