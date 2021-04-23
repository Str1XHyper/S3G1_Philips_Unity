using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PassedBankMessage : SocketMessage
{
    public PassedBankMessage(int playerId) : base(playerId)
    {
        messageType = MessageType.PASSED_BANK;
    }
}
