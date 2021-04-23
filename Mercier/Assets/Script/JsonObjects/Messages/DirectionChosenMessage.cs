using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DirectionChosenMessage : SocketMessage
{
    public MovementDirection direction;

    public DirectionChosenMessage(int playerId, MovementDirection direction) : base(playerId)
    {
        this.direction = direction;

        messageType = MessageType.DIRECTION_CHOSEN;
    }
}
