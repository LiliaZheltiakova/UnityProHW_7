using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class JumpTimeMechanic : MonoBehaviour
    {
        public event Action<float> OnJumpTimeChanged;
        [SerializeField] private float jumpTime;
        public float JumpTime => this.jumpTime;
        [SerializeField] private UnityEvent<float> onJumpTimeChanged;

        public void SetJumpTime(float time)
        {
            this.jumpTime = time;
            OnJumpTimeChanged?.Invoke(time);
            onJumpTimeChanged?.Invoke(time);
        }
    }
}