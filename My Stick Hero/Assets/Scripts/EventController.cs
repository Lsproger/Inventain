using UnityEngine;

public class EventAggregator : MonoBehaviour {

    public delegate void EventContainer();

    internal static event EventContainer OnPlayClickEvent;
    internal static event EventContainer OnCreateStickEvent;
    internal static event EventContainer OnStopCreateStickEvent;
    internal static event EventContainer OnStopRotateStickEvent;
    internal static event EventContainer OnPlatformEdgeReachedEvent;
    internal static event EventContainer OnGameOverEvent;
    internal static event EventContainer OnIncreaseScoreEvent;
    internal static event EventContainer OnStickGotOnPlatformEvent;


    internal static void OnStickGotOnPlatformEventHandler()
    {
        CallIfNotNull(OnStickGotOnPlatformEvent);
    }


    internal static void OnPlayCliсkEventHandler()
    {
        CallIfNotNull(OnPlayClickEvent);
    }

    internal static void OnCreateStickEventHandler()
    {
        CallIfNotNull(OnCreateStickEvent);
    }

    internal static void OnStopCreateStickEventHandler()
    {
        CallIfNotNull(OnStopCreateStickEvent);
    }

    internal static void OnStopRotateStickEventHandler()
    {
        CallIfNotNull(OnStopRotateStickEvent);
    }

    internal static void OnPlatformEdgeReachedEventHandler()
    {
        CallIfNotNull(OnPlatformEdgeReachedEvent);
    }

    internal static void OnGameOverEventHandler()
    {
        CallIfNotNull(OnGameOverEvent);
    }

    internal static void OnIncreaseScoreEventHandler()
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
