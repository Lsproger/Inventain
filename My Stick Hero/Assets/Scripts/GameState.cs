using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

    internal enum States { Menu, Game, DeathMenu}

    internal static States state;


	void Start () {
        state = States.Menu;
	}


    internal static void SetGameState(States value)
    {
        state = value;
    }


    internal static States GetGameState()
    {
        return state;
    }

}
