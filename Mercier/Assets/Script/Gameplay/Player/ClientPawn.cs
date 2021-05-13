using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientPawn : Pawn
{
    private const int DataSplitIndex = 1;
    private const int LessonSplitIndex = 1;
    private const int PlayerIdSplitIndex = 0;

    private const float AwaitBeforeConnection = 1f;

    private void Start()
    {
        StartCoroutine(ConnectToServer());
    }

    IEnumerator ConnectToServer()
    {
        yield return new WaitForSecondsRealtime(AwaitBeforeConnection);
        //string localPlayerId = GetPlayerID();
        //string lessonId = GetLessonID();
        //SocketCaller.instance.PlayerJoin(new PlayerJoinMessage(localPlayerId, lessonId, "Piet"));
        SocketCaller.instance.PlayerJoin(new PlayerJoinMessage("", "", "Piet"));
    }

    private string GetLessonID()
    {
        string data = GetData();
        string id = data.Split(',')[LessonSplitIndex];
        string lessonId = "";

        lessonId = id;

        return lessonId;
    }

    private string GetPlayerID()
    {
        string data = GetData();
        string id = data.Split(',')[PlayerIdSplitIndex];
        string playerId = "";

        playerId = id;

        return playerId;
    }

    private static string GetData()
    {
        string currentPageUrl = Application.absoluteURL;
        string data = currentPageUrl.Split('?')[DataSplitIndex];
        return data;
    }
}
