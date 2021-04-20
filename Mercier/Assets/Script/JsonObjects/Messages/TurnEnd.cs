using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class TurnEnd : SocketMessage
{
    public TurnEnd(int playerId) : base(playerId)
    {
        messageType = MessageType.TURN_END;
    }
}
