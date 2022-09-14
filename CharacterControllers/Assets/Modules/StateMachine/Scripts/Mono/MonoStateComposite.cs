using UnityEngine;

namespace StateMachine
{
    public sealed class MonoStateComposite : MonoState
    {
        [SerializeField] private MonoState[] stateComponents;

        public override void EnterState()
        {
            for (int i = 0, count = this.stateComponents.Length; i < count; i++)
            {
                var state = this.stateComponents[i];
                state.EnterState();
            }
        }

        public override void ExitState()
        {
            for (int i = 0, count = this.stateComponents.Length; i < count; i++)
            {
                var state = this.stateComponents[i];
                state.ExitState();
            }
        }

        public override void UpdateState(float deltaTime)
        {
            for (int i = 0, count = this.stateComponents.Length; i < count; i++)
            {
                var state = this.stateComponents[i];
                state.UpdateState(deltaTime);
            }
        }
    }
}