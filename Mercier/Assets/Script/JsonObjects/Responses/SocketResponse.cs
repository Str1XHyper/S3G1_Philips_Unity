using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class SocketResponse
{
    public string playerId;
    public ResponseType responseType;

    protected SocketResponse(string playerId)
    {
        this.playerId = playerId;
    }
}
