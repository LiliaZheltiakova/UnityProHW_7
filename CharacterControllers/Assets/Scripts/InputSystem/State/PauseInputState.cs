using UnityEngine;
using StateMachine;
using UnityEngine.Serialization;

namespace InputSystem
{
    public class PauseInputState : MonoState
    {
        [SerializeField] private PauseInput pauseInput;
        public override void EnterState()
        {
            this.pauseInput.enabled = true;
        }

        public override void ExitState()
        {
            this.pauseInput.enabled = false;
        }

        public override void UpdateState(float deltaTime)
        {
        }
    }
}