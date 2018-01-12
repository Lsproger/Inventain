using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlatformEdge : MonoBehaviour {

    void OnBecameInvisible()
    {
        CameraController.isNeedToMove = false;
        Debug.Log("BECOME INVISIBLE");
        
    }

    void OnBecameVisible()
    {
        Debug.Log("BECOMEVISIBLE");
    }
}
