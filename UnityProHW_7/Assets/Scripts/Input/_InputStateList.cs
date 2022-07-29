using System.Collections.Generic;

namespace InputSystem
{
    public class _InputStateList : IInputState
    {
        private readonly List<IInputState> substates;
        private bool isActive;

        public _InputStateList()
        {
            this.substates = new List<IInputState>();
        }

        public void AddSubstate(IInputState state)
        {
            this.substates.Add(state);
            if (this.isActive)
            {
                state.EnterState();
            }
        }

        public void RemoveSubstate(IInputState state)
        {
            this.substates.Remove(state);
        }
        public void EnterState()
        {
            this.isActive = true;
            foreach (var state in this.substates)
            {
                state.EnterState();
            }
        }

        public void ExitState()
        {
            foreach (var state in this.substates)
            {
                state.ExitState();
            }

            this.isActive = false;
        }

        public void UpdateState(float deltaTime)
        {
            foreach (var state in substates)
            {
                state.UpdateState(deltaTime);
            }
        }
    }
}