using System.Collections;
using System.Collections.Generic;
using Tsa.CodingChallenge.Submissions.Core.Data.Annotations;

namespace Tsa.CodingChallenge.Submissions.UnitTests.Core.Data.Annotations
{
    public class PasswordComplexityAttributeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "CapitalLetters", PasswordComplexityRules.CapitalLetters, 1, null };
            yield return new object[] { "Numbers1", PasswordComplexityRules.Numbers, 1, null };
            yield return new object[] { "Punctuation!", PasswordComplexityRules.Punctuation, 1, null };
            yield return new object[] { "SpecialCharacters@", PasswordComplexityRules.SpecialCharacters, 1, null };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}