using UnityEngine;

namespace StateMachines
{
    [CreateAssetMenu(fileName = "CharacterProperties", menuName = "Scriptable Objects/CharacterProperties")]
    public class CharacterProperties : ScriptableObject
    {
        [Header("Movement Data")]
        public float walkSpeed;
    }
}
