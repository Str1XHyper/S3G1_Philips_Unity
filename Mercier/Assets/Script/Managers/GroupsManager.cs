using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupsManager : MonoBehaviour
{
    #region SingleTon
    public static GroupsManager instance;

    private void Awake()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private List<PlayerGroup> playerGroupsInGame = new List<PlayerGroup>();

    public List<PlayerGroup> PlayerGroupsInGame { get => playerGroupsInGame; private set => playerGroupsInGame = value; }
}
