using System;
using UnityEngine;

namespace Homework
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Vector2> OnInput;
        [SerializeField] private MoveMechanic moveMech;

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                //this.OnInput?.Invoke(Vector2.left);
                this.moveMech.Move(Vector2.left);
            }
            
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                //this.OnInput?.Invoke(Vector2.right);
                this.moveMech.Move(Vector2.right);
            }

            if (!Input.GetKey(KeyCode.RightArrow)
                && !Input.GetKey(KeyCode.D)
                && !Input.GetKey(KeyCode.LeftArrow)
                && !Input.GetKey(KeyCode.A))
            {
                this.moveMech.StopMove();
            }
        }
    }
}