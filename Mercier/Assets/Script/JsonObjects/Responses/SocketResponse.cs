using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class SocketResponse
{
    public int playerId;
    public ResponseType responseType;

    protected SocketResponse(int playerId)
    {
        this.playerId = playerId;
    }
}
