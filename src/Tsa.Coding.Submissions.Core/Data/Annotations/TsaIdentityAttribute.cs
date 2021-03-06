﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Tsa.Coding.Submissions.Core.Data.Annotations
{
    public class TsaIdentityAttribute : ValidationAttribute
    {
        private readonly TsaIdentityType _tsaIdentityType;
        private const string IndividualInvalidFormatMessage = "Your student number must in the format of '####-###'.";
        private const string TeamInvalidFormatMessage = "The team number must in the format of '####-###'. This is your school number followed by your team number.";
        private const string TsaTeamNumberRegExPattern = @"[\d]{4}-[\d]{3}";

        public TsaIdentityAttribute(TsaIdentityType tsaIdentityType)
        {
            _tsaIdentityType = tsaIdentityType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var identity = value as string;

            if (string.IsNullOrWhiteSpace(identity))
                return ValidationResult.Success;

            return Regex.IsMatch(identity, TsaTeamNumberRegExPattern)
                ? ValidationResult.Success
                : new ValidationResult(_tsaIdentityType == TsaIdentityType.Individual ? IndividualInvalidFormatMessage : TeamInvalidFormatMessage);
        }
    }
}
