using UnityEngine;

namespace StateMachines.BearExample
{

    public class Floor : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;

        [SerializeField] private Bear _bear;
        [SerializeField] private Vector2 _position;

        public void Start()
        {
            _renderer = GetComponent<Renderer>();
            _bear.OnMove += ScollGround;
        }


        private void ScollGround(float x, float y)
        {
            if (_renderer == null) return;
            if (_renderer.material == null) return;
            _position = new Vector2(x, y);
            Vector2 newOffset = _renderer.material.mainTextureOffset + _position * Time.deltaTime;
            _renderer.material.mainTextureOffset = newOffset;
        }
    }
}