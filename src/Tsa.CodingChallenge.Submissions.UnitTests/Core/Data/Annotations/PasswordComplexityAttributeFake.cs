using System.ComponentModel.DataAnnotations;
using Tsa.CodingChallenge.Submissions.Core.Data.Annotations;

namespace Tsa.CodingChallenge.Submissions.UnitTests.Core.Data.Annotations
{
    /// <summary>
    ///     A class to provide an instantiable object to unit test <see cref="PasswordComplexityAttribute" />
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <see cref="PasswordComplexityAttribute" /> implements protected methods which cannot be directly unit
    ///         tested.
    ///     </para>
    ///     <para>This fake exposes those methods so they can be unit tested without breaking interface contract.</para>
    /// </remarks>
    public class PasswordComplexityAttributeFake : PasswordComplexityAttribute
    {
        public PasswordComplexityAttributeFake(PasswordComplexityRules complexityRules, int minimumRulesToApply) : base(complexityRules, minimumRulesToApply) { }

        public ValidationResult TestIsValid(object value, ValidationContext validationContext)
        {
            return IsValid(value, validationContext);
        }
    }
}