using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovePlayerResponse : SocketResponse
{
    public MovePlayerResponse(string playerId) : base(playerId)
    {
        responseType = ResponseType.MOVE_PLAYER;
    }
}
