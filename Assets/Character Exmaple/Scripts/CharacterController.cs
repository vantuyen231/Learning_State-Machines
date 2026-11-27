using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterProperties characterProperties { get; private set; }
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public StateMachine StateMachine { get; private set; }

        private void Awake()
        {
            Movement = new CharacterMovement(characterProperties, GetComponent<Rigidbody2D>());
            StateMachine = new StateMachine();

            StateMachine.AddState(CharacterStates.IDLE.ToString(), new IdleState(this));
            StateMachine.AddState(CharacterStates.WALK.ToString(), new WalkState(this));
        }

        private void Start()
        {
            StateMachine.ChangeState(CharacterStates.IDLE.ToString());
        }
        private void OnEnable()
        {
            ActionReader.OnEnable();
        }

        private void Update()
        {
            ActionReader.OnUpdate();
            StateMachine.Update();
            //if (ActionReader.MoveAction.x == 0)
            //{
            //    Animator.Play("Idle");
            //}else
            //{
            //    Animator.Play("Walk");
            //}

            //Movement.SetVelocity(x: ActionReader.MoveAction.x);
        }

        private void OnDisable()
        {
            ActionReader.OnDisable();
        }
    }
}