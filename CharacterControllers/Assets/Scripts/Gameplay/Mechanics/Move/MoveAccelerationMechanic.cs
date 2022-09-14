using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class MoveAccelerationMechanic : MonoBehaviour
    {
        public event Action<float> OnAccelerationChanged;

        [SerializeField] private float acceleration;
        public float Acceleration => this.acceleration;

        [Header("Events")]
        [SerializeField] private UnityEvent<float> onAccelerationChanged;

        public void SetAcceleration(float acceleration)
        {
            this.acceleration = acceleration;
            OnAccelerationChanged?.Invoke(acceleration);
            onAccelerationChanged?.Invoke(acceleration);
        }
    }
}