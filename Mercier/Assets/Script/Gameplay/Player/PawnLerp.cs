using System.Collections;
using UnityEngine;

public class PawnLerp
{
    private PawnMover pawnMover;

    public IEnumerator LerpPawnToNewPos(Vector3 oldPos, Vector3 newPos)
    {
        pawnMover.IsMoving = true;
        pawnMover.Pawn.Animator.SetFloat("Forward", 0.5f);

        for (int elapsedFrames = 0; elapsedFrames < PawnMover.AmountOfFramesToGetToNextSpace; elapsedFrames++)
        {
            MovePawnToNextLerpPos(oldPos, newPos, elapsedFrames);

            yield return new WaitForFixedUpdate();
        }

        pawnMover.CheckForLastTile();

        pawnMover.MovePawnTransform(newPos);

        pawnMover.IsMoving = false;
        pawnMover.AmountAlreadyMoved++;
    }

    public void MovePawnToNextLerpPos(Vector3 oldPos, Vector3 newPos, int elapsedFrames)
    {
        float interpolairRatio = (float)elapsedFrames / (float)PawnMover.AmountOfFramesToGetToNextSpace;
        Vector3 nextLerpedPos = Vector3.Lerp(oldPos, newPos, interpolairRatio);
        pawnMover.MovePawnTransform(nextLerpedPos);

        pawnMover.CharacterRotationTransform.LookAt(newPos);
    }
}
