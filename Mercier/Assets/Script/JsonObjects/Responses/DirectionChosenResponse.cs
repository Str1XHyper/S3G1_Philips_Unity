using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DirectionChosenResponse : SocketResponse
{
    public MovementDirection ChosenDirection;

    public DirectionChosenResponse(string playerId, MovementDirection chosenDirection) : base(playerId)
    {
        responseType = ResponseType.DIRECTION_CHOSEN;
        ChosenDirection = chosenDirection;
    }
}
