using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public abstract class SocketResponse
{
    public string playerId;
    public ResponseType responseType;

    protected SocketResponse(string playerId)
    {
        this.playerId = playerId;
    }
}
