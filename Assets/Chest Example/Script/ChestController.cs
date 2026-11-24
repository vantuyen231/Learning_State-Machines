using UnityEngine;

namespace StateMachines.ChestExample
{
    [RequireComponent(typeof(ChestView))]
    public partial class ChestController : MonoBehaviour
    {
        [field: SerializeField] public StateMachine StateMachine { get; private set; }
        [field: SerializeField] public ChestView View { get; private set; }

        private void Awake()
        {
            StateMachine = new StateMachine();
            StateMachine.AddState(ChestState.CLOSED.ToString(), new ChestStateClosed(this));
            StateMachine.AddState(ChestState.OPEN.ToString(), new ChestStateOpen(this));
            View = GetComponent<ChestView>();
        }

        private void Start()
        {
            StateMachine.ChangeState(ChestState.CLOSED.ToString());
        }

        private void Update()
        {
            StateMachine.Update();
        }

        public void Open()
        {
            View.OpenChest();
        }

        public void Closed()
        {
            View.CloseChest();
        }
    }
}