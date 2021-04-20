using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketConnection : MonoBehaviour
{
    private SocketListener socketListener;
    private SocketCaller socketCaller;

    private WebSocketSharp.WebSocket ws;

    private void Start()
    {
        socketListener = GetComponent<SocketListener>();
        socketCaller = GetComponent<SocketCaller>();

        StartCoroutine(ConnectAndTest());
    }

    public void Send(string message)
    {
        if (ws.IsAlive)
        {
            ws.Send(message);
        }
    }

    private IEnumerator ConnectAndTest()
    {
        using (ws = new WebSocketSharp.WebSocket("ws://localhost:4000/Mercier"))
        {
            ws.OnMessage += (sender, e) => socketListener.OnMessage(sender,e);

            ws.Connect();

            bool stop = false;
            while (!stop)
            {
                if (Input.GetKey(KeyCode.P))
                {
                    stop = true;
                }
                else
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }
    }
}
