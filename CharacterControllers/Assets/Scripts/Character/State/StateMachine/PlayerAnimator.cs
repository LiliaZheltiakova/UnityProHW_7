using UnityEngine;
using System;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly Lazy<int> STATE_PARAMETER = new Lazy<int>(() => Animator.StringToHash("State"));

        [SerializeField] private Animator animator;
        [SerializeField] private PlayerStateEnum state;
        [SerializeField] private float speed;

        public void SetAnimation(PlayerStateEnum state)
        {
            if (this.state != state)
            {
                this.animator.SetInteger(STATE_PARAMETER.Value, (int)state);
                this.state = state;
            }
        }

        private void Awake()
        {
            this.state = (PlayerStateEnum)this.animator.GetInteger(STATE_PARAMETER.Value);
        }
    }
}

