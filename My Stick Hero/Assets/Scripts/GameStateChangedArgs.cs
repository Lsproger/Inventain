using System;

namespace Assets.Scripts
{
    internal class GameStateChangedArgs : EventArgs
    {
        private GameStateManager.GameState _state = 0;

        public GameStateManager.GameState State
        {
            get { return _state; }
        }

        public GameStateChangedArgs(GameStateManager.GameState state)
        {
            _state = state;
        }

    }
}
