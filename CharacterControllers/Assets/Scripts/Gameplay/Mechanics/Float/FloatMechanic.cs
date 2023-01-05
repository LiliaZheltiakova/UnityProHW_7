using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class FloatMechanic : MonoBehaviour
    {
        public event Action<float> OnValueChanged;
        public float Value => this.value;

        [SerializeField] private float value;

        [SerializeField] private UnityEvent<float> onValueChanged;

        public void SetValue(float newValue)
        {
            this.value = newValue;
            OnValueChanged?.Invoke(newValue);
            onValueChanged?.Invoke(newValue);
        }
    }
}