using System;
using UnityEngine;

namespace Homework
{
    public class MoveHandler_StateMachineCall : MonoBehaviour
    {
        [SerializeField] private MoveMechanic moveMech;
        [SerializeField] private PlayerStateMachine playerStateMachine;

        private void OnEnable()
        {
            this.moveMech.OnStartMove += OnStartMove;
            this.moveMech.OnFinishMove += OnFinishMove;
        }

        private void OnDisable()
        {
            this.moveMech.OnStartMove -= OnStartMove;
            this.moveMech.OnFinishMove -= OnFinishMove;
        }

        private void OnStartMove()
        {
            playerStateMachine.GoToState(PlayerStateEnum.Move);
            //Debug.Log("Start");
        }

        private void OnFinishMove()
        {
            playerStateMachine.GoToState(PlayerStateEnum.Idle);
            //Debug.Log("Stop");
        }
    }
}