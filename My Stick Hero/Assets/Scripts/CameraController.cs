using UnityEngine;

public class CameraController : MonoBehaviour
{

    internal static bool isNeedToMove;

    internal static bool IsNeedToMove
    {
        get
        {
            return isNeedToMove;
        }
        set
        {
            isNeedToMove = value;
        }

    }


    void Awake()
    {
        IsNeedToMove = false;
    }


    void OnEnable()
    {
        EventAggregator.OnPlatformEdgeReachedEvent += this.MoveNextPosition;
        EventAggregator.OnPlayClickEvent += this.MoveNextPosition;
    }

    void OnDisable()
    {
        EventAggregator.OnPlatformEdgeReachedEvent -= this.MoveNextPosition;
        EventAggregator.OnPlayClickEvent -= this.MoveNextPosition;
    }

    void Update()
    {
        if (IsNeedToMove)
        {
            Camera.main.transform.Translate(new Vector3(0.1f, 0, 0));
        }
    }


    public void MoveNextPosition()
    {
        IsNeedToMove = true;
    }
}
