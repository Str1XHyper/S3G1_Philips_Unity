using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PlayerJoinResponse : SocketResponse
{
    public int amountOfPlayers;

    protected PlayerJoinResponse(int playerId, int amountOfPlayers) : base(playerId)
    {
        this.amountOfPlayers = amountOfPlayers;
        responseType = ResponseType.PLAYER_JOIN;
    }
}
