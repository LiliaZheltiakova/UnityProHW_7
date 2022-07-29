using System.Collections.Generic;

namespace InputSystem
{
    public class _InputStateManager : IInputStateManager
    {
        public InputLayer CurrentLayer { get; private set; }
        private _InputStateList currentList;
        private readonly Dictionary<InputLayer, _InputStateList> stateLists;

        public _InputStateManager()
        {
            this.CurrentLayer = InputLayer.BASE;
            this.stateLists = new Dictionary<InputLayer, _InputStateList>
            {
                { InputLayer.NONE, new _InputStateList() },
                { InputLayer.BASE, new _InputStateList() },
                { InputLayer.TUTORIAL, new _InputStateList() }
            };
            this.currentList = this.stateLists[this.CurrentLayer];
        }
        

        public void AddState(InputLayer layer, IInputState state)
        {
            var stateList = this.stateLists[layer];
            stateList.AddSubstate(state);
        }

        public void RemoveLayer(InputLayer layer, IInputState state)
        {
            var stateList = this.stateLists[layer];
            stateList.RemoveSubstate(state);
        }

        public void ChangeLayer(InputLayer layer)
        {
            var previousLayer = this.CurrentLayer;
            var previousStateList = this.stateLists[previousLayer];
            previousStateList.ExitState();

            var currentStateList = this.stateLists[layer];
            currentStateList.EnterState();

            this.CurrentLayer = layer;
        }

        public void Update(float deltaTime)
        {
            var currentStateList = this.stateLists[this.CurrentLayer];
            currentStateList.UpdateState(deltaTime);
        }

        public void AddStates(InputLayer layer, IEnumerable<IInputState> states)
        {
            var stateList = this.stateLists[layer];
            foreach (var state in states)
            {
                stateList.AddSubstate(state);
            }
        }
    }
}