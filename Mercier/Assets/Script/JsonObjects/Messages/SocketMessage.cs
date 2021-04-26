using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public abstract class SocketMessage
{
    public string playerId;
    public MessageType messageType;

    protected SocketMessage(string playerId)
    {
        this.playerId = playerId;
    }
}
