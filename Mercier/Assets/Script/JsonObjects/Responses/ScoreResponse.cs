using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ScoreResponse : SocketResponse
{
    public int Stars;
    public int Points;

    protected ScoreResponse(string playerId, int amountOfStars, int amountOfPoints) : base(playerId)
    {
        responseType = ResponseType.SCORE;
        this.Points = amountOfPoints;
        this.Stars = amountOfStars;
    }
}
