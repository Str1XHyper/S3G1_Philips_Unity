using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class EncounteredSpaceMessage : SocketMessage
{
    public SpaceType spaceType;

    public EncounteredSpaceMessage(string playerId, SpaceType spaceType) : base(playerId)
    {
        this.spaceType = spaceType;
        messageType = MessageType.ENCOUNTERED_SPACE;
    }
}
