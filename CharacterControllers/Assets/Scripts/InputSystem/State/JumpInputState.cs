using StateMachine;
using UnityEngine;

namespace InputSystem
{
    public class JumpInputState : MonoState
    {
        [SerializeField] private JumpInput jumpInput;
        
        public override void EnterState()
        {
            this.jumpInput.enabled = true;
        }

        public override void ExitState()
        {
            this.jumpInput.CancelInput();
            this.jumpInput.enabled = false;
        }

        public override void UpdateState(float deltaTime)
        {
        }
    }
}