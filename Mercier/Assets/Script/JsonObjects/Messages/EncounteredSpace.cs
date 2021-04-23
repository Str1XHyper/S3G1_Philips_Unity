﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class EncounteredSpace : SocketMessage
{
    public string spaceType;

    public EncounteredSpace(int playerId,string spaceType) : base(playerId)
    {
        this.spaceType = spaceType;
        messageType = MessageType.ENCOUNTERED_SPACE;
    }
}
