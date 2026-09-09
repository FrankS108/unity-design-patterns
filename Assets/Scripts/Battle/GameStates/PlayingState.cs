using System;
using Common;
using Ships.Common;

namespace Battle.GameStates
{
    public class PlayingState : GameState, EventObserver
    {
        private Action<GameStateController.GameStates> onEndedCallback;
        private int aliveShips;
        private bool allShipSpawned;

        public void Start(Action<GameStateController.GameStates> onEndedCallback)
        {
            this.onEndedCallback = onEndedCallback;
            aliveShips = 0;
            allShipSpawned = false;
            EventQueue.Instance.Subscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Subscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Subscribe(EventIds.AllShipSpawned, this);
        }

        public void Stop()
        {
            EventQueue.Instance.Unsubscribe(EventIds.ShipDestroyed, this);
            EventQueue.Instance.Unsubscribe(EventIds.ShipSpawned, this);
            EventQueue.Instance.Unsubscribe(EventIds.AllShipSpawned, this);
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ShipDestroyed)
            {
                aliveShips -= 1;
                var shipDestroyedEventData = (ShipDestroyedEventData)eventData;
                if (shipDestroyedEventData.Team == Teams.Ally)
                {
                    onEndedCallback?.Invoke(GameStateController.GameStates.GameOver);
                    return;
                }
            }
            else if (eventData.EventId == EventIds.ShipSpawned)
            {
                aliveShips += 1;
            }
            else if (eventData.EventId == EventIds.AllShipSpawned)
            {
                allShipSpawned = true;
            }

            CheckGameState();
        }


        private void CheckGameState()
        {
            if (aliveShips == 0 && allShipSpawned)
            {
                onEndedCallback?.Invoke(GameStateController.GameStates.Victory);
            }
        }
    }
}