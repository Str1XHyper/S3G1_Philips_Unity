using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinResponse : SocketResponse
{
    public List<JsonPlayer> players;
    
    protected PlayerJoinResponse(string playerId, List<JsonPlayer> players) : base(playerId)
    {
        this.players = players;
        responseType = ResponseType.PLAYER_JOIN;
    }
}
