using System;
using UnityEngine;

namespace InputSystem
{
    public interface IMoveInput
    {
        event Action<Vector2> OnMoveDirection;
        event Action OnMoveInputStopped;
        event Action OnCanceled;
        bool AnyArrowPressed { get; }
    }
}