using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Chat
{
    public string id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string type { get; set; }
}

public class From
{
    public string id { get; set; }
    public bool is_bot { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string username { get; set; }
    public string language_code { get; set; }
}

public class Message
{
    public From from { get; set; }
    public Chat chat { get; set; }
    public int date { get; set; }
    public string text { get; set; }
}

public class Result
{
    public int update_id { get; set; }
    public From from { get; set; }
    public Chat chat { get; set; }
    public Message message { get; set; }
    public MyChatMember myChatMember { get; set; }
}

public class Root
{
    public bool ok { get; set; }
    public List<Result> result { get; set; }
}
public class MyChatMember
{
    public Chat2 chat { get; set; }
    public From from { get; set; }
    public int date { get; set; }
    public OldChatMember old_chat_member { get; set; }
    public NewChatMember new_chat_member { get; set; }
}

public class NewChatMember
{
    public User user { get; set; }
    public string status { get; set; }
    public bool can_be_edited { get; set; }
    public bool can_manage_chat { get; set; }
    public bool can_change_info { get; set; }
    public bool can_delete_messages { get; set; }
    public bool can_invite_users { get; set; }
    public bool can_restrict_members { get; set; }
    public bool can_pin_messages { get; set; }
    public bool can_promote_members { get; set; }
    public bool can_manage_video_chats { get; set; }
    public bool is_anonymous { get; set; }
    public bool can_manage_voice_chats { get; set; }
}

public class OldChatMember
{
    public User user { get; set; }
    public string status { get; set; }
}
public class User
{
    public long id { get; set; }
    public bool is_bot { get; set; }
    public string first_name { get; set; }
    public string username { get; set; }
}
public class Chat2
{
    public string type { get; set; }
    public string titel { get; set; }
    public string id { get; set; }
}