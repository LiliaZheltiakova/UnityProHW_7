using UnityEngine;

namespace Gameplay
{
    public class JumpTimeComponent : MonoBehaviour, IJumpTimeComponent
    {
        [SerializeField] private JumpTimeMechanic timeMechanic;
        public float JumpTime => this.timeMechanic.JumpTime;

        public void SetJumpTime(float time)
        {
            this.timeMechanic.SetJumpTime(time);
        }
    }
}