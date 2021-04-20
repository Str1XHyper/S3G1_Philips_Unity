using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPositionReseter : MonoBehaviour
{
    // Update is called once per frame
    void LateUpdate()
    {
        transform.localPosition = Vector3.zero;
    }
}
