using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinResponse : SocketResponse
{
    public List<string> amountOfPlayers;

    protected PlayerJoinResponse(string playerId, List<string> amountOfPlayers) : base(playerId)
    {
        this.amountOfPlayers = amountOfPlayers;
        responseType = ResponseType.PLAYER_JOIN;
    }
}
