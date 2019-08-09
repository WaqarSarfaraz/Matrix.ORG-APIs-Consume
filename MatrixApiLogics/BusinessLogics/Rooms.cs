using MatrixApiLogics.DTOS;
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
    public class Rooms : BaseConfig
    {

        public List<detail> JoinedRooms(string token)
        {
            var client = new RestClient(string.Format("{0}/r0/joined_rooms?access_token={1}", HomeServer,token));
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            var clientP = new RestClient(string.Format("{0}/r0/publicRooms", HomeServer));
            var requestP = new RestRequest(Method.GET);
            requestP.AddHeader("cache-control", "no-cache");
            requestP.AddHeader("content-type", "application/json");
            try
            {
                IRestResponse<PublicRoom> responseP = clientP.Execute<PublicRoom>(requestP);

               var PublicRooms = responseP.Data.chunk;
                IRestResponse<JoinRoomsResponse> response2 = client.Execute<JoinRoomsResponse>(request);
    
                List<detail> FinalRoom = new List<detail>();
                foreach (var item in PublicRooms)
                {
                    foreach (var itemFinal in response2.Data.joined_rooms)
                    {
                        if (item.room_id == itemFinal)
                        {
                            detail dt = new detail();
                            dt.Name = item.name;
                            dt.Roomid = itemFinal;
                            FinalRoom.Add(dt);
                        }
                           
                    }
                   
                }

                return FinalRoom;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public object  GetMessage(string token,string Roomid)
        {
            var client = new RestClient(string.Format("{0}/r0/rooms/{1}/messages?from=s345_678_333&dir=f&limit=50&filter=%7B%22contains_url%22%3Afalse%7D&access_token={2}", HomeServer,Roomid,token));
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            try
            {
                IRestResponse<MessageResponse> response2 = client.Execute<MessageResponse>(request);
                var d = response2.Data.chunk;
                d.Where(x => x.content.body != null || x.content.displayname != null).ToList();
                return d ;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
