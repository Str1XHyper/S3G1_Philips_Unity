using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovePlayerResponse : SocketResponse
{
    public int movementAmount;

    public MovePlayerResponse(string playerId, int movementAmount) : base(playerId)
    {
        responseType = ResponseType.MOVE_PLAYER;
        this.movementAmount = movementAmount;
    }
}
