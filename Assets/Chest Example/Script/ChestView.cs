using System;
using UnityEngine;

namespace StateMachines.ChestExample
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        public event Action OnClick;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        public void OnMouseDown()
        {
            Debug.Log("Clicked Chest");
            OnClick?.Invoke();
        }

        public void OpenChest()
        {
            _anim.SetTrigger("Open");
        }

        public void CloseChest()
        {
            _anim.SetTrigger("Close");
        }
    }
}