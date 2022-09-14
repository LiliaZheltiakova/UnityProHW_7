using UnityEngine;

namespace Gameplay
{
    public class JumpMechanicHandler : MonoBehaviour
    {
        [SerializeField] private JumpMechanic jumpMechanic;

        private void OnEnable()
        {
            this.jumpMechanic.OnStartJumpUp += this.OnStartJumpUp;
            this.jumpMechanic.OnStartJumpDown += this.OnStartJumpDown;
            this.jumpMechanic.OnFinishJump += this.OnFinishJump;
        }

        private void OnDisable()
        {
            this.jumpMechanic.OnStartJumpUp -= this.OnStartJumpUp;
            this.jumpMechanic.OnStartJumpDown -= this.OnStartJumpDown;
            this.jumpMechanic.OnFinishJump -= this.OnFinishJump;
        }

        protected virtual void OnStartJumpUp() { }
        protected virtual void OnStartJumpDown() { }
        protected virtual void OnFinishJump() { }
    }
}