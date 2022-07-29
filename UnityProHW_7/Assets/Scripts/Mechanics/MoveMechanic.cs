using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Events;

namespace Homework
{
    public class MoveMechanic : MonoBehaviour
    {
        public event Action OnStartMove;
        public event Action OnFinishMove;

        [SerializeField] private bool isMoving;
        public bool IsMoving => this.isMoving;

        [SerializeField] private bool finishMove;

        [SerializeField] private Vector2 direction;
        public Vector2 Direction => this.direction;

        [Header("Events")] 
        [SerializeField] private UnityEvent onStartMove;
        [SerializeField] private UnityEvent onFinishMove;
        
        public void Move(Vector2 direction)
        {
            this.direction = direction;
            this.finishMove = false;

            if (!this.isMoving)
            {
                isMoving = true;
                this.onStartMove?.Invoke();
                this.OnStartMove?.Invoke();
            }
        }

        public void StopMove()
        {
            this.finishMove = true;
        }

        private void FixedUpdate()
        {
            if (!this.isMoving)
                return;

            if (this.finishMove)
            {
                this.isMoving = false;
                this.onFinishMove?.Invoke();
                this.OnFinishMove?.Invoke();
            }
            //this.finishMove = true;
        }
    } 
}