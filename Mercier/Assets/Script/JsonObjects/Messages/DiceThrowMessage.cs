using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DiceThrowMessage : SocketMessage
{
    public int rolledNumber;
    
    public DiceThrowMessage(int playerId, int rolledNumber) : base(playerId)
    {
        messageType = MessageType.DICE_THROW;
        this.rolledNumber = rolledNumber;
    }
}
