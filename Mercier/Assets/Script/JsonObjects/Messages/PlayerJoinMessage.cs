using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinMessage : SocketMessage
{
    public PlayerJoinMessage(int playerId) : base(playerId)
    {
        messageType = MessageType.PLAYER_JOIN;
        this.playerId = -1;
    }
}
