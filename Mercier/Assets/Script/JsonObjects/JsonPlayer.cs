using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class JsonPlayer
{
    public string PlayerID;
    public string SessionID;
    public string Username;
    public int Points;
    public int Stars;

    public JsonPlayer(string playerID, string sessionId, string username)
    {
        this.PlayerID = playerID;
        Points = 0;
        Stars = 0;
        SessionID = sessionId;
        this.Username = username;
    }
}
