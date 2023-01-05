using System;
using UnityEngine;

namespace InputSystem
{
    public class PauseInput : MonoBehaviour, IPauseInput
    {
        public event Action OnPauseInputPressed;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                this.OnPauseInputPressed?.Invoke();
            }
        }
    }
}