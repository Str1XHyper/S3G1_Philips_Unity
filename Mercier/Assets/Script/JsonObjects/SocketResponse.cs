using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public abstract class SocketResponse
{
    public string playerId;
    public string responseType;

    protected SocketResponse(string playerId, string responseType)
    {
        this.playerId = playerId;
        this.responseType = responseType;
    }
}
