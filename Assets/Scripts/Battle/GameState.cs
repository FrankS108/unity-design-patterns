using System;

namespace Battle
{
    public interface GameState
    {
        void Start(Action<GameStateController.GameStates> onEndedCallback);
        void Stop();
    }
}