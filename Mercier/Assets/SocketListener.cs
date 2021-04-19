using System;
using UnityEngine;

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
        Uri uri = new Uri("ws://localhost:4000/Mercier");


        WebSocket websok = new WebSocket(uri);

        websok.Connect();

        websok.SendString("Test");
    }
}
