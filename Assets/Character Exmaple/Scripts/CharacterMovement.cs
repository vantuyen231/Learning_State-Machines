using System;
using UnityEngine;

namespace StateMachines.CharacterExample
{
    [Serializable]
    public class CharacterMovement
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public bool isFlip = false;

        public CharacterMovement(Rigidbody2D rigidbody)
        {
            Rigidbody = rigidbody;
        }

        #region Code Lucas
        public void SetVelocity(float x, float y)
        {
            if(x > 0) Rigidbody.transform.localScale = new Vector3(1,1,1);
            else if (x < 0) Rigidbody.transform.localScale = new Vector3(-1,1,1);
            Rigidbody.linearVelocity = new Vector2(x, y);
        }

        public void SetVelocity(float? x, float? y = null)
        {
            Vector2 currentVelocity = Rigidbody.linearVelocity;
            float newX = x ?? currentVelocity.x;
            float newY = y ?? currentVelocity.y;

            this.SetVelocity(newX, newY);
        }
        #endregion

        #region MyCode
        //public void SetVelocity(float x, float y)
        //{
        //    this.HandFlip(x);

        //    Rigidbody.linearVelocity = new Vector2(x, y);
        //}

        //public void HandFlip(float x)
        //{
        //    if (x > 0 && isFlip == true)
        //    {
        //        this.Flip();
        //    }
        //    else if (x < 0 && isFlip == false)
        //    {
        //        this.Flip();
        //    }
        //}

        //public void Flip()
        //{
        //    Rigidbody.transform.Rotate(0, 180, 0);
        //    isFlip = !isFlip;
        //}
        #endregion
    }
}
