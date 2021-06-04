using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartGameMessage : SocketMessage
{
    public StartGameMessage(string playerId) : base(playerId)
    {
        messageType = MessageType.START_GAME;
    }
}