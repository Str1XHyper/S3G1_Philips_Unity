using System;
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

    [SerializeField] private GameObject serverPlayerGroupPrefab;

    [SerializeField] private List<PlayerGroup> playerGroupsInGame = new List<PlayerGroup>();

    private List<JsonPlayer> playersToSpawn = new List<JsonPlayer>();
    private bool canSpawn = true;

    private void Update()
    {
        if (playersToSpawn.Count > 0)
        {
            JsonPlayer playerToSpawn = playersToSpawn[0];

            if (!ContainsID(playerToSpawn.PlayerID))
            {
                canSpawn = false;

                GameObject newPlayerGroup = Instantiate(serverPlayerGroupPrefab);

                ServerPawn serverPawn = newPlayerGroup.GetComponent<ServerPawn>();

                serverPawn.Init();
                serverPawn.SetID(playerToSpawn.PlayerID);
                serverPawn.SetUserName(playerToSpawn.Username);
                serverPawn.MovePawnDirectlyToTile(TileManager.instance.GetStartTile());

                PlayerGroupsInGame.Add(newPlayerGroup.GetComponent<PlayerGroup>());
                playersToSpawn.RemoveAt(0);
                canSpawn = true;
            }
        }
    }

    public void MovePlayer(string id, int amountToMove)
    {
        PlayerGroup groupToMove = GetGroupByID(id);

        if (groupToMove != null)
        {
            groupToMove.GroupPawn.MovePawn(amountToMove);
        }
    }

    public PlayerGroup GetLocalPlayer()
    {
        foreach (PlayerGroup playerGroup in playerGroupsInGame)
        {
            if (typeof(ClientPawn) == playerGroup.GroupPawn.GetType())
            {
                return playerGroup;
            }
        }

        return null;
    }

    public void CreateServerPlayer(JsonPlayer player)
    {
        if (!ContainsID(player.PlayerID))
        {
            if (GetLocalPlayer().GroupPawn.PlayerID != player.PlayerID)
            {
                playersToSpawn.Add(player);
            }
        }
    }

    public PlayerGroup GetGroupByID(string id)
    {
        foreach (PlayerGroup playerGroup in playerGroupsInGame)
        {
            if (playerGroup.GroupPawn.PlayerID == id)
            {
                return playerGroup;
            }
        }

        return null;
    }

    private bool ContainsID(string id)
    {
        foreach (PlayerGroup playerGroup in playerGroupsInGame)
        {
            if (playerGroup.GroupPawn.PlayerID == id)
            {
                return true;
            }
        }

        return false;
    }

    public List<PlayerGroup> PlayerGroupsInGame { get => playerGroupsInGame; private set => playerGroupsInGame = value; }
}
