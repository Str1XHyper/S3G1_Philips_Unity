using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartGameResponse : SocketResponse
{
    public StartGameResponse(int playerId) : base(playerId)
    {
        responseType = ResponseType.START_GAME;
    }
}
