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
        private IKeyboardSpaceInput keyboardSpace;
        private IJumpComponent jumpComponent;

        private void Awake()
        {
            this.enabled = false;
        }

        public void OnInitGame(IGameSystem system)
        {
            this.jumpComponent = system.GetService<IJumpComponent>();
            this.keyboardSpace = system.GetService<IKeyboardSpaceInput>();
        }

        public void OnReadyGame(IGameSystem system)
        {
            this.keyboardSpace.OnKeyDown += OnJumpUp;
            this.keyboardSpace.OnKeyReleased += OnJumpDown;
            this.keyboardSpace.OnKeyHold += OnJumpUp;
        }

        public void OnFinishGame()
        {
            this.keyboardSpace.OnKeyDown -= OnJumpUp;
            this.keyboardSpace.OnKeyReleased -= OnJumpDown;
            this.keyboardSpace.OnKeyHold -= OnJumpUp;
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

