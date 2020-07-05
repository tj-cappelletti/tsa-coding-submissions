using System.Collections;
using System.Collections.Generic;
using Tsa.CodingChallenge.Submissions.Core.Data.Annotations;

namespace Tsa.CodingChallenge.Submissions.UnitTests.Core.Data.Annotations
{
    public class PasswordComplexityAttributeTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "CapitalLetters", PasswordComplexityRules.CapitalLetters, 1, true };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}