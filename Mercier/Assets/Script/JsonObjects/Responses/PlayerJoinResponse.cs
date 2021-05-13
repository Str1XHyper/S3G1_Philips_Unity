using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinResponse : SocketResponse
{
    public JsonPlayer[] players;
    
    protected PlayerJoinResponse(string playerId, JsonPlayer[] players) : base(playerId)
    {
        this.players = players;
        responseType = ResponseType.PLAYER_JOIN;
    }
}
