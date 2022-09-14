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
        private IKeyboardArrowsInput keyboardArrows;
        private IMoveComponent moveComponent;

        private void Awake()
        {
            this.enabled = false;
        }
        public void OnInitGame(IGameSystem system)
        {
            this.moveComponent = system.GetService<IMoveComponent>();
            this.keyboardArrows = system.GetService<IKeyboardArrowsInput>();
        }

        public void OnReadyGame(IGameSystem system)
        {
            this.keyboardArrows.OnArrowDirection += this.OnMove;
            this.keyboardArrows.OnArrowReleased += this.OnStopMove;
            this.enabled = true;
        }

        public void OnFinishGame()
        {
            this.enabled = false;
            this.keyboardArrows.OnArrowDirection -= OnMove;
            this.keyboardArrows.OnArrowReleased -= this.OnStopMove;
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