using UnityEngine;

namespace Gameplay
{
    public class CoyoteTimeComponent : MonoBehaviour, ICoyoteTimeComponent
    {
        [SerializeField] private CoyoteTimeMechanic coyoteTimeMechanic;

        public float CoyoteTime => this.coyoteTimeMechanic.CoyoteTime;

        public float LastJumpTime => this.coyoteTimeMechanic.LastJumpTime;

        public void SetCoyoteTime(float time)
        {
            this.coyoteTimeMechanic.SetoyoteTime(time);
        }

        public void SetLastJumpTime(float time)
        {
            this.coyoteTimeMechanic.SetLastJumpTime(time);
        }
    }
}