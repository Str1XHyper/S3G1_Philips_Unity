using System;
using System.Collections;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private int amountOfFramesToGetToNextSpace;
    [SerializeField] private Animator animator;

    protected int playerID;

    private SmartTile currentSmartTile;

    private int movedSpaces = 0;
    private bool isMoving = false;
    private bool choosingDirection = false;

    Transform characterRotationTransform;

    private void Start()
    {
        //Call komen voor id
        SocketCaller.instance.DiceThrown(new DiceThrow(0, "100"));
    }

    public void MovePawn(int amountToMove)
    {
        StartCoroutine(MovePawnMultipleSpaces(amountToMove));
    }

    public void MovePawnToTile(SmartTile tileToMoveTo)
    {
        currentSmartTile = tileToMoveTo;
        MovePawnTransform(currentSmartTile.PawnPos);
    }

    private void MovePawnToNextSpace()
    {
        SmartTile tileToMoveTo = currentSmartTile.NextTile;

        tileToMoveTo = CheckDirectionTile(tileToMoveTo);
        tileToMoveTo = CheckPortalTile(tileToMoveTo);

        StartCoroutine(LerpPawnToNewPos(currentSmartTile.PawnPos, tileToMoveTo.PawnPos));

        currentSmartTile = tileToMoveTo;
    }

    private SmartTile CheckPortalTile(SmartTile tileToMoveTo)
    {
        if (currentSmartTile.GetType() == typeof(PortalTile))
        {
            if (!currentSmartTile.MoveToNextTile)
            {
                PortalTile portalTile = (PortalTile)currentSmartTile;
                tileToMoveTo = portalTile.AlternateNextTile;
                currentSmartTile.MoveToNextTile = true;
            }
        }

        return tileToMoveTo;
    }

    private SmartTile CheckDirectionTile(SmartTile tileToMoveTo)
    {
        if (currentSmartTile.GetType() == typeof(ChooseDirectionTile))
        {
            ChooseDirectionTile directionTile = (ChooseDirectionTile)currentSmartTile;

            if (currentSmartTile.MoveToNextTile)
            {
                tileToMoveTo = directionTile.AlternateNextTile;
            }
        }

        return tileToMoveTo;
    }

    private IEnumerator LerpPawnToNewPos(Vector3 oldPos, Vector3 newPos)
    {
        characterRotationTransform = GetComponentInChildren<AnimationPositionReseter>().transform;

        IsMoving = true;

        for (int elapsedFrames = 0; elapsedFrames < amountOfFramesToGetToNextSpace; elapsedFrames++)
        {
            float interpolairRatio = (float)elapsedFrames / (float)amountOfFramesToGetToNextSpace;
            Vector3 nextLerpedPos = Vector3.Lerp(oldPos, newPos, interpolairRatio);
            MovePawnTransform(nextLerpedPos);

            characterRotationTransform.LookAt(newPos);

            yield return new WaitForFixedUpdate();
        }

        MovePawnTransform(newPos);
        movedSpaces++;
        IsMoving = false;
    }

    private void HandlePassingOfTile()
    {
        currentSmartTile.HandlePassingTile(TurnManager.instance.CurrentPlayerGroup);
    }

    private IEnumerator MovePawnMultipleSpaces(int amountOfSpaces)
    {
        movedSpaces = 0;

        HandlePassingOfTile();

        while (movedSpaces < amountOfSpaces)
        {
            if (!IsMoving && !choosingDirection)
            {
                MovePawnToNextSpace();

                if (movedSpaces < amountOfSpaces)
                    HandlePassingOfTile();
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private void MovePawnTransform(Vector3 posToMoveTo) { transform.position = posToMoveTo; }

    public int MovedSpaces { get => movedSpaces; private set => movedSpaces = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public SmartTile CurrentSmartTile { get => currentSmartTile; private set => currentSmartTile = value; }
    public bool ChoosingDirection { get => choosingDirection; set => choosingDirection = value; }
    public int PlayerID { get => playerID; }
    public Animator Animator { get => animator; private set => animator = value; }
}