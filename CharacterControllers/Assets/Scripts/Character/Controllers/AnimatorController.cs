using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class AnimatorController : MonoBehaviour
    {
        private static readonly Lazy<int> STATE_PARAMETER = new Lazy<int>(() => Animator.StringToHash("State"));

        [SerializeField] private Animator animator;
        [SerializeField] private PlayerStateMachine playerStateMachine;
        [FormerlySerializedAs("state")] [SerializeField] private PlayerStateEnum animState;
        [SerializeField] private PlayerStateEnum currentSMstate;
        
        private void Awake()
        {
            this.animState = (PlayerStateEnum)this.animator.GetInteger(STATE_PARAMETER.Value);
        }
        
        private void Update()
        {
            currentSMstate = playerStateMachine.CurrentState;
            if (this.animState != currentSMstate)
            {
                SetAnimation(currentSMstate);
            }
        }

        private void SetAnimation(PlayerStateEnum newState)
        {
            this.animator.SetInteger(STATE_PARAMETER.Value, (int)newState);
            this.animState = newState;
        }
    }
}