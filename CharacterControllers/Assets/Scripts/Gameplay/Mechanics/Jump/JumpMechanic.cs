using UnityEngine;
using System;
using UnityEngine.Events;

namespace Gameplay
{
    public class JumpMechanic : MonoBehaviour
    {
        public event Action OnStartJumpUp;
        public event Action OnStartJumpDown;
        public event Action OnFinishJump;

        private bool isJumpingUp;
        private bool isJumpingDown;
        public bool IsJumpingUp => this.isJumpingUp;

        private bool finishJump = true;

        [Space] 
        [Header("Other Mechanics")]
        [SerializeField] private GroundCheckMechanic groundMech;
        public bool IsGrounded => this.groundMech.IsGrounded();
        
        [SerializeField] private FloatMechanic jumpForceMechanic; 
        public FloatMechanic JumpForceMechanic => this.jumpForceMechanic;
        
        [SerializeField] private FloatMechanic jumpTimeMechanic; 
        public FloatMechanic JumpTimeMechanic => this.jumpTimeMechanic;

        [SerializeField] private TimeCounterMechanic jumpTimeCounterMechanic;
        public TimeCounterMechanic JumpTimeCounterMechanic => this.jumpTimeCounterMechanic;

        [SerializeField] private CoyoteTimeMechanic coyoteTimeMechanic;
        public CoyoteTimeMechanic CoyoteTimeMechanic => this.coyoteTimeMechanic;

        [SerializeField] private TimeCounterMechanic coyoteTimeCounterMechanic;
        public TimeCounterMechanic CoyoteTimeCounterMechanic => this.coyoteTimeCounterMechanic;

        [Header("Events")]
        [SerializeField] private UnityEvent onStartJumpUp;
        [SerializeField] private UnityEvent onStartJumpDown;
        [SerializeField] private UnityEvent onFinishJump;

        public void JumpUp()
        {
            if(this.coyoteTimeCounterMechanic.TimeCounter > 0f)
            {
                if (!this.isJumpingUp)
                {
                    this.finishJump = false;
                    this.isJumpingDown = false;
                    this.isJumpingUp = true;
                    this.jumpTimeCounterMechanic.ResetTimeCounter(this.jumpTimeMechanic.Value);
                    this.onStartJumpUp?.Invoke();
                    this.OnStartJumpUp?.Invoke();
                }
            }
        }

        public void JumpDown()
        {
            if (!this.isJumpingDown)
            {
                this.isJumpingUp = false;
                this.finishJump = false;

                this.jumpTimeCounterMechanic.ResetTimeCounter(0f);
                this.coyoteTimeCounterMechanic.ResetTimeCounter(0f);

                this.onStartJumpDown?.Invoke();
                this.OnStartJumpDown?.Invoke();
            }
        }

        public void FinishJumping()
        {
        }

        private void FixedUpdate()
        {
            if (this.groundMech.IsGrounded())
            {
                this.coyoteTimeCounterMechanic.ResetTimeCounter(this.coyoteTimeMechanic.CoyoteTime);
            }

            if (this.finishJump)
                return;


            if (!this.isJumpingUp && !this.isJumpingDown
                                  && !this.finishJump
                                  && this.groundMech.IsGrounded())
            {
                this.finishJump = true;
                this.isJumpingUp = false;
                this.isJumpingDown = false;
                
                this.onFinishJump?.Invoke();
                this.OnFinishJump?.Invoke();
            }
        }
    }
}