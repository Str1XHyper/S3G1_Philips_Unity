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

    private JsonPlayer player;
    private bool spawnPlayer = false;

    private void Update()
    {
        if (spawnPlayer)
        {
            spawnPlayer = false;

            GameObject newPlayerGroup = Instantiate(serverPlayerGroupPrefab);

            ServerPawn serverPawn = newPlayerGroup.GetComponent<ServerPawn>();

            serverPawn.SetID(player.PlayerID);
            serverPawn.SetUserName(player.Username);
            serverPawn.MovePawnDirectlyToTile(TileManager.instance.GetStartTile());

            PlayerGroupsInGame.Add(newPlayerGroup.GetComponent<PlayerGroup>());
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

    public void CreatePlayer(JsonPlayer player)
    {
        if (!ContainsID(player.PlayerID))
        {
            if (GetLocalPlayer().GroupPawn.PlayerID != player.PlayerID)
            {
                this.player = player;
                spawnPlayer = true;
            }
            else
            {
                GetLocalPlayer().GroupPawn.SetUserName(player.Username);
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
