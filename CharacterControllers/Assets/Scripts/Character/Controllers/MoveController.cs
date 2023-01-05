using UnityEngine;
using GameS;
using InputSystem;
using Gameplay;

namespace Player
{
    public class MoveController : MonoBehaviour,
        IGameInitComponent,
        IGameReadyComponent,
        IGameFinishComponent
    {
        private IMoveInput moveInput;
        private IComponent_Move moveComponent;

        private void Awake()
        {
            this.enabled = false;
        }
        public void OnInitGame(IGameSystem system)
        {
            this.moveComponent = system.GetService<IComponent_Move>();
            this.moveInput = system.GetService<IMoveInput>();
        }

        public void OnReadyGame(IGameSystem system)
        {
            this.moveInput.OnMoveDirection += this.OnMove;
            this.moveInput.OnMoveInputStopped += this.OnStopMove;
            this.enabled = true;
        }

        public void OnFinishGame()
        {
            this.enabled = false;
            this.moveInput.OnMoveDirection -= OnMove;
            this.moveInput.OnMoveInputStopped -= this.OnStopMove;
        }

        private void OnMove(Vector2 direction)
        {
            moveComponent.Move(direction);
        }

        private void OnStopMove()
        {
            moveComponent.StopMove();
            //decc
        }
    }
}