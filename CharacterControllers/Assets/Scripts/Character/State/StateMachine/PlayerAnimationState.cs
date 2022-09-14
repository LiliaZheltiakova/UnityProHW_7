using UnityEngine;
using StateMachine;

namespace Player
{
    public class PlayerAnimationState : MonoState
    {
        [SerializeField] private PlayerAnimator animator;
        [SerializeField] private PlayerAnimationInfo enterAnimationInfo;
        [Space]
        [SerializeField] private bool hasExitAnimation;

        [SerializeField] private PlayerAnimationInfo exitAnimationInfo;

        public override void EnterState()
        {
            this.animator.SetAnimation(this.enterAnimationInfo.animation);
        }

        public override void ExitState()
        {
            if (this.hasExitAnimation)
            {
                this.animator.SetAnimation(this.exitAnimationInfo.animation);
            }
        }
    }
}