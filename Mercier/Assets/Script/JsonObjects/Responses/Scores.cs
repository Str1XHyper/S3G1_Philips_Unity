using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class Scores : SocketResponse
{
    public ScoreResponse[] scoreResponses;

    public Scores(string playerId, ScoreResponse[] scoreResponses) : base(playerId)
    {
        responseType = ResponseType.SCORE;
        this.scoreResponses = scoreResponses;
    }
}
