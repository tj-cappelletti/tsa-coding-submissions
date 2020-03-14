using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace Tsa.CodingChallenge.Submissions.Client
{
    public abstract class WebApiClientBase
    {
        protected const string GenericErrorMessage = "An unknown error occured.";

        protected void CheckForOk(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK)
                return;

            var message = GetErrorMessage(response.Content);
            throw new WebApiClientException(response.StatusCode, message);
        }

        protected void CheckForOkOrNotFound(IRestResponse response)
        {
            if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NotFound)
                return;

            var message = GetErrorMessage(response.Content);
            throw new WebApiClientException(response.StatusCode, message);
        }

        protected string GetErrorMessage(string jsonContent)
        {
            if (string.IsNullOrWhiteSpace(jsonContent))
                return GenericErrorMessage;

            var definition = new { Message = string.Empty };

            string returnMessage = null;

            try
            {
                var jsonObject = JsonConvert.DeserializeAnonymousType(jsonContent, definition);

                returnMessage = jsonObject.Message;
            }
            catch (JsonReaderException)
            {
                // If a JsonReaderException is thrown just return the generic message
            }

            return string.IsNullOrWhiteSpace(returnMessage)
                ? GenericErrorMessage
                : returnMessage;
        }
    }
}