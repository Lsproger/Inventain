using UnityEngine;

public class LeftPlatformEdge : MonoBehaviour
{
    #region Unity lifecycle
    void OnBecameInvisible()
    {
        CameraController.IsNeedToMove = false;
    }
    #endregion
}
