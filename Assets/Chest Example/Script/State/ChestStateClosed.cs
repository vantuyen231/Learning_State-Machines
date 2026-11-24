using UnityEngine;
using UnityEngine.InputSystem;

namespace StateMachines.ChestExample
{
    public class ChestStateClosed : IState
    {
        public StateMachine StateMachine { get; set; }
        ChestController _chestController;

        public ChestStateClosed(ChestController chestController)
        {
            _chestController = chestController;
        }
        
        private void OnClick()
        {
            _chestController.Open();
            StateMachine.ChangeState(ChestState.OPEN.ToString());
        }

        public void Enter()
        {
            _chestController.View.OnClick += OnClick;
        }

        public void Execute()
        {

        }

        public void Exit()
        {
            Debug.Log("Exited closed state");
            _chestController.View.OnClick -= OnClick;
        }
    }
}
