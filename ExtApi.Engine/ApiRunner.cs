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

namespace ExtApi.Engine
{
    public class ApiRunner
    {
        /// <summary>
        /// Gets or sets the DotNetOpenAuth token manager to use for OAuth API call
        /// </summary>
        public IConsumerTokenManager OAuthTokenManager { get; set; }

        /// <summary>
        /// Performs an OAuthed api call with the specified access token
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="parameters"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Thrown when no token manager has been specified</exception>
        public ExtApiCallResult ExecuteOAuthApiCall(string apiUrl, IList<ApiParameter> parameters, string accessToken)
        {
            if (OAuthTokenManager == null)
                throw new InvalidOperationException("Cannot perform an OAuth API call without a valid OAuth token manager");

            // Setup OAuth Request
            var serviceProviderDesc = new ServiceProviderDescription
            {
                ProtocolVersion = ProtocolVersion.V10a,
                TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() }
            };

            var consumer = new WebConsumer(serviceProviderDesc, OAuthTokenManager);
            var endpoint = new MessageReceivingEndpoint(BuildGetUrl(apiUrl, parameters), HttpDeliveryMethods.GetRequest);
            var request = consumer.PrepareAuthorizedRequest(endpoint, accessToken);

            // Perform the web request
            WebResponse response;
            try { response = request.GetResponse(); }
            catch (WebException ex)
            {
                return HandleWebException(ex);
            }

            // Call was successful
            return new ExtApiCallResult
            {
                StatusCode = HttpStatusCode.OK,
                ResponseStream = response.GetResponseStream()
            };
        }

        /// <summary>
        /// Performs an api call on the specified URL 
        /// </summary>
        /// <param name="apiUrl"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public ExtApiCallResult ExecuteApiCall(string apiUrl, IList<ApiParameter> parameters)
        {
            var request = HttpWebRequest.Create(BuildGetUrl(apiUrl, parameters));
            request.Method = WebRequestMethods.Http.Get;

            // Perform the web request
            WebResponse response;
            try { response = request.GetResponse(); }
            catch (WebException ex)
            {
                return HandleWebException(ex);
            }

            return new ExtApiCallResult
            {
                StatusCode = HttpStatusCode.OK,
                ResponseStream = response.GetResponseStream()
            };
        }

        private ExtApiCallResult HandleWebException(WebException ex)
        {
            var httpResponse = (HttpWebResponse)ex.Response;

            if (httpResponse != null)
            {
                return new ExtApiCallResult
                {
                    StatusCode = httpResponse.StatusCode,
                    ResponseStream = httpResponse.GetResponseStream()
                };
            }

            // else
            var stream = new MemoryStream();
            var msg = System.Text.Encoding.ASCII.GetBytes(string.Format("{0}: {1}", ex.GetType().ToString(), ex.Message));
            stream.Write(msg, 0, msg.Length);

            return new ExtApiCallResult
            {
                StatusCode = HttpStatusCode.NoContent,
                ResponseStream = stream
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
    }
}
