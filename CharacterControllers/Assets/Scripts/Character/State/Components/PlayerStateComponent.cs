using UnityEngine;

namespace Player
{
    public class PlayerStateComponent : MonoBehaviour, IPlayerStateComponent
    {
        public PlayerStateEnum State => this.stateMachine.CurrentState;

        [SerializeField] private PlayerStateMachine stateMachine;
    }
}