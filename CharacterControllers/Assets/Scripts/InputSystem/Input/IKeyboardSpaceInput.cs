using System;

namespace InputSystem
{
    public interface IKeyboardSpaceInput
    {
        event Action OnKeyDown;
        event Action OnKeyReleased;
        event Action OnKeyHold;
        event Action OnCanceled;
    }
}