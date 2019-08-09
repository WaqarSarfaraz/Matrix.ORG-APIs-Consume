using MatrixApiLogics.Responses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApiLogics.BusinessLogics
{
    public class Authentication : BaseConfig
    {
        public string MatrixAuthentication(string username, string password)
        {
            var client = new RestClient(string.Format("{0}/r0/login", HomeServer));
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", string.Format("{{\n\t\"type\":\"{0}\",\n\t\"user\":\"{1}\",\n\t\"password\":\"{2}\"\n}}", "m.login.password", username, password), ParameterType.RequestBody);
            try
            {
                IRestResponse<AuthenticationResponse> response2 = client.Execute<AuthenticationResponse>(request);
                if(response2.StatusCode == HttpStatusCode.OK)
                {
                    return response2.Data.access_token;

                }
                else
                {
                    IRestResponse<Error> response3 = client.Execute<Error>(request);
                    return response3.StatusCode.ToString();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
