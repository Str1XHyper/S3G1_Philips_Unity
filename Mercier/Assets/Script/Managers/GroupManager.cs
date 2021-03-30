using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    #region SingleTon
    public static GroupManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
    #endregion

    private List<PlayerGroup> tiles = new List<PlayerGroup>();

    private void Start()
    {
    }
}
