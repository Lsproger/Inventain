using UnityEngine;

public class CameraController : MonoBehaviour
{

    internal static bool isNeedToMove = false;


    void OnEnable()
    {
        Debug.Log("CAMAERA ENable");
        InputAggregator.OnPlatformEdgeReachedEvent += this.MoveNextPosition;
        InputAggregator.OnPlayClickEvent += this.MoveNextPosition;
    }

    void OnDisable()
    {
        InputAggregator.OnPlatformEdgeReachedEvent -= this.MoveNextPosition;
        InputAggregator.OnPlayClickEvent -= this.MoveNextPosition;
    }

    void Update()
    {
        if (isNeedToMove)
        {
            Camera.main.transform.Translate(new Vector3(0.1f, 0, 0));
        }
    }


    public void MoveNextPosition()
    {
        isNeedToMove = true;
    }
}
