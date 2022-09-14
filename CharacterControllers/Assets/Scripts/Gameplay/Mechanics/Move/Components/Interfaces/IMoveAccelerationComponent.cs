using System;
using UnityEngine;

namespace Gameplay
{
    public interface IMoveAccelerationComponent
    {
        event Action<float> OnAccelerationChanged;
        float Acceleration { get; }
        void SetAcceleration(float acceleration);
    }
}