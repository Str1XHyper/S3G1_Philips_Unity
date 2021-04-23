using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DiceThrow : SocketMessage
{
    public string rolledNumber;
    
    public DiceThrow(int playerId, string rolledNumber) : base(playerId)
    {
        messageType = MessageType.DICE_THROW;
        this.rolledNumber = rolledNumber;
    }
}
