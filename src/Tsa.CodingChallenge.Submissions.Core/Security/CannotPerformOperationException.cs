using System;

namespace Tsa.CodingChallenge.Submissions.Core.Security
{
    public class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException() { }

        public CannotPerformOperationException(string message) : base(message) { }

        public CannotPerformOperationException(string message, Exception inner) : base(message, inner) { }
    }
}