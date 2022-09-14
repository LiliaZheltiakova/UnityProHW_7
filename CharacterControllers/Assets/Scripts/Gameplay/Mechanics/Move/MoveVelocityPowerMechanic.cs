using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class MoveVelocityPowerMechanic : MonoBehaviour
    {
        public event Action<float> OnVelPowerChanged;

        [SerializeField] private float velPower;

        public float VelocityPower => this.velPower;

        [SerializeField] private UnityEvent<float> onVelPowerChanged;

        public void SetVelocityPower(float velPower)
        {
            this.velPower = velPower;
            OnVelPowerChanged?.Invoke(velPower);
            onVelPowerChanged?.Invoke(velPower);
        }
    }
}

