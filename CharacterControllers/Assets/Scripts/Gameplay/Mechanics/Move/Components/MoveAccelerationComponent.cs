using System;
using UnityEngine;

namespace Gameplay
{
    public class MoveAccelerationComponent : MonoBehaviour, IMoveAccelerationComponent
    {
        [SerializeField] private MoveAccelerationMechanic accelMech;

        public event Action<float> OnAccelerationChanged;

        public float Acceleration => this.accelMech.Acceleration;

        void IMoveAccelerationComponent.SetAcceleration(float acceleration)
        {
            this.accelMech.SetAcceleration(acceleration);
        }
    }
}