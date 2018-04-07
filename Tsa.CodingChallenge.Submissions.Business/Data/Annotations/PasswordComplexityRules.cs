using System;

namespace Tsa.CodingChallenge.Submissions.Business.Data.Annotations
{
    [Flags]
    public enum PasswordComplexityRules
    {
        CapitalLetters = 1,
        Numbers = 1 << 1,
        Punctuation = 1 << 2,
        SpecialCharacters = 1 << 3,
        All = CapitalLetters | Numbers | Punctuation | SpecialCharacters
    }
}