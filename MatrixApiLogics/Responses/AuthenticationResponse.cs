using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApiLogics.Responses
{

    public class AuthenticationResponse
    {
        public string user_id { get; set; }
        public string access_token { get; set; }
        public string home_server { get; set; }
        public string device_id { get; set; }
        public WellKnown well_known { get; set; }
    }
    public class MHomeserver
    {
        public string base_url { get; set; }
    }

    public class WellKnown
    {
        public MHomeserver homeserver { get; set; }
    }
    public class Error
    {
        public string errcode { get; set; }
        public string error { get; set; }
        public int retry_after_ms { get; set; }
    }

}
