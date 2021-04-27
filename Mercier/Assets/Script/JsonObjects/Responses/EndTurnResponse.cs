using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EndTurnResponse : SocketResponse
{
    public int currentTileIndex;

    protected EndTurnResponse(string playerId, int currentTileIndex) : base(playerId)
    {
        this.currentTileIndex = currentTileIndex;
        responseType = ResponseType.TURN_END;
    }
}
