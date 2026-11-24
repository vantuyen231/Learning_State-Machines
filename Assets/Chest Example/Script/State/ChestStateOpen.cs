using System;
using UnityEngine;

namespace StateMachines.ChestExample
{
    public class ChestStateOpen : IState
    {
        public StateMachine StateMachine { get; set; }
        ChestController _chestController;

        public ChestStateOpen(ChestController chestController)
        {
            _chestController = chestController;
        }

        private void OnClick()
        {
            _chestController.Closed();
            StateMachine.ChangeState(ChestState.CLOSED.ToString());
        }

        public void Enter()
        {
            _chestController.View.OnClick += OnClick;

        }

        public void Execute()
        {
            Debug.Log("Runing open state");

        }

        public void Exit()
        {
            Debug.Log("Exited open state");
            _chestController.View.OnClick -= OnClick;
        }
    }
}
