using System;
using UnityEngine;

namespace InputSystem
{
    public interface IPauseInput
    {
        event Action OnPauseInputPressed;
    }
}