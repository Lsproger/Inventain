using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlatformEdge : MonoBehaviour {

    void OnBecameInvisible()
    {
        CameraController.IsNeedToMove = false;
    }
}
