using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    internal delegate void GameStateChangedHandler(object sender, GameStateChangedArgs GameStateChangedArgs);
    internal GameStateChangedHandler GameStateChanged;


    internal class GameStateChangedArgs : EventArgs
    {
        private GameState _state = 0;

        public GameState State
        {
            get { return _state; }
        }

        public GameStateChangedArgs(GameState state)
        {
            _state = state;
        }

    }


    internal static GameStateManager instance = null;
    internal enum GameState { Menu, Game, GameOverMenu }
    private static GameState state;
    internal GameState State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
            if (GameStateChanged != null)
            {
                GameStateChanged(this, new GameStateChangedArgs(state));
            }
        }
    }

    void Start()
    {
        Debug.Log("Instance: " + instance);
        if (instance == null)
        {
            Debug.Log("Instance set");
            instance = this;
        }
        else
        {
            throw new Exception("Instance of GameStateChange already exist");
        }

        instance.GameStateChanged += new GameStateChangedHandler(EnableUIItem);
        Debug.Log("Handler Added");
        State = GameState.Menu;
    }




    internal void EnableUIItem(object sender, GameStateChangedArgs gameStateChangedArgs)
    {
        foreach (Transform child in transform)
        {
            if (child.name == gameStateChangedArgs.State.ToString())
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }

}
