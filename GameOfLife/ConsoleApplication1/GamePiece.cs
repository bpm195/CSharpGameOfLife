using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class GamePiece
    {
        private const string _aliveSymbol = "1";
        private const string _deadSymbol = "0";
        public const PieceState defaultState = PieceState.Dead;

        public PieceState CurrentState { get; private set; }
        private PieceState _nextState;
        
        public GamePiece()
        {
            CurrentState = defaultState;
        }

        public GamePiece(PieceState state)
        {
            CurrentState = state;
        }

        public GamePiece(string state)
        {
            initializeState(state);
        }

        public GamePiece(char c)
        {
            initializeState(c.ToString());   
        }

        private void initializeState(string state)
        {
            switch (state)
            {
                case _aliveSymbol:
                    CurrentState = PieceState.Alive;
                    break;
                case _deadSymbol:
                    CurrentState = PieceState.Dead;
                    break;
                default:
                    CurrentState = defaultState;
                    break;
            }
        }

        public void Evaluate(int livingNeighbors)
        {
            if (ConfiguredSettings.BornConditions.Contains(livingNeighbors) && CurrentState == PieceState.Dead)
            {
                _nextState = PieceState.Alive;
            }
            else if (ConfiguredSettings.StayAliveConditions.Contains(livingNeighbors) && CurrentState == PieceState.Alive)
            {
                _nextState = PieceState.Alive;
            }
            else
            {
                _nextState = PieceState.Dead;
            }
        }

        public void Tick()
        {
            CurrentState = _nextState;
        }

        public override String ToString()
        {
            String retVal = String.Empty;
            switch (CurrentState)
            {
                case PieceState.Alive:
                    retVal = ConfiguredSettings.DisplayAlive;
                    break;
                case PieceState.Dead:
                    retVal = ConfiguredSettings.DisplayDead;
                    break;
            }

            return retVal;
        }
    }
}
