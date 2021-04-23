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

    public void DiceThrown(DiceThrow diceThrow)
    {
        SendJson(diceThrow);
    }

    public void EncounterSpace(EncounteredSpace encounteredSpace)
    {
        SendJson(encounteredSpace);
    }

    public void AnsweredQuestion(AnsweredQuestion answeredQuestion)
    {
        SendJson(answeredQuestion);
    }

    public void DirectionChosen(DirectionChosen directionChosen)
    {
        SendJson(directionChosen);
    }

    public void PassedStart(PassedStart passedStart)
    {
        SendJson(passedStart);
    }
    public void PassedBank(PassedBank PassedBank)
    {
        SendJson(PassedBank);
    }

    public void BoughtStar(BoughtStar boughtStar)
    {
        SendJson(boughtStar);
    }

    public void EndTurn(TurnEnd turnEnd)
    {
        SendJson(turnEnd);
    }
}
