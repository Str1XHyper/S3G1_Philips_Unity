using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EndGameResponse : SocketResponse
{
    public EndGameResponse(string playerId) : base(playerId)
    {
        responseType = ResponseType.END_GAME;
    }
}
