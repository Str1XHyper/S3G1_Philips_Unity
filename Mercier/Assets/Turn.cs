﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Turn
{
    private TurnState currentTurnState;

    private int rolledNumber = 0;

    private bool alreadyMoved = false;

    private PlayerGroup currentPlayerGroup;

    public Turn(PlayerGroup currentPlayerGroup)
    {
        currentTurnState = TurnState.START;
        this.currentPlayerGroup = currentPlayerGroup;
    }

    public void Start()
    {
        currentTurnState = TurnState.MOVEMENT;
    }

    public void Movement()
    {
        if (!alreadyMoved)
        {
            RollDice();
            currentPlayerGroup.GroupPawn.MovePawn(rolledNumber);
            alreadyMoved = true;
        }

        if (currentPlayerGroup.GroupPawn.MovedSpaces >= rolledNumber && alreadyMoved)
        {
            currentTurnState = TurnState.ENCOUNTER_SPACE;
        }
    }

    public void EncounterSpace()
    {
        currentPlayerGroup.GroupPawn.CurrentSmartTile.HandleTile(currentPlayerGroup);
        currentTurnState = TurnState.END;
    }

    public void End()
    {
        
    }

    private void RollDice()
    {
        rolledNumber = DiceRoller.instance.GetRandomNumber();
    }

    public TurnState CurrentTurnState { get => currentTurnState; private set => currentTurnState = value; }
}
