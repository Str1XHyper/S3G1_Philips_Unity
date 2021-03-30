using System.Collections;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField] private int amountOfFramesToGetToNextSpace;
    private SmartTile currentSmartTile;

    private void Start()
    {
        currentSmartTile = TileManager.instance.GetStartTile();
    }

    public void MovePawnToNextSpace()
    {
        SmartTile tileToMoveTo = currentSmartTile.NextTile;

        StartCoroutine(LerpPawnToNewPos(currentSmartTile.PawnPos, tileToMoveTo.PawnPos));

        currentSmartTile = tileToMoveTo;
    }

    public void MovePawnToTile(SmartTile tileToMoveTo)
    {
        currentSmartTile = tileToMoveTo;

        MovePawnTransform(currentSmartTile.PawnPos);
    }

    private void MovePawnTransform(Vector3 posToMoveTo)
    {
        transform.position = posToMoveTo;
    }

    private IEnumerator LerpPawnToNewPos(Vector3 oldPos, Vector3 newPos)
    {
        int elapsedFrames = 0;

        while (elapsedFrames < amountOfFramesToGetToNextSpace)
        {
            float interpolairRatio = (float)elapsedFrames / (float)amountOfFramesToGetToNextSpace;

            Vector3 nextLerpedPos = Vector3.Lerp(oldPos, newPos, interpolairRatio);

            MovePawnTransform(nextLerpedPos);

            elapsedFrames++;

            yield return new WaitForFixedUpdate();
        }
    }
}