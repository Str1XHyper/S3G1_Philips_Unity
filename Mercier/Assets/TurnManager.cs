using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    private List<PlayerGroup> GroupsInGame = new List<PlayerGroup>();

    private int currentGroupIndex = 0;
    private int currentTurnCount = 0;

    private void Start()
    {
        
    }

    public void GoToNextTurn()
    {
        currentTurnCount++;

        SetNextGroup();
    }

    public PlayerGroup GetCurrentPlayerGroup()
    {
        return GroupsInGame[currentGroupIndex];
    }
        
    private void SetNextGroup()
    {
        currentGroupIndex++;

        if (currentGroupIndex > GroupsInGame.Count)
        {
            currentGroupIndex = 0;

            QuestionManager.instance.AskQuestion();
        }
    }
}
