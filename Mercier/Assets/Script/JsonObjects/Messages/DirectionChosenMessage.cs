using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DirectionChosenMessage : SocketMessage
{
    public MovementDirection direction;

    public DirectionChosenMessage(string playerId, MovementDirection direction) : base(playerId)
    {
        this.direction = direction;

        messageType = MessageType.DIRECTION_CHOSEN;
    }
}
