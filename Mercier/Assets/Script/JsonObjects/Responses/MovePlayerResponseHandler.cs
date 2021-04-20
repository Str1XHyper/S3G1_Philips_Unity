using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MovePlayerResponseHandler : ResponseHandler
{
    public override void HandleResponse(SocketResponse socketResponse)
    {
        base.HandleResponse(socketResponse);

        MovePlayerResponse movePlayerResponse = (MovePlayerResponse)socketResponse;


    }
}
