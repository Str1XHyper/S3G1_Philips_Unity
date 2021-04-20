using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PassedBank : SocketMessage
{
    public PassedBank(int playerId) : base(playerId)
    {
        messageType = MessageType.PASSED_BANK;
    }
}
