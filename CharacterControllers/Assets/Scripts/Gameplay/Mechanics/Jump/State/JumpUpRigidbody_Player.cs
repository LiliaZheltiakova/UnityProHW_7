using UnityEngine;
using StateMachine;

namespace Gameplay
{
    public class JumpUpRigidbody_Player : MonoState
    {
        [SerializeField] private JumpMechanic jumpMechanic;
        [SerializeField] private Rigidbody2D rigidbody;

        public override void UpdateState(float deltaTime)
        {
            this.UpdateJump(deltaTime);
        }

        private void UpdateJump(float deltaTime)
        {

            if (!this.jumpMechanic.IsJumpingUp && !this.jumpMechanic.IsGrounded)
            {
                this.jumpMechanic.CoyoteTimeCounterMechanic.UpdateTimeCounter(deltaTime);
                return;
            }

            if (this.jumpMechanic.JumpTimeCounterMechanic.TimeCounter > 0f && this.jumpMechanic.IsJumpingUp)
            {
                rigidbody.AddForce(Vector2.up * this.jumpMechanic.JumpForceMechanic.JumpForce, ForceMode2D.Impulse);
                this.jumpMechanic.JumpTimeCounterMechanic.UpdateTimeCounter(deltaTime);
            }

            else
            {
                this.jumpMechanic.JumpDown();
            }
        }
    }
}

