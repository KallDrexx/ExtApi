using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtApi.Engine.Data;

namespace ExtApi.Tester
{
    [Serializable]
    public class ExtApiSettings
    {
        public string LastApiUrl { get; set; }
        public string LastOAuthConsumerKey { get; set; }
        public string LastOAuthConsumerSecret { get; set; }
        public string LastOAuthAccessToken { get; set; }
        public string LastOAuthTokenSecret { get; set; }
        public string WebAuthUsername { get; set; }
        public List<ApiParameter> Parameters { get; set; }
    }
}
