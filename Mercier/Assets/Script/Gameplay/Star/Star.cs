using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public void SpawnStar()
    {
        gameObject.SetActive(true);
    }

    public void DeSpawnStar()
    {
        gameObject.SetActive(false);
    }
}
