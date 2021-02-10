using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Tsa.Coding.Submissions.Core.Data.Annotations
{
    public class PasswordComplexityAttribute : ValidationAttribute
    {
        private readonly PasswordComplexityRules _complexityRules;
        private readonly int _minimumRulesToApply;
        private const string CapitalLettersRegEx = "(?=.*[A-Z])";
        private const string NumbersRegEx = "(?=.*[0-9])";
        private const string PunctuationRegEx = "(?=.*[\\.\\,\\;\\:\\!\\?\\\'\\\"\\-])";
        private const string SpecialCharactersRegEx = "(?=.*[\\@\\#\\$\\%\\^\\&\\*\\(\\)_\\=\\+\\{\\[\\]\\}\\|\\\\\\/\\<\\>\\~\\`])";

        public PasswordComplexityAttribute(PasswordComplexityRules complexityRules, int minimumRulesToApply)
        {
            _complexityRules = complexityRules;
            _minimumRulesToApply = minimumRulesToApply;
        }

        private List<string> GetPasswordRuleNames()
        {
            var ruleNamesList = new List<string>();

            if (_complexityRules.HasFlag(PasswordComplexityRules.CapitalLetters))
                ruleNamesList.Add("capital letter");

            if (_complexityRules.HasFlag(PasswordComplexityRules.Numbers))
                ruleNamesList.Add("number");

            if (_complexityRules.HasFlag(PasswordComplexityRules.Punctuation))
                ruleNamesList.Add("punctuation");

            if (_complexityRules.HasFlag(PasswordComplexityRules.SpecialCharacters))
                ruleNamesList.Add("special character");

            return ruleNamesList;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
                return new ValidationResult("The password did not contain any valid characters.");

            var successfulParts = 0;

            if (_complexityRules.HasFlag(PasswordComplexityRules.CapitalLetters) && Regex.IsMatch(password, CapitalLettersRegEx))
                successfulParts++;

            if (_complexityRules.HasFlag(PasswordComplexityRules.Numbers) && Regex.IsMatch(password, NumbersRegEx))
                successfulParts++;

            if (_complexityRules.HasFlag(PasswordComplexityRules.Punctuation) && Regex.IsMatch(password, PunctuationRegEx))
                successfulParts++;

            if (_complexityRules.HasFlag(PasswordComplexityRules.SpecialCharacters) && Regex.IsMatch(password, SpecialCharactersRegEx))
                successfulParts++;

            if (successfulParts >= _minimumRulesToApply)
                return ValidationResult.Success;

            var errorMessageStringBuilder = new StringBuilder($"The password must contain at least {_minimumRulesToApply} of the following: ");

            var ruleNames = GetPasswordRuleNames();

            for (var index = 0; index < ruleNames.Count; index++)
            {
                if (index != 0 && ruleNames.Count > 2)
                    errorMessageStringBuilder.Append(", ");

                if (index == ruleNames.Count - 1 && ruleNames.Count > 1)
                    errorMessageStringBuilder.Append("and ");

                errorMessageStringBuilder.Append(ruleNames[index]);
            }

            errorMessageStringBuilder.Append(".");

            return new ValidationResult(errorMessageStringBuilder.ToString());
        }
    }
}
