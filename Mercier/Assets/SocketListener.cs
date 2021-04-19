using System;
using System.Collections;
using UnityEngine;
using WebSocketSharp;

public class SocketListener : MonoBehaviour
{
    #region SingleTon
    public static SocketListener instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    private void Start()
    {
        StartCoroutine(ConnectAndTest());
    }

    private IEnumerator ConnectAndTest()
    {
        using (var ws = new WebSocketSharp.WebSocket("ws://localhost:4000/Mercier"))
        {
            ws.OnMessage += (sender, e) =>
                Debug.Log("Laputa says: " + e.Data);

            ws.Connect();
            ws.Send("Test");

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
