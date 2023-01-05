using System;
using UnityEngine;

namespace InputSystem
{
    public class MoveInput : MonoBehaviour, IMoveInput
    {
        public event Action<Vector2> OnMoveDirection;
        
        public event Action OnMoveInputStopped;
        
        public event Action OnCanceled;
        
        private bool anyArrowPressed;
        
        public bool AnyArrowPressed => this.anyArrowPressed;
        
        public void Update()
        {
            if(Input.GetButton("Horizontal"))
            {
                this.OnMoveDirection?.Invoke(new Vector2(Input.GetAxis("Horizontal"), 0f));
                this.anyArrowPressed = true;
            }

            if(!Input.GetButton("Horizontal"))
            {
                this.OnMoveInputStopped?.Invoke();
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