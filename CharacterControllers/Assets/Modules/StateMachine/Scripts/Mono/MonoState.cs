using UnityEngine;

namespace StateMachine
{
    public class MonoState : MonoBehaviour, IState
    {
        public virtual void EnterState() { }

        public virtual void ExitState() { }

        public virtual void UpdateState(float deltaTime) { }
    }
}