using System;
using Common;

namespace Battle.GameStates
{
    public class GameOverState : GameState
    {
        private readonly GameFacade gameFacade;

        public GameOverState(GameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            gameFacade.StopBattle();
            EventQueue.Instance.EnqueueEvent(new EventData(EventIds.GameOver));
        }

        public void Stop()
        {

        }
    }
}