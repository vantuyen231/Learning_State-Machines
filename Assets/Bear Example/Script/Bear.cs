using System;
using UnityEngine;

namespace StateMachines.BearExample
{
    public class Bear : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Vector2 _input;
        [SerializeField] private float delayTime = 0.1f;

        [SerializeField] private bool _isTranform = false;
        [SerializeField] private float _delayTimer = 0f;
        [SerializeField] private string _animationState;

        public event Action<float, float> OnMove;
        private void Update()
        {
            this.InputBear();
        }

        private void InputBear()
        {
            if (_isTranform)
            {
                _delayTimer += Time.deltaTime;
                if (_delayTimer > delayTime)
                {
                    _delayTimer = 0;
                    _isTranform = false;
                }
            }
            else
            {
                _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                if (_input.y > 0 && _animationState != "Walk Forward")
                {
                    _animator.CrossFade("Walk Forward", delayTime);
                    _delayTimer = 0;
                    _isTranform = true;
                    _animationState = "Walk Forward";
                }
                else if (_input.y == 0 && _animationState != "Idle")
                {
                    _animator.CrossFade("Idle", delayTime);
                    _isTranform = true;
                    _delayTimer = 0;
                    _animationState = "Idle";
                }
                else if (_input.y < 0 && _animationState != "Walk Back")
                {
                    _animator.CrossFade("Walk Back", delayTime);
                    _delayTimer = 0;
                    _isTranform = true;
                    _animationState = "Walk Back";
                }
                OnMove?.Invoke(_input.x, _input.y);
            }
        }
    }
}