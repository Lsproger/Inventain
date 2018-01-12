using UnityEngine;

public class EventController : MonoBehaviour {

    public delegate void MethodContainer();


    [SerializeField]
    private Character ch;
    [SerializeField]
    private CameraController cam;
    [SerializeField]
    private Game game;


    void Awake()
    {
        InputAggregator.OnPlayClickEvent += ch.StartMove;
        InputAggregator.OnPlayClickEvent += cam.MoveNextPosition;
        InputAggregator.OnCreateStickEvent += game.CreateStick;
        InputAggregator.OnStopCreateStickEvent += game.StopCreateStick;
        InputAggregator.OnStopRotateStickEvent += ch.StartMove;
        InputAggregator.OnPlatfotmEdgeReachedEvent += cam.MoveNextPosition;
    }
}
