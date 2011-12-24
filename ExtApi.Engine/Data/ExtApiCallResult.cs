using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace ExtApi.Engine.Data
{
    public class ExtApiCallResult
    {
        /// <summary>
        /// Gets or sets the status code of the api call result
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        protected Stream _responseStream;

        /// <summary>
        /// Gets or sets the api call response's stream
        /// </summary>
        public Stream ResponseStream
        {
            get { return _responseStream; }
            set
            {
                // Copy the stream into a memory string, so it can be re-read
                const int readSize = 256;
                byte[] buffer = new byte[readSize];
                MemoryStream ms = new MemoryStream();

                int count = value.Read(buffer, 0, readSize);
                while (count > 0)
                {
                    ms.Write(buffer, 0, count);
                    count = value.Read(buffer, 0, readSize);
                }
                ms.Position = 0;
                value.Close();

                _responseStream = ms;
            }
        }

        /// <summary>
        /// Retrieves the api call's result as xml
        /// </summary>
        public XDocument XmlResponse
        {
            get
            {
                // Attempt to turn the response stream into an Linq-To-Xml document
                try { return XDocument.Load(_responseStream); }
                catch (XmlException)
                {
                    return null;
                }

                finally
                {
                    // Reset the stream to the beginning
                    _responseStream.Position = 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the URL that was built after all parameters were added
        /// </summary>
        public string FinalUrl { get; set; }
    }
}
