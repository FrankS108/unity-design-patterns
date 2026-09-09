using System;
using Common;

namespace Battle.GameStates
{
    public class VictoryState : GameState
    {
        private readonly GameFacade gameFacade;

        public VictoryState(GameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
        }

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            gameFacade.StopBattle();
            EventQueue.Instance.EnqueueEvent(new EventData(EventIds.Victory));
        }

        public void Stop()
        {

        }
    }
}