using UnityEngine;

namespace StateMachines.CharacterExample
{
    public class CharacterMovement
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

        public CharacterMovement(Rigidbody2D rigidbody)
        {
            Rigidbody = rigidbody;
        }

        public void SetVelocity(float x, float y)
        {
            if (x > 0)
            {
                Rigidbody.transform.Rotate(0, 0, 0);
            }
            else if (x < 0) Rigidbody.transform.Rotate(0,180,0);

            Rigidbody.linearVelocity = new Vector2 (x, y);
        }
    }
}
