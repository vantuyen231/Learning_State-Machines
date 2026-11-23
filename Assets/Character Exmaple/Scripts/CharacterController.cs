using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        [field: SerializeField] public StateMachine StateMachine { get; private set; }

        private void Awake()
        {
            Movement = new CharacterMovement(GetComponent<Rigidbody2D>());
        }
        private void OnEnable()
        {
            ActionReader.OnEnable();
        }

        private void Update()
        {
            ActionReader.OnUpdate();
            if (ActionReader.MoveAction.x == 0)
            {
                Animator.Play("Idle");
            }else
            {
                Animator.Play("Walk");
            }

            Movement.SetVelocity(x: ActionReader.MoveAction.x);
        }

        private void OnDisable()
        {
            ActionReader.OnDisable();
        }
    }
}