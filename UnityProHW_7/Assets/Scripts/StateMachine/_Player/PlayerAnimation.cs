using UnityEngine;

namespace Homework
{
    public class PlayerAnimation : State
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerStateEnum stateID;

        public override void EnterState()
        {
            animator.SetTrigger(stateID.ToString());
        }
    }
}