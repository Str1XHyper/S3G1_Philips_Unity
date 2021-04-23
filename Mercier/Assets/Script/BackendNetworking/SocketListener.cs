using System;
using System.Collections;
using UnityEngine;
using WebSocketSharp;

public class SocketListener : MonoBehaviour
{
    private SocketConnection connection;

    private void Start()
    {
        connection = GetComponent<SocketConnection>();
    }

    public void OnMessage(object sender, MessageEventArgs e)
    {
        SocketResponse response = ConvertToSocketResponse(e.Data);

        switch (response.responseType)
        {
            case ResponseType.START_GAME:
                break;
            case ResponseType.START_TURN:
                break;
            case ResponseType.MOVE_PLAYER:
                break;
            case ResponseType.QUESTION:
                break;
            default:
                break;
        }
    }

    private SocketResponse ConvertToSocketResponse(string json)
    {
        return JsonUtility.FromJson<SocketResponse>(json);
    }
}
