using System;
using UnityEngine;

namespace InputSystem
{
    public class KeyboardESCInput : MonoBehaviour, IKeyboardESCInput
    {
        public event Action OnESCPressed;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                this.OnESCPressed?.Invoke();
            }
        }
    }
}