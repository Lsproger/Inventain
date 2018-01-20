using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Fields
    internal static bool isNeedToMove;
    #endregion


    #region Properties
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
    #endregion


    #region Unity lifecycle
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


    void Awake()
    {
        IsNeedToMove = false;
    }


    void Update()
    {
        if (IsNeedToMove)
        {
            Camera.main.transform.Translate(new Vector3(0.1f, 0, 0));
        }
    }
    #endregion


    #region Public Methods
    public void MoveNextPosition()
    {
        IsNeedToMove = true;
    }
    #endregion
}
