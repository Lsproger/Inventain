using UnityEngine;

public class CameraController : MonoBehaviour
{

    internal static bool isNeedToMove = false;


    void Update()
    {
        if (isNeedToMove)
        {
            Debug.Log("CAMERA: ISNEEDTOMOVE");
            Camera.main.transform.Translate(new Vector3(0.1f, 0, 0));
        }
    }


    public void MoveNextPosition()
    {
        isNeedToMove = true;
    }
}
