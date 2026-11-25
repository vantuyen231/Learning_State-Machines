using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class IdleState : IState
    {
        public StateMachine StateMachine { get; set;}
        //Type _owner;
        CharacterController _owner;

        public IdleState(CharacterController owner)
        {
            // _owner = owner;
            _owner = owner;
        }

        public void Enter()
        {
            _owner.Animator.Play("Idle");
            _owner.Movement.SetVelocity(x: 0);
        }

        public void Execute()
        {
            if (_owner.ActionReader.MoveAction.x != 0)
            {
                StateMachine.ChangeState(CharacterStates.WALK.ToString());
                return;
            }
        }

        public void Exit()
        {

        }
    }
}
