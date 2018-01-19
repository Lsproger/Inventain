using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour {

    internal const float BACKGROUND_WIDTH = 15;

    void OnBecameInvisible()
    {
        transform.position = new Vector3
            (
            transform.position.x + BACKGROUND_WIDTH * 2,
            transform.position.y,
            transform.position.z
            );
    }
}
