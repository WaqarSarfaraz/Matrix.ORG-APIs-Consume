using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApiLogics.Responses
{

    public class JoinRoomsResponse
    {
        public List<string> joined_rooms { get; set; }
    }

    public class RoomError
    {
        public string errcode { get; set; }
        public string error { get; set; }
        public bool soft_logout { get; set; }
    }
    public class Chunk
    {
        public string room_id { get; set; }
        public int num_joined_members { get; set; }
        public bool? federate { get; set; }
        public List<string> aliases { get; set; }
        public string name { get; set; }
        public string topic { get; set; }
        public bool world_readable { get; set; }
        public bool guest_can_join { get; set; }
        public string avatar_url { get; set; }
    }

    public class PublicRoom
    {
        public List<Chunk> chunk { get; set; }
        public int total_room_count_estimate { get; set; }
        public string next_batch { get; set; }
    }
}
