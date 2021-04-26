using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class PassedStartMessage : SocketMessage
{
    public PassedStartMessage(string playerId) : base(playerId)
    {
        messageType = MessageType.PASSED_START;
    }
}
