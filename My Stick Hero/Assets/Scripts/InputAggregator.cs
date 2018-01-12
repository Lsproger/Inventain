using UnityEngine;

internal class InputAggregator : MonoBehaviour {

    internal static event EventController.MethodContainer OnPlayClickEvent;
    internal static event EventController.MethodContainer OnCreateStickEvent;
    internal static event EventController.MethodContainer OnStopCreateStickEvent;

    internal static void OnPlayClikEventHandler ()
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
}
