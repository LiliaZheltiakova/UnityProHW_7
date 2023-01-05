using UnityEngine;
using GameS;
using InputSystem;
using Gameplay;

namespace Player
{
    public class JumpController : MonoBehaviour,
    IGameInitComponent,
    IGameReadyComponent,
    IGameFinishComponent
    {
        private IJumpInput jumpInput;
        private IComponent_Jump jumpComponent;

        private void Awake()
        {
            this.enabled = false;
        }

        public void OnInitGame(IGameSystem system)
        {
            this.jumpComponent = system.GetService<IComponent_Jump>();
            this.jumpInput = system.GetService<IJumpInput>();
        }

        public void OnReadyGame(IGameSystem system)
        {
            this.jumpInput.OnKeyDown += OnJumpUp;
            this.jumpInput.OnKeyReleased += OnJumpDown;
            this.jumpInput.OnKeyHold += OnJumpUp;
        }

        public void OnFinishGame()
        {
            this.jumpInput.OnKeyDown -= OnJumpUp;
            this.jumpInput.OnKeyReleased -= OnJumpDown;
            this.jumpInput.OnKeyHold -= OnJumpUp;
        }

        private void OnJumpUp()
        {
            this.jumpComponent.JumpUp();
        }

        private void OnJumpDown()
        {
            this.jumpComponent.JumpDown();
        }
    }
}

