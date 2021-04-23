using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class PassedStart : SocketMessage
{
    public PassedStart(int playerId) : base(playerId)
    {
        messageType = MessageType.PASSED_START;
    }
}
