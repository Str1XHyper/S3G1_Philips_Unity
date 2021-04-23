using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DirectionChosen : SocketMessage
{
    public MovementDirection direction;

    public DirectionChosen(int playerId, MovementDirection direction) : base(playerId)
    {
        this.direction = direction;

        messageType = MessageType.DIRECTION_CHOSEN;
    }
}
