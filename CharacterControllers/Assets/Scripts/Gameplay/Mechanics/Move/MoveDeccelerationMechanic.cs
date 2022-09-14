using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class MoveDeccelerationMechanic : MonoBehaviour
    {
        public event Action<float> OnDeccelerationChanged;

        [SerializeField] private float decceleration;

        public float Decceleration => this.decceleration;

        [SerializeField] private UnityEvent<float> onDeccelerationChanged;

        public void SetDecceleration(float decceleration)
        {
            this.decceleration = decceleration;
            OnDeccelerationChanged?.Invoke(decceleration);
            onDeccelerationChanged?.Invoke(decceleration);
        }
    }
}