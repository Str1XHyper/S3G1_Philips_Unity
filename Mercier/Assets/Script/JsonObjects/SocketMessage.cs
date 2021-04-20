using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public abstract class SocketMessage
{
    public int playerId;
    public MessageType messageType;

    protected SocketMessage(int playerId)
    {
        this.playerId = playerId;
    }
}
