using UnityEngine;
using Gameplay;
using InputSystem;
using GameS;

namespace Player
{
    public class JumpState : JumpMechanicHandler,
        IGameReadyComponent
    {
        private IKeyboardArrowsInput keyboardArrowsInput;
        [SerializeField] private PlayerStateMachine stateMachine;

        public void OnReadyGame(IGameSystem system)
        {
            this.keyboardArrowsInput = system.GetService<IKeyboardArrowsInput>();
        }

        protected override void OnStartJumpUp()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.JUMPUP);
        }

        protected override void OnStartJumpDown()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.JUMPDOWN);
        }

        protected override void OnFinishJump()
        {
            this.stateMachine.ChangeState(SetUpFinishState());
        }

        private PlayerStateEnum SetUpFinishState()
        {
            if (keyboardArrowsInput.AnyArrowPressed)
                return PlayerStateEnum.MOVE;

            else
                return PlayerStateEnum.IDLE;
        }


    }
}