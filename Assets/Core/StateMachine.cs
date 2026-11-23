using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace StateMachines
{
    [Serializable]
    public class StateMachine
    {
        Dictionary<string, IState> _states = new Dictionary<string, IState>();
        [field: SerializeField] private IState _currentState;
        [field: SerializeField] private string _currentStateName;

        public void AddState(string nameState, IState state)
        {
            _states[nameState] = state;
            state.StateMachine = this;
        }
        public void ChangeState(string nameState)
        {
            _currentState?.Exit();
            _currentState = _states[nameState];
            _currentStateName = nameState;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Execute();
        }
    }
}
