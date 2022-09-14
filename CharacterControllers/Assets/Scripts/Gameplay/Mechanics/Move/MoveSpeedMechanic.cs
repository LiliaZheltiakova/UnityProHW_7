using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class MoveSpeedMechanic : MonoBehaviour
    {
        public event Action<float> OnSpeedChanged;

        [SerializeField] private float speed;
        public float Speed => this.speed;

        [SerializeField] private UnityEvent<float> onSpeedChanged;

        public void SetSpeed(float speed)
        {
            this.speed = speed;
            this.OnSpeedChanged?.Invoke(speed);
            this.onSpeedChanged?.Invoke(speed);
        }
    }
}