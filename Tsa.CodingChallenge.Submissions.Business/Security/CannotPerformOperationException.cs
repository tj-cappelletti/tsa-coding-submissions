using System;

namespace Tsa.CodingChallenge.Submissions.Business.Security
{
    public class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException() { }

        public CannotPerformOperationException(string message) : base(message) { }

        public CannotPerformOperationException(string message, Exception inner) : base(message, inner) { }
    }
}