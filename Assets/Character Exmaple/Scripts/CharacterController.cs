using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterController : MonoBehaviour
    {
        [field: SerializeField] public CharacterActionReader ActionReader { get; private set; }
        [field: SerializeField] public CharacterMovement Movement { get; private set; }

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
            Movement.SetVelocity(ActionReader.MoveAction.x, Movement.Rigidbody.linearVelocityY);
        }

        private void OnDisable()
        {
            ActionReader.OnDisable();
        }
    }
}