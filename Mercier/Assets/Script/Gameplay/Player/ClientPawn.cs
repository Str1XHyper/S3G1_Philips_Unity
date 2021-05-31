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

        string localPlayerId = GetPlayerID();
        string lessonId = GetLessonID();
        SocketCaller.instance.PlayerJoin(new PlayerJoinMessage(localPlayerId, lessonId, "Piet"));
    }

    private string GetLessonID()
    {
        string data = GetData();
        string lessonId = "";

        if (string.IsNullOrEmpty(data))
        {
            lessonId = "ac04dcab-b025-45ff-b90a-d15b73759284";
        }
        else
        {
            string id = data.Split(',')[LessonSplitIndex];
            lessonId = id;
        }

        return lessonId;
    }

    private string GetPlayerID()
    {
        string data = GetData();
        string playerId = "";

        if (string.IsNullOrEmpty(data))
        {
            playerId = UnityEngine.Random.Range(1, 9999).ToString();
        }
        else
        {
            string id = data.Split(',')[PlayerIdSplitIndex];
            playerId = id;
        }

        return playerId;
    }

    private static string GetData()
    {
        string currentPageUrl = Application.absoluteURL;
        string data = "";

        if (!string.IsNullOrEmpty(currentPageUrl))
        {
            data = currentPageUrl.Split('?')[DataSplitIndex];
        }

        return data;
    }
}
