using System;
using System.Collections;
using UnityEngine;
using WebSocketSharp;

public class SocketListener : MonoBehaviour
{
    private SocketConnection connection;

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
                HandleScore(JsonUtility.FromJson<ScoreResponse>(json));
                break;
            case ResponseType.PLAYER_JOIN:
                HandlePlayerJoin(JsonUtility.FromJson<PlayerJoinResponse>(json));
                break;
            case ResponseType.DIRECTION_CHOSEN:
                HandleDirectionChosenResponse(JsonUtility.FromJson<DirectionChosenResponse>(json));
                break;
            default:
                break;
        }
    }

    private void HandleDirectionChosenResponse(DirectionChosenResponse directionChosenResponse)
    {
        throw new NotImplementedException();
    }

    private void HandlePlayerJoin(PlayerJoinResponse playerJoinResponse)
    {
        GroupsManager.instance.CreatePlayer(playerJoinResponse.playerId);
    }

    private void HandleScore(ScoreResponse scoreResponse)
    {
        UI_manager.instance.UpdateText(scoreResponse);
    }

    private void HandleQuestion(QuestionResponse questionResponse)
    {
        
    }

    private void HandleMovePlayer(MovePlayerResponse movePlayerResponse)
    {
        throw new NotImplementedException();
    }

    private void HandleStartTurn(StartTurnResponse startTurnResponse)
    {
        throw new NotImplementedException();
    }

    private void HandleStartGame(StartGameResponse startGameResponse)
    {
        throw new NotImplementedException();
    }
}
