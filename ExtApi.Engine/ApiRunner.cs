using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.OAuth.ChannelElements;
using ExtApi.Engine.Data;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.Messaging;
using System.Web;
using System.Net;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;

namespace ExtApi.Engine
{
    public class ApiRunner
    {
        /// <summary>
        /// Performs an OAuthed api call with the specified access token
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Thrown when no token manager has been specified</exception>
        public ExtApiCallResult ExecuteOAuthApiCall(string apiUrl, IList<ApiParameter> parameters, RequestMethod method,
                                                    string consumerKey, string consumerSecret, string accessToken, string tokenSecret)
        {
            var client = new RestClient(apiUrl);
            client.Authenticator = OAuth1Authenticator.ForAccessToken(consumerKey, consumerSecret, accessToken, tokenSecret);
            var request = new RestRequest();
            request.Method = ConvertRequestMethod(method);          

            foreach (var param in parameters)
                request.Parameters.Add(new Parameter { Name = param.Name, Value = param.UnencodedValue, Type = ParameterType.GetOrPost });

            // Execute the request
            return CreateExtApiCallResult(client.Execute(request));
        }

        /// <summary>
        /// Performs an api call on the specified URL 
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ExtApiCallResult ExecuteApiCall(string apiUrl, IList<ApiParameter> parameters, RequestMethod method, string username = "", string password = "")
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            request.Method = ConvertRequestMethod(method);            

            // Add all the parameters to the request
            foreach (var param in parameters)
                request.Parameters.Add(new Parameter { Name = param.Name, Value = param.UnencodedValue, Type = ParameterType.GetOrPost });

            // Setup authentication
            if (!string.IsNullOrWhiteSpace(username))
                client.Authenticator = new HttpBasicAuthenticator(username, password);

            // Execute the request
            return CreateExtApiCallResult(client.Execute(request));
        }

        protected ExtApiCallResult CreateExtApiCallResult(RestResponse response)
        {
            // Put the response content into a memorystream for reading
            var stream = new MemoryStream();
            var bytes = new System.Text.ASCIIEncoding().GetBytes(response.Content);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Position = 0;

            return new ExtApiCallResult
            {
                StatusCode = response.StatusCode,
                ResponseStream = stream,
                FinalUrl = response.ResponseUri.AbsoluteUri
            };
        }

        protected ExtApiCallResult HandleWebException(WebException ex)
        {
            var httpResponse = (HttpWebResponse)ex.Response;

            if (httpResponse != null)
            {
                return new ExtApiCallResult
                {
                    StatusCode = httpResponse.StatusCode,
                    ResponseStream = httpResponse.GetResponseStream(),
                    FinalUrl = httpResponse.ResponseUri.AbsoluteUri
                };
            }

            // else
            var stream = new MemoryStream();
            var msg = System.Text.Encoding.ASCII.GetBytes(string.Format("{0}: {1}", ex.GetType().ToString(), ex.Message));
            stream.Write(msg, 0, msg.Length);

            return new ExtApiCallResult
            {
                StatusCode = HttpStatusCode.NoContent,
                ResponseStream = stream,
                FinalUrl = httpResponse.ResponseUri.AbsoluteUri
            };
        }

        /// <summary>
        /// Builds a GET URL based on the specified api URL and the passed in parameters
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected string BuildGetUrl(string apiUrl, IList<ApiParameter> parameters)
        {
            StringBuilder resultingUrl = new StringBuilder(apiUrl);

            if (parameters == null || parameters.Count == 0)
                return apiUrl;

            // Add all the parameters to the url
            foreach (var param in parameters)
            {
                // Check if we already have a question mark in the URL (e.g. not the first parameter)
                if (resultingUrl.ToString().Contains('?'))
                    resultingUrl.Append('&');
                else
                    resultingUrl.Append('?');

                resultingUrl.Append(HttpUtility.UrlEncode(param.Name));
                resultingUrl.Append('=');
                resultingUrl.Append(param.EncodedValue);
            }

            return resultingUrl.ToString();
        }

        protected Method ConvertRequestMethod(RequestMethod method)
        {
            if (method == RequestMethod.Get)
                return Method.GET;
            else if (method == RequestMethod.Post)
                return Method.POST;
            else
                throw new NotSupportedException(
                    string.Format("The request method of {0} is not supported", method.ToString()));
        }
    }
}
