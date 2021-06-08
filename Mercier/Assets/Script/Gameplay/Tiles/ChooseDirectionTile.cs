using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDirectionTile : SmartTile
{
    private const float MaxWaitingTime = 5;

    [SerializeField] private SmartTile alternateNextTile;

    [SerializeField] private MovementDirection alternateDirection;
    [SerializeField] private MovementDirection defaultDirection;

    new private void Start()
    {
        base.Start();

        TileType = SpaceType.CHOOSE_DIRECTION;
    }

    public override void HandlePassingTile(PlayerGroup currentPlayerGroup)
    {
        base.HandlePassingTile(currentPlayerGroup);
        ChooseDirection(currentPlayerGroup);
    }

    public void SetChosenDirectionForServerPawn(PlayerGroup currentPlayerGroup, MovementDirection chosenDirection)
    {
        MovementDirection currentChosenDirection = MovementDirection.DOWN;

        if (chosenDirection == alternateDirection)
        {
            MoveToNextTile = false;
            currentChosenDirection = alternateDirection;
        }
        else
        {
            MoveToNextTile = true;
            currentChosenDirection = defaultDirection;
        }

        currentPlayerGroup.GroupPawn.PawnMover.ChoosingDirection = false;
    }

    public void SetChosenDirectionLocalPlayer(PlayerGroup currentPlayerGroup, MovementDirection chosenDirection)
    {
        if (GroupsManager.instance.GetLocalPlayer().GroupPawn.PlayerID == currentPlayerGroup.GroupPawn.PlayerID)
        {
            ArrowManager.instance.HideAllArrows();
            SocketCaller.instance.DirectionChosen(new DirectionChosenMessage(currentPlayerGroup.GroupPawn.PlayerID, chosenDirection));
        }
    }

    private void ChooseDirection(PlayerGroup currentPlayerGroup)
    {
        currentPlayerGroup.GroupPawn.PawnMover.ChoosingDirection = true;

        if (GroupsManager.instance.GetLocalPlayer().GroupPawn.PlayerID == currentPlayerGroup.GroupPawn.PlayerID)
        {
            ArrowManager.instance.ShowArrows(defaultDirection, alternateDirection);
            StartCoroutine(ChooseDirectionPrompt(currentPlayerGroup));
        }

        Debug.Log("Choose " + defaultDirection + " or " + alternateDirection);

        UI_manager.instance.UpdateText();
    }

    private IEnumerator ChooseDirectionPrompt(PlayerGroup currentPlayerGroup)
    {
        float timePassed = 0;
        bool directionIsChosen = false;

        while (timePassed <= MaxWaitingTime)
        {
            if (DirectionPressed(defaultDirection))
            {
                SetChosenDirectionLocalPlayer(currentPlayerGroup, defaultDirection);
                directionIsChosen = true;
                break;
            }
            else if (DirectionPressed(alternateDirection))
            {
                SetChosenDirectionLocalPlayer(currentPlayerGroup, alternateDirection);
                directionIsChosen = true; 
                break;
            }

            timePassed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        if (!directionIsChosen)
        {
            ChooseRandomDirection(currentPlayerGroup);
        }
    }

    private void ChooseRandomDirection(PlayerGroup currentPlayerGroup)
    {
        if (Random.Range(0, 2) == 1)
        {
            SocketCaller.instance.DirectionChosen(new DirectionChosenMessage(currentPlayerGroup.GroupPawn.PlayerID, defaultDirection));
            SetChosenDirectionLocalPlayer(currentPlayerGroup, defaultDirection);
        }
        else
        {
            SocketCaller.instance.DirectionChosen(new DirectionChosenMessage(currentPlayerGroup.GroupPawn.PlayerID, alternateDirection));
            SetChosenDirectionLocalPlayer(currentPlayerGroup, alternateDirection);
        }
    }

    private bool DirectionPressed(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.LEFT:
                return Input.GetKey(KeyCode.LeftArrow);
            case MovementDirection.RIGHT:
                return Input.GetKey(KeyCode.RightArrow);
            case MovementDirection.UP:
                return Input.GetKey(KeyCode.UpArrow);
            case MovementDirection.DOWN:
                return Input.GetKey(KeyCode.DownArrow);
            default:
                return false;
        }
    }

    public SmartTile AlternateNextTile { get => alternateNextTile; private set => alternateNextTile = value; }
}
