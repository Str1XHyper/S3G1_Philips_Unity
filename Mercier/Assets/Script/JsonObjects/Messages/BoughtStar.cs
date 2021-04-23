using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BoughtStar : SocketMessage
{
    public BoughtStar(int playerId) : base(playerId)
    {
        messageType = MessageType.BOUGHT_STAR;
    }
}
