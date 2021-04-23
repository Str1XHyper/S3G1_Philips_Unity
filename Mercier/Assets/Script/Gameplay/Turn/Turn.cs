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
            currentPlayerGroup.GroupPawn.Animator.SetFloat("Forward",0.5f);
            RollDice();
            
            //Cheat code TODO: remove at final
            if (Input.GetKey(KeyCode.Alpha1))
                rolledNumber = 1;

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
        currentPlayerGroup.GroupPawn.Animator.SetFloat("Forward", 0);
        currentPlayerGroup.GroupPawn.CurrentSmartTile.HandleTile(currentPlayerGroup);

        currentTurnState = TurnState.END;
    }

    public void End()
    {
        SocketCaller.instance.EndTurn(new TurnEnd(currentPlayerGroup.GroupPawn.PlayerID));

        currentTurnState = TurnState.QUESTION;
    }

    private void RollDice()
    {
        rolledNumber = DiceRoller.instance.GetRandomNumber();
        SocketCaller.instance.DiceThrown(new DiceThrow(0, rolledNumber));
    }

    private EncounteredSpace GetNewEncounteredSpace(PlayerGroup playerGroup, SmartTile currentTile)
    {
        EncounteredSpace toReturn = new EncounteredSpace(playerGroup.GroupPawn.PlayerID, currentTile.TileType);
    }

    public TurnState CurrentTurnState { get => currentTurnState; private set => currentTurnState = value; }
}
