using System;
using System.Net;
using System.Runtime.Serialization;

namespace Tsa.CodingChallenge.Submissions.Client
{
    [Serializable]
    public class WebApiClientException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public WebApiClientException(HttpStatusCode httpStatusCode, string message) : base(message) { HttpStatusCode = httpStatusCode; }

        protected WebApiClientException(SerializationInfo info, StreamingContext context) : base(info, context) { HttpStatusCode = (HttpStatusCode)info.GetInt32("HttpStatusCode"); }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(HttpStatusCode), HttpStatusCode);
        }
    }
}