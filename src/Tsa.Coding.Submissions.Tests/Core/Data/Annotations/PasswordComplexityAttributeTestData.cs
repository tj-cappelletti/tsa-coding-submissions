using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tsa.Coding.Submissions.Core.Data.Annotations;

namespace Tsa.Coding.Submissions.Tests.Core.Data.Annotations
{
    public class PasswordComplexityAttributeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "CapitalLetters", PasswordComplexityRules.CapitalLetters, 1, ValidationResult.Success };
            yield return new object[] { "Numbers1", PasswordComplexityRules.Numbers, 1, ValidationResult.Success };
            yield return new object[] { "Punctuation!", PasswordComplexityRules.Punctuation, 1, ValidationResult.Success };
            yield return new object[] { "SpecialCharacters@", PasswordComplexityRules.SpecialCharacters, 1, ValidationResult.Success };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
