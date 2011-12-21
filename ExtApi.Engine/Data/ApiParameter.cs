using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ExtApi.Engine.Data
{
    [Serializable]
    public class ApiParameter
    {
        /// <summary>
        /// Gets or sets the name of the API parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unencoded value of the api parameter
        /// </summary>
        public string UnencodedValue { get; set; }

        /// <summary>
        /// Gets or sets the value of the parameter encoded for use in an URL
        /// </summary>
        public string EncodedValue
        {
            get { return HttpUtility.UrlEncode(UnencodedValue); }
            set { UnencodedValue = HttpUtility.UrlDecode(value); }
        }

        public ApiParameter()
        {
            Name = string.Empty;
            UnencodedValue = string.Empty;
        }

        public override string ToString()
        {
            return string.Format("{0}={1}", Name, EncodedValue);
        }
    }
}
