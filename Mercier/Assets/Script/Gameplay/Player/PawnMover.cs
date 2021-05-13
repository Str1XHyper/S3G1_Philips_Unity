using System.Collections;
using UnityEngine;

public class PawnMover : MonoBehaviour
{
    public const int AmountOfFramesToGetToNextSpace = 40;

    private SmartTile currentSmartTile;
    private Transform characterRotationTransform;

    private Pawn pawn;
    private PawnLerp pawnLerp;

    private bool isMoving = false;
    private bool doneMoving = false;
    private bool choosingDirection = false;
    private bool alreadyChoseADirection = false;

    private int currentAmountToMove = 0;
    private int amountAlreadyMoved = 0;

    private void Start()
    {
        pawn = GetComponent<Pawn>();
        pawnLerp = new PawnLerp(this);
        characterRotationTransform = GetComponentInChildren<AnimationPositionReseter>().transform;
    }

    private void FixedUpdate()
    {
        if (currentAmountToMove > 0)
        {
            if (!isMoving && !choosingDirection)
            {
                if (currentSmartTile.GetType() == typeof(ChooseDirectionTile) && amountAlreadyMoved == 0 && !alreadyChoseADirection)
                {
                    currentSmartTile.HandlePassingTile(GetComponent<PlayerGroup>());
                    alreadyChoseADirection = true;
                    return;
                }

                alreadyChoseADirection = false;

                currentAmountToMove--;
                MovePawnToNextSpace();
            }
        }
    }

    public void MovePawn(int amountToMove)
    {
        amountAlreadyMoved = 0;
        HandlePassingATile(currentSmartTile);
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

        StartCoroutine(pawnLerp.LerpPawnToNewPos(currentSmartTile.PawnPos, tileToMoveTo.PawnPos));

        currentSmartTile = tileToMoveTo;
    }

    private void HandlePassingATile(SmartTile tileToPass)
    {
        if (currentAmountToMove > 0)
        {
            tileToPass.HandlePassingTile(GetComponent<PlayerGroup>());
        }
    }

    public void CheckForLastTile()
    {
        if (currentAmountToMove <= 0)
        {
            currentAmountToMove = 0;
            doneMoving = true;
        }
    }

    public void MovePawnTransform(Vector3 posToMoveTo) => transform.position = posToMoveTo;
    public SmartTile CurrentSmartTile { get => currentSmartTile; private set => currentSmartTile = value; }
    public Pawn Pawn { get => pawn; private set => pawn = value; }
    public Transform CharacterRotationTransform { get => characterRotationTransform; private set => characterRotationTransform = value; }

    public int AmountAlreadyMoved { get => amountAlreadyMoved; set => amountAlreadyMoved = value; }
    public bool IsMoving { get => isMoving; set => isMoving = value; }
    public bool DoneMoving { get => doneMoving; set => doneMoving = value; }
    public bool ChoosingDirection { get => choosingDirection; set => choosingDirection = value; }
}