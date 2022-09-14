using UnityEngine;

namespace Gameplay
{
    public class JumpForceComponent : MonoBehaviour, IJumpForceComponent
    {
        [SerializeField] private JumpForceMechanic forceMechanic;
        public float JumpForce => this.forceMechanic.JumpForce;

        public void SetForce(float force)
        {
            this.forceMechanic.SetJumpForce(force);
        }
    }
}