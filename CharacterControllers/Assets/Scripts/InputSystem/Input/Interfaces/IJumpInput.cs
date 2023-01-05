using System;

namespace InputSystem
{
    public interface IJumpInput
    {
        event Action OnKeyDown;
        event Action OnKeyReleased;
        event Action OnKeyHold;
        event Action OnCanceled; 
    }
}