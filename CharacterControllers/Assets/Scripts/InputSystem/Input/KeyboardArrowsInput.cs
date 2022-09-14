using System;
using UnityEngine;

namespace InputSystem
{
    public class KeyboardArrowsInput : MonoBehaviour, IKeyboardArrowsInput
    {
        public event Action<Vector2> OnArrowDirection;
        public event Action OnArrowReleased;
        public event Action OnCanceled;

        private bool anyArrowPressed;
        public bool AnyArrowPressed => this.anyArrowPressed;

        public void Update()
        {
            if(Input.GetButton("Horizontal"))
            {
                this.OnArrowDirection?.Invoke(new Vector2(Input.GetAxis("Horizontal"), 0f));
                this.anyArrowPressed = true;
            }

            if(!Input.GetButton("Horizontal"))
            {
                this.OnArrowReleased?.Invoke();
                this.anyArrowPressed = false;
            }
        }

        public void CancelInput()
        {
            this.OnCanceled?.Invoke();
            this.anyArrowPressed = false;
        }
    }
}