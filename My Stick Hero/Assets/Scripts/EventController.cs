using UnityEngine;

public class EventAggregator : MonoBehaviour {

    public delegate void EventContainer();

    internal static event EventContainer OnPlayClickEvent;
    internal static event EventContainer OnCreateEvent;
    internal static event EventContainer OnStopCreateEvent;
    internal static event EventContainer OnStopRotateEvent;
    internal static event EventContainer OnPlatformEdgeReachedEvent;
    internal static event EventContainer OnGameOverEvent;
    internal static event EventContainer OnIncreaseScoreEvent;
    internal static event EventContainer OnGotPlatformEvent;


    internal static void Stick_OnGotPlatform()
    {
        CallIfNotNull(OnGotPlatformEvent);
    }


    internal static void Game_OnPlayCliсk()
    {
        CallIfNotNull(OnPlayClickEvent);
    }

    internal static void Stick_OnCreate()
    {
        CallIfNotNull(OnCreateEvent);
    }

    internal static void Stick_OnStopCreate()
    {
        CallIfNotNull(OnStopCreateEvent);
    }

    internal static void Stick_OnStopRotate()
    {
        CallIfNotNull(OnStopRotateEvent);
    }

    internal static void Character_OnPlatformEdgeReached()
    {
        CallIfNotNull(OnPlatformEdgeReachedEvent);
    }

    internal static void Game_OnGameOver()
    {
        CallIfNotNull(OnGameOverEvent);
    }

    internal static void Score_OnIncrease()
    {
        CallIfNotNull(OnIncreaseScoreEvent);
    }

    private static void CallIfNotNull(EventAggregator.EventContainer eventName)
    {
        if (eventName != null)
        {
            eventName();
        }
    }
}
