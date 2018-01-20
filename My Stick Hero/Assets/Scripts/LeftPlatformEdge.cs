using UnityEngine;

public class LeftPlatformEdge : MonoBehaviour
{

    void OnBecameInvisible()
    {
        CameraController.IsNeedToMove = false;
    }
}
