using UnityEngine;
using InputSystem;
using Gameplay;
using GameS;

namespace Player
{
    public class MoveState : MoveMechanicHandler,
        IGameReadyComponent
    {
        private IKeyboardArrowsInput keyboardArrowsInput;
        [SerializeField] private PlayerStateMachine stateMachine;

        public void OnReadyGame(IGameSystem system)
        {
            this.keyboardArrowsInput = system.GetService<IKeyboardArrowsInput>();
        }
        protected override void OnStartMove()
        {
            this.stateMachine.ChangeState(PlayerStateEnum.MOVE);
        }

        protected override void OnFinishMove()
        {
            this.stateMachine.ChangeState(SetUpFinishState());
        }

        private PlayerStateEnum SetUpFinishState()
        {
            if (keyboardArrowsInput.AnyArrowPressed)
                return PlayerStateEnum.MOVE;

            else
                return PlayerStateEnum.IDLE;
            //Change to decc
        }
    }
}