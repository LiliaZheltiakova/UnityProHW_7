using System;
using UnityEngine;

namespace InputSystem
{
    public class JumpInput : MonoBehaviour, IJumpInput
    {
        public event Action OnKeyDown;
        public event Action OnKeyReleased;
        public event Action OnKeyHold;
        public event Action OnCanceled;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.OnKeyDown?.Invoke();
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                this.OnKeyReleased?.Invoke();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                this.OnKeyHold?.Invoke();
            }
        }

        public void CancelInput()
        {
            this.OnCanceled?.Invoke();
        }
    }
}