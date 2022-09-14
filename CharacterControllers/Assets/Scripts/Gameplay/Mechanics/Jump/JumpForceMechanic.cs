using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class JumpForceMechanic : MonoBehaviour
    {
        public event Action<float> OnJumpForceChanged;
        [SerializeField] private float jumpForce;
        public float JumpForce => this.jumpForce;
        [SerializeField] private UnityEvent<float> onJumpForceChanged;

        public void SetJumpForce(float jumpForce)
        {
            this.jumpForce = jumpForce;
            OnJumpForceChanged?.Invoke(jumpForce);
            onJumpForceChanged?.Invoke(jumpForce);
        }
    }
}