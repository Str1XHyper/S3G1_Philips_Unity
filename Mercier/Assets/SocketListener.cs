using UnityEngine;
using UnityEngine.Networking.PlayerConnection;

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
        WebSocket websok = new WebSocket("ws://localhost:4000");

        websok.OnMessage += (sender, e) => OnMessage(sender, e);

        websok.Connect();

    }

    public void OnMessage(object sender, MessageEventArgs e )
    {
        Debug.Log(e.Data);
    }
}
