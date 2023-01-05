using UnityEngine;
using StateMachine;

namespace InputSystem
{
    public class MoveInputState : MonoState
    {
        [SerializeField] private MoveInput moveInput;
        
        public override void EnterState()
        {
            this.moveInput.enabled = true;
        }

        public override void ExitState()
        {
            this.moveInput.CancelInput();
            this.moveInput.enabled = false;
        }

        public override void UpdateState(float deltaTime)
        {
        }
    }
}