using UnityEngine;
using StateMachine;

namespace InputSystem
{
    public class KeyboardSpaceState : MonoState
    {
        [SerializeField] private KeyboardSpaceInput keyboard;
        public override void EnterState()
        {
            this.keyboard.enabled = true;
        }

        public override void ExitState()
        {
            this.keyboard.CancelInput();
            this.keyboard.enabled = false;
        }

        public override void UpdateState(float deltaTime)
        {
        }
    }
}

