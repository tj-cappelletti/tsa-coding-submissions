using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Tsa.Coding.Submissions.WebApi.Responses
{
    /// <summary>
    ///     An <see cref="ObjectResult" /> that when executed performs content negotiation, formats the entity body, and
    ///     will produce a <see cref="StatusCodes.Status406NotAcceptable" /> response if the server doesn't find any content
    ///     that conforms to the criteria given by the user agent.
    /// </summary>
    [DefaultStatusCode(DefaultStatusCode)]
    public class NotAcceptableResult : ObjectResult
    {
        private const int DefaultStatusCode = StatusCodes.Status406NotAcceptable;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotAcceptableResult" /> class.
        /// </summary>
        public NotAcceptableResult()
            : base(null)
        {
            StatusCode = DefaultStatusCode;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NotAcceptableResult" /> class.
        /// </summary>
        /// <param name="value">The content to format into the entity body.</param>
        public NotAcceptableResult(object value)
            : base(value)
        {
            StatusCode = DefaultStatusCode;
        }
    }
}
