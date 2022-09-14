using System;
using UnityEngine;

namespace InputSystem
{
    public interface IKeyboardArrowsInput
    {
        event Action<Vector2> OnArrowDirection;
        event Action OnArrowReleased;
        event Action OnCanceled;
        bool AnyArrowPressed { get; }
    }
}