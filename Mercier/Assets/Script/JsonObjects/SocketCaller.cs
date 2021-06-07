using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCaller : MonoBehaviour
{
    #region SingleTon
    public static SocketCaller instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }


    }
    #endregion

    private SocketConnection connection;

    void Start()
    {
        connection = GetComponent<SocketConnection>();
    }

    private void SendJson(object objectToSerialize)
    {
        string json = JsonUtility.ToJson(objectToSerialize);

        connection.Send(json);
    }

    public void StartGame(StartGameMessage startGame)
    {
        SendJson(startGame);
    }

    public void DiceThrown(DiceThrowMessage diceThrow)
    {
        SendJson(diceThrow);
    }

    public void PlayerJoin(PlayerJoinMessage playerJoin)
    {
        GroupsManager.instance.GetLocalPlayer().GroupPawn.SetID(playerJoin.playerId);
       // GroupsManager.instance.PlayerGroupsInGame.Add(GroupsManager.instance.GetLocalPlayer());
        SendJson(playerJoin);
    }

    public void EncounterSpace(EncounteredSpaceMessage encounteredSpace)
    {
        SendJson(encounteredSpace);
    }

    public void AnsweredQuestion(AnsweredQuestionMessage answeredQuestion)
    {
        SendJson(answeredQuestion);
    }

    public void DirectionChosen(DirectionChosenMessage directionChosen)
    {
        SendJson(directionChosen);
    }

    public void PassedStart(PassedStartMessage passedStart)
    {
        SendJson(passedStart);
    }
    public void PassedBank(PassedBankMessage PassedBank)
    {
        SendJson(PassedBank);
    }

    public void BoughtStar(BoughtStarMessage boughtStar)
    {
        SendJson(boughtStar);
    }

    public void EndTurn(TurnEndMessage turnEnd)
    {
        SendJson(turnEnd);
    }

    public void StartGame()
    {
        SendJson(new StartGameMessage("0"));
    }
}
