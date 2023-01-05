using System;
using Gameplay;
using UnityEngine;

namespace Player
{
    public class PlayerStateMachineController : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine stateMachine;

        [SerializeField] private MoveMechanic moveMechanic;

        [SerializeField] private JumpMechanic jumpMechanic;
        
        private void OnEnable()
        {
            // Move
            this.moveMechanic.OnStartMove += this.OnStartMove;
            this.moveMechanic.OnFinishMove += this.OnFinishMove;
            
            // Jump
            this.jumpMechanic.OnStartJumpUp += this.OnStartJumpUp;
            this.jumpMechanic.OnStartJumpDown += this.OnStartJumpDown;
            this.jumpMechanic.OnFinishJump += this.OnFinishJump;
        }

        private void OnDisable()
        {
            // Move
            this.moveMechanic.OnStartMove -= this.OnStartMove;
            this.moveMechanic.OnFinishMove -= this.OnFinishMove;
            
            // Jump
            this.jumpMechanic.OnStartJumpUp -= this.OnStartJumpUp;
            this.jumpMechanic.OnStartJumpDown -= this.OnStartJumpDown;
            this.jumpMechanic.OnFinishJump -= this.OnFinishJump;
        }

        // Move
        private void OnStartMove()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.MOVE);
        }

        private void OnFinishMove()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.IDLE);
        }
        
        // Jump
        private void OnStartJumpUp()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.JUMPUP);
        }

        private void OnStartJumpDown()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.JUMPDOWN);
        }

        private void OnFinishJump()
        {
            if(moveMechanic.IsMoving)
                this.stateMachine.ChangeState(PlayerStateEnum.MOVE);
            else
                this.stateMachine.ChangeState(PlayerStateEnum.IDLE);
        }
    }
}