using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixApiLogics.Responses
{

    public class MessageResponse
    {
        public List<Chunks> chunk { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
    public class Events
    {
        public int avatar { get; set; }
        public int canonical_alias { get; set; }
        public int history_visibility { get; set; }
        public int roomname { get; set; }
        public int power_levels { get; set; }
    }

    public class Users
    {
        public int @gitterbot{ get; set; }
}

public class Content
{
        public string body { get; set; }
        public string formatted_body { get; set; }
        public string msgtype { get; set; }
        public string creator { get; set; }
    public string avatar_url { get; set; }
    public string displayname { get; set; }
    public string membership { get; set; }
    public int? ban { get; set; }
    public Events events { get; set; }
    public int? events_default { get; set; }
    public int? invite { get; set; }
    public int? kick { get; set; }
    public int? redact { get; set; }
    public int? state_default { get; set; }
    public Users users { get; set; }
    public int? users_default { get; set; }
    public string alias { get; set; }
    public string join_rule { get; set; }
    public string history_visibility { get; set; }
    public string name { get; set; }
    public List<string> aliases { get; set; }
}

public class Unsigned
{
    public object age { get; set; }
}

public class Chunks
{
    public Content content { get; set; }
    public string event_id { get; set; }
    public object origin_server_ts { get; set; }
    public string room_id { get; set; }
    public string sender { get; set; }
    public string state_key { get; set; }
    public string type { get; set; }
    public Unsigned unsigned { get; set; }
    public string user_id { get; set; }
    public object age { get; set; }
    public string membership { get; set; }
}


}
