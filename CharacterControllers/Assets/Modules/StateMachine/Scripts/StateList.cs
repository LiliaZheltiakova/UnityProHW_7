using System.Collections.Generic;

namespace StateMachine
{
    public sealed class StateList : IState
    {
        private readonly List<IState> states;
        private readonly List<IState> cache;

        private bool isEntered;
        public StateList()
        {
            this.states = new List<IState>();
            this.cache = new List<IState>();
        }

        public void EnterState()
        {
            this.isEntered = true;
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                var controller = this.states[i];
                controller.EnterState();
            }

        }

        public void ExitState()
        {
            for (int i = 0, count = this.states.Count; i < count; i++)
            {
                var controller = this.states[i];
                controller.ExitState();
            }
            this.isEntered = false;
        }

        public void UpdateState(float deltaTime)
        {
            this.cache.Clear();
            this.cache.AddRange(this.states);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var controller = this.cache[i];
                controller.UpdateState(deltaTime);
            }
        }

        public void AddSubstate(IState state)
        {
            this.states.Add(state);
            if (this.isEntered)
            {
                state.EnterState();
            }
        }

        public void RemoveSubstate(IState state)
        {
            this.states.Remove(state);
            state.ExitState();
        }
    }

}