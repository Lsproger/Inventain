using UnityEngine;

internal class InputAggregator : MonoBehaviour {

    internal static event EventController.MethodContainer OnPlayClickEvent;
    internal static event EventController.MethodContainer OnCreateStickEvent;
    internal static event EventController.MethodContainer OnStopCreateStickEvent;
    internal static event EventController.MethodContainer OnStopRotateStickEvent;
    internal static event EventController.MethodContainer OnPlatformEdgeReachedEvent;
    internal static event EventController.MethodContainer OnGameOverEvent;



    internal static void OnPlayCliсkEventHandler ()
    {
        OnPlayClickEvent();
        
	}

    internal static void Game_OnCreateStickEvent()
    {
        OnCreateStickEvent();
    }

    internal static void Game_OnStopCreateStickEvent()
    {
        OnStopCreateStickEvent();
    }

    internal static void Game_OnStopRotateStickEvent()
    {
        OnStopRotateStickEvent();
    }

    internal static void Game_OnPlatformEdgeReachedEvent()
    {
        OnPlatformEdgeReachedEvent();
    }

    internal static void OnGameOverEventHandler()
    {
        OnGameOverEvent();
    }


}
