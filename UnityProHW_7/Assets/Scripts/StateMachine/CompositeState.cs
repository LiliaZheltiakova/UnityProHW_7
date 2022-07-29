using System.Collections.Generic;
using UnityEngine;

namespace Homework
{
    public class CompositeState : State
    {
        [SerializeField] private List<State> states = new List<State>();

        public override void EnterState()
        {
            foreach (var state in states)
            {
                state.EnterState();
            }
        }

        public override void ExitState()
        {
            foreach (var state in states)
            {
                state.ExitState();
            }
        }

        public override void UpdateState(float deltaTime)
        {
            foreach (var state in states)
            {
                state.UpdateState(deltaTime);
            }
        }
    }
}