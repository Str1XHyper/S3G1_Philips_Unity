using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class TurnEndMessage : SocketMessage
{
    public int currentTileIndex;

    public TurnEndMessage(string playerId, int currentTileIndex) : base(playerId)
    {
        this.currentTileIndex = currentTileIndex;
        messageType = MessageType.TURN_END;
    }
}
