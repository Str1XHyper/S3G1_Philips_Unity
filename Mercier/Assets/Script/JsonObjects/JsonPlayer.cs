using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class JsonPlayer
{
    private string playerID;
    private string sessionID;
    private string username;
    private int points;
    private int stars;

    public JsonPlayer(string playerID, string sessionId, string username)
    {
        this.playerID = playerID;
        points = 0;
        stars = 0;
        sessionID = sessionId;
        this.username = username;
    }

    public string PlayerID { get => playerID; }
    public int Points { get => points; }
    public int Stars { get => stars; }
    public string SessionID { get => sessionID; }
    public string Username { get => username; }
}
