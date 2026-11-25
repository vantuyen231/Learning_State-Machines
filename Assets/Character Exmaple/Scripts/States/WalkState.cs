using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class WalkState : IState
    {
        public StateMachine StateMachine { get; set;}
        //Type _owner;
        CharacterController _owner;

        public WalkState(CharacterController owner)
        {
            _owner = owner;
        }

        public void Enter()
        {
            _owner.Animator.Play("Walk");
            _owner.Movement.SetVelocity(x: _owner.ActionReader.MoveAction.x);
        }

        public void Execute()
        {
            if (_owner.ActionReader.MoveAction.x == 0)
            {
                StateMachine.ChangeState(CharacterStates.IDLE.ToString());
                return;
            }
            _owner.Movement.SetVelocity(x : _owner.ActionReader.MoveAction.x * 2f);
        }

        public void Exit()
        {

        }
    }
}
