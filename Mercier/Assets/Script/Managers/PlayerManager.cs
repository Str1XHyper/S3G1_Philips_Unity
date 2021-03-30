using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region SingleTon
    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    List<Player> playersInGame = new List<Player>();

    private void Start()
    {
        
    }
}
