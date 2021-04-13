using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseDirectionTile : SmartTile
{
    private const float MaxWaitingTime = 5;

    [SerializeField] private SmartTile alternateNextTile;

    [SerializeField] private MovementDirection alternateDirection;
    [SerializeField] private MovementDirection defaultDirection;


    public override void HandlePassingTile(PlayerGroup currentPlayerGroup)
    {
        base.HandlePassingTile(currentPlayerGroup);
        ChooseDirection(currentPlayerGroup);
    }

    private void ChooseDirection(PlayerGroup currentPlayerGroup)
    {
        currentPlayerGroup.GroupPawn.ChoosingDirection = true;

        StartCoroutine(ChooseDirectionPrompt(currentPlayerGroup));

        Debug.Log("Choose " + defaultDirection + " or " + alternateDirection);
        UI_manager.instance.UpdateText();
    }

    private IEnumerator ChooseDirectionPrompt(PlayerGroup currentPlayerGroup)
    {
        float timePassed = 0;

        while (timePassed <= MaxWaitingTime)
        {
            if (DirectionPressed(defaultDirection))
            {
                MoveToNextTile = true;
                break;
            }
            else if (DirectionPressed(alternateDirection))
            {
                MoveToNextTile = false;
                break;
            }

            timePassed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        currentPlayerGroup.GroupPawn.ChoosingDirection = false;
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
