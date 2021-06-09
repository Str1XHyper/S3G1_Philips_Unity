using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using WebSocketSharp;

public class SocketListener : MonoBehaviour
{
    private SocketConnection connection;

    private int joinMessages_Received = 0;

    private void Start()
    {
        connection = GetComponent<SocketConnection>();
    }

    public void OnMessage(object sender, MessageEventArgs e)
    {
        string json = e.Data;
        SocketResponse response = JsonUtility.FromJson<SocketResponse>(json);

        switch (response.responseType)
        {
            case ResponseType.START_GAME:
                HandleStartGame(JsonUtility.FromJson<StartGameResponse>(json));
                break;
            case ResponseType.START_TURN:
                HandleStartTurn(JsonUtility.FromJson<StartTurnResponse>(json));
                break;
            case ResponseType.MOVE_PLAYER:
                HandleMovePlayer(JsonUtility.FromJson<MovePlayerResponse>(json));
                break;
            case ResponseType.QUESTION:
                HandleQuestion(JsonUtility.FromJson<QuestionResponse>(json));
                break;
            case ResponseType.SCORE:
                HandleScore(JsonUtility.FromJson<Scores>(json));
                break;
            case ResponseType.PLAYER_JOIN:
                HandlePlayerJoin(JsonUtility.FromJson<PlayerJoinResponse>(json));
                break;
            case ResponseType.DIRECTION_CHOSEN:
                HandleDirectionChosenResponse(JsonUtility.FromJson<DirectionChosenResponse>(json));
                break;
            case ResponseType.END_GAME:
                HandleEndGame();
                break;
            default:
                break;
        }
    }

    private void HandleDirectionChosenResponse(DirectionChosenResponse directionChosenResponse)
    {
        PlayerGroup group = GroupsManager.instance.GetGroupByID(directionChosenResponse.playerId);
        
        bool noDirectionTile = true;
        ChooseDirectionTile tileToSet = null;

        while (noDirectionTile)
        {
            if (group.GroupPawn.PawnMover.CurrentSmartTile.GetType() == typeof(ChooseDirectionTile))
            {
                tileToSet = (ChooseDirectionTile)group.GroupPawn.PawnMover.CurrentSmartTile;
                tileToSet.SetChosenDirectionForServerPawn(group, directionChosenResponse.ChosenDirection);

                noDirectionTile = false;
            }
        }
    }

    private void HandleEndGame()
    {
       LeaderBoard.SaveLeaderboard();
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    private void HandlePlayerJoin(PlayerJoinResponse playerJoinResponse)
    {
        joinMessages_Received++;

        if (joinMessages_Received == 1 && playerJoinResponse.players.Length > 1)
        {
            UI_manager.instance.HideStartButton();
        }

        foreach (JsonPlayer player in playerJoinResponse.players)
        {
            GroupsManager.instance.CreateServerPlayer(player);
            Debug.Log(player.Username);
        }
    }

    private void HandleScore(Scores scoreResponse)
    {
        UnityThread.executeInLateUpdate(() => UI_manager.instance.UpdateText(scoreResponse));
    }

    private void HandleQuestion(QuestionResponse questionResponse)
    {
        QuestionManager.instance.AskQuestion(questionResponse.question);
    }

    private void HandleMovePlayer(MovePlayerResponse movePlayerResponse)
    {
        GroupsManager.instance.MovePlayer(movePlayerResponse.playerId, movePlayerResponse.movementAmount);
    }

    private void HandleStartTurn(StartTurnResponse startTurnResponse)
    {
        if (startTurnResponse.playerId == GroupsManager.instance.GetLocalPlayer().GroupPawn.PlayerID)
        {
            TurnManager.instance.StartNewTurn();
        }
    }

    private void HandleStartGame(StartGameResponse startGameResponse)
    {
        if (startGameResponse.playerId == GroupsManager.instance.GetLocalPlayer().GroupPawn.PlayerID)
        {
            TurnManager.instance.StartNewTurn();
        }
    }
}
