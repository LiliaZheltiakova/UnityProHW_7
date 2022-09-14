using UnityEngine;
using StateMachine;

namespace InputSystem
{
    public class KeyboardESCState : MonoState
    {
        [SerializeField] private KeyboardESCInput keyboard;
        public override void EnterState()
        {
            this.keyboard.enabled = true;
        }

        public override void ExitState()
        {
            this.keyboard.enabled = false;
        }

        public override void UpdateState(float deltaTime)
        {
        }
    }
}