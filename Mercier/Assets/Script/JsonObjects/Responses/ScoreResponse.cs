using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class ScoreResponse
{
    public int Points;
    public int Stars;
    public string PlayerID;
    public string Username;

    public ScoreResponse(string playerId, int amountOfStars, int amountOfPoints, string username)
    {
        this.Points = amountOfPoints;
        this.Stars = amountOfStars;
        this.PlayerID = playerId;
        this.Username = username;
    }
}
