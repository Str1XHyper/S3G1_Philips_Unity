using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinMessage : SocketMessage
{
    public string LessonId;
    public string Username;

    public PlayerJoinMessage(string playerId, string lessonId, string username) : base(playerId)
    {
        messageType = MessageType.PLAYER_JOIN;
        this.playerId = playerId;
        this.LessonId = lessonId;
        this.Username = username;
    }
}
