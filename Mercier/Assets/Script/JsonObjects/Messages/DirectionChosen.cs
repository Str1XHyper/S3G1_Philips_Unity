using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class DirectionChosen : SocketMessage
{
    public MovementDirection direction;

    protected DirectionChosen(int playerId, MovementDirection direction) : base(playerId)
    {
        this.direction = direction;

        messageType = MessageType.DIRECTION_CHOSEN;
    }
}
