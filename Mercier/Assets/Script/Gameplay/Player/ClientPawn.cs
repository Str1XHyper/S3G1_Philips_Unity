using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientPawn : Pawn
{
    private void Start()
    {
        StartCoroutine(ConnectToServer());
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSecondsRealtime(1f);
        string localPlayerId = Guid.NewGuid().ToString();
        playerID = localPlayerId;
        SocketCaller.instance.PlayerJoin(new PlayerJoinMessage(localPlayerId));
    }
}
