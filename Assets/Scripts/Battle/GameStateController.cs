using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Battle.GameStates;
using Common;
using Ships.Common;
using UI;
using UnityEngine;

namespace Battle
{
    public class GameStateController : MonoBehaviour
    {
        public enum GameStates
        {
            Playing,
            GameOver,
            Victory
        }
        [SerializeField] private GameFacade gameFacade;
        private GameState currentState;
        private Dictionary<GameStates, GameState> idToState;

        private void Awake()
        {
            idToState = new Dictionary<GameStates, GameState>
            {
                {GameStates.Playing, new PlayingState()},
                {GameStates.GameOver, new GameOverState(gameFacade)},
                {GameStates.Victory, new VictoryState(gameFacade)}


            };
        }

        private void Start()
        {
            currentState = GetState(GameStates.Playing);
            currentState.Start(ChangeToNextState);
        }

        private async void ChangeToNextState(GameStates nextState)
        {
            await Task.Yield();
            currentState.Stop();
            currentState = GetState(nextState);
            currentState.Start(ChangeToNextState);
        }

        public void Reset()
        {
            ChangeToNextState(GameStates.Playing);
        }

        private GameState GetState(GameStates gameState)
        {
            return idToState[gameState];
        }
    }
}