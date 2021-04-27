using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinResponse : SocketResponse
{
    public List<string> players;

    protected PlayerJoinResponse(string playerId, List<string> players) : base(playerId)
    {
        this.players = players;
        responseType = ResponseType.PLAYER_JOIN;
    }
}
