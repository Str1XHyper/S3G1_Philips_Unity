using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    #region SingleTon
    public static TurnManager instance;

    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }

    #endregion

    private Turn currentTurn;

    private int currentGroupIndex = 0;

    private TurnState lastState = TurnState.START;

    public void StartNewTurn()
    {
        currentTurn = new Turn(GroupsManager.instance.GetLocalPlayer());
    }

    private void Start()
    {
        StarPlacer.instance.PlaceStarOnBoard();
        CurrentPlayerGroup.GroupPawn.MovePawnDirectlyToTile(TileManager.instance.GetStartTile());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentTurn.CurrentTurnState == TurnState.AWAITING_START)
        {
            currentTurn.StartTurn();
            //StartNewTurn();
        }

        if (currentTurn != null)
        {
            switch (currentTurn.CurrentTurnState)
            {
                case TurnState.START:
                    Debug.Log(currentTurn.CurrentTurnState);
                    currentTurn.Start();
                    break;
                case TurnState.MOVEMENT:
                    currentTurn.Movement();
                    break;
                case TurnState.ENCOUNTER_SPACE:
                    currentTurn.EncounterSpace();
                    break;
                case TurnState.END:
                    //Send dingie to server to make it known that you've ended your turn
                    currentTurn.End();
                    EndOfTurn();
                    break;
                case TurnState.QUESTION:
                    //CameraManager.instance.ChangeCameraTarget( INSERT TARGET HERE );
                    break;
                case TurnState.AWAITING_START:
                    
                    break;
                default:
                    break;
            }

            if (currentTurn.CurrentTurnState != lastState)
            {
                lastState = currentTurn.CurrentTurnState;
                Debug.Log(lastState);
            }

            UI_manager.instance.UpdateText();
        }
    }

    private void EndOfTurn()
    {
        currentGroupIndex++;

        if (currentGroupIndex >= GroupsManager.instance.PlayerGroupsInGame.Count)
        {
            currentGroupIndex = 0;
            EndOfRound();
        }

        //StartNewTurn();
    }

    private void EndOfRound()
    {
        AskQuestion();
    }

    private void AskQuestion()
    {
        QuestionManager.instance.AskQuestion();
    }

    public PlayerGroup CurrentPlayerGroup { get => GroupsManager.instance.PlayerGroupsInGame[currentGroupIndex]; }
}
