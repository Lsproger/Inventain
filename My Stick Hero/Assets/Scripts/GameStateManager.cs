using Assets.Scripts;
using System;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    internal delegate void GameStateChangedHandler
        (object sender, GameStateChangedArgs GameStateChangedArgs);
    internal GameStateChangedHandler GameStateChanged;
    internal static GameStateManager instance = null;
    internal enum GameState { Menu, Game, GameOverMenu }
    private static GameState state;
    internal  GameState State
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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new Exception("Instance of GameStateChange already exist");
        }

        instance.GameStateChanged += new GameStateChangedHandler(EnableUIItem);
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
