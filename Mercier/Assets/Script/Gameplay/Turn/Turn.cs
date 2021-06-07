using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Turn
{
    private TurnState currentTurnState;

    private int rolledNumber = 0;

    private bool alreadyStartedMoved = false;

    private PlayerGroup currentPlayerGroup;

    public Turn(PlayerGroup currentPlayerGroup)
    {
        //currentTurnState = TurnState.AWAITING_START;
        currentTurnState = TurnState.START;
        this.currentPlayerGroup = currentPlayerGroup;
    }

    public void Start()
    {
        currentTurnState = TurnState.MOVEMENT;
    }

    public void StartTurn()
    {
        currentTurnState = TurnState.START;
    }

    public void Movement()
    {
        if (!alreadyStartedMoved)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RollDice();
                alreadyStartedMoved = true;
            }
        }

        if (currentPlayerGroup.GroupPawn.PawnMover != null)
        {
            if (currentPlayerGroup.GroupPawn.PawnMover.DoneMoving && alreadyStartedMoved)
            {
                currentPlayerGroup.GroupPawn.PawnMover.DoneMoving = false;
                currentTurnState = TurnState.ENCOUNTER_SPACE;
            }
        }
    }

    public void EncounterSpace()
    {
        SmartTile currentTile = currentPlayerGroup.GroupPawn.PawnMover.CurrentSmartTile;
        currentPlayerGroup.GroupPawn.Animator.SetFloat("Forward", 0);
        currentTile.HandleTile(currentPlayerGroup);

        SocketCaller.instance.EncounterSpace(new EncounteredSpaceMessage(currentPlayerGroup.GroupPawn.PlayerID, currentTile.TileType));

        UI_manager.instance.UpdateText();

        currentTurnState = TurnState.END;
    }

    public void End()
    {
        SocketCaller.instance.EndTurn(new TurnEndMessage(currentPlayerGroup.GroupPawn.PlayerID, 1));

        currentTurnState = TurnState.QUESTION;
    }

    private void RollDice()
    {
        rolledNumber = DiceRoller.instance.GetRandomNumber();

        //Cheat code TODO: remove at final
        if (Input.GetKey(KeyCode.Alpha1))
            rolledNumber = 1; 
        
        SocketCaller.instance.DiceThrown(new DiceThrowMessage(currentPlayerGroup.GroupPawn.PlayerID, rolledNumber));
    }

    public TurnState CurrentTurnState { get => currentTurnState; private set => currentTurnState = value; }
}
