using System;
using System.Collections;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private int amountOfFramesToGetToNextSpace;
    [SerializeField] private Animator animator;

    protected string playerID;

    private SmartTile currentSmartTile;
    private Transform characterRotationTransform;

    private bool isMoving = false;
    private bool doneMoving = false;
    private bool choosingDirection = false;
    private int currentAmountToMove = 0;
    private int amountAlreadyMoved = 0;

    private void Update()
    {
        if (currentAmountToMove > 0)
        {
            if (!isMoving && !choosingDirection)
            {
                currentAmountToMove--;
                MovePawnToNextSpace();
            }
        }
    }

    public void MovePawn(int amountToMove)
    {
        HandlePassingATile(currentSmartTile);
        amountAlreadyMoved = 0;
        currentAmountToMove = amountToMove;
    }

    public void MovePawnDirectlyToTile(SmartTile tileToMoveTo)
    {
        currentSmartTile = tileToMoveTo;
        MovePawnTransform(currentSmartTile.PawnPos);
    }

    private void MovePawnToNextSpace()
    {
        SmartTile tileToMoveTo = currentSmartTile.NextTile;

        tileToMoveTo = TileManager.instance.GetCorrectDirectionFromDirectionTile(currentSmartTile, tileToMoveTo);
        tileToMoveTo = TileManager.instance.CheckForAlternateDirectionPortalTile(currentSmartTile, tileToMoveTo);

        HandlePassingATile(tileToMoveTo);

        StartCoroutine(LerpPawnToNewPos(currentSmartTile.PawnPos, tileToMoveTo.PawnPos));

        currentSmartTile = tileToMoveTo;
    }

    private IEnumerator LerpPawnToNewPos(Vector3 oldPos, Vector3 newPos)
    {
        characterRotationTransform = GetComponentInChildren<AnimationPositionReseter>().transform;

        IsMoving = true;
        TurnManager.instance.CurrentPlayerGroup.GroupPawn.animator.SetFloat("Forward", 0.5f);

        for (int elapsedFrames = 0; elapsedFrames < amountOfFramesToGetToNextSpace; elapsedFrames++)
        {
            MovePawnToNextLerpPos(oldPos, newPos, elapsedFrames);

            yield return new WaitForFixedUpdate();
        }

        CheckForLastTile();

        MovePawnTransform(newPos);

        IsMoving = false;
        amountAlreadyMoved++;
    }

    private void HandlePassingATile(SmartTile tileToPass)
    {
        if (currentAmountToMove > 0)
        {
            tileToPass.HandlePassingTile(TurnManager.instance.CurrentPlayerGroup);
        }
    }

    private void CheckForLastTile()
    {
        if (currentAmountToMove <= 0)
        {
            currentAmountToMove = 0;
            doneMoving = true;
        }
    }

    private void MovePawnToNextLerpPos(Vector3 oldPos, Vector3 newPos, int elapsedFrames)
    {
        float interpolairRatio = (float)elapsedFrames / (float)amountOfFramesToGetToNextSpace;
        Vector3 nextLerpedPos = Vector3.Lerp(oldPos, newPos, interpolairRatio);
        MovePawnTransform(nextLerpedPos);

        characterRotationTransform.LookAt(newPos);
    }

    private void MovePawnTransform(Vector3 posToMoveTo) { transform.position = posToMoveTo; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public SmartTile CurrentSmartTile { get => currentSmartTile; private set => currentSmartTile = value; }
    public bool ChoosingDirection { get => choosingDirection; set => choosingDirection = value; }
    public string PlayerID { get => playerID; }
    public Animator Animator { get => animator; private set => animator = value; }
    public int CurrentAmountToMove { get => currentAmountToMove; }
    public bool DoneMoving { get => doneMoving; set => doneMoving = value; }
    public int AmountAlreadyMoved { get => amountAlreadyMoved; }
}