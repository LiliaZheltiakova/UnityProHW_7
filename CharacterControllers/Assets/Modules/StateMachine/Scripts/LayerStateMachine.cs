using System.Collections.Generic;

namespace StateMachine
{
    public sealed class LayerStateMachine<T>
    {
        private readonly Dictionary<T, StateList> layerLists;

        private T currentLayer;
        public T CurrentLayer => this.currentLayer;

        private StateList currenList;

        public LayerStateMachine()
        {
            this.layerLists = new Dictionary<T, StateList>();
        }

        public void AddState(T layer, IState state)
        {
            var list = this.GetOrCreateList(layer);
            list.AddSubstate(state);
        }

        public void AddStates(T layer, IEnumerable<IState> states)
        {
            var list = this.GetOrCreateList(layer);
            foreach (var state in states)
            {
                list.AddSubstate(state);
            }
        }

        public void RemoveState(T layer, IState state)
        {
            var group = this.GetOrCreateList(layer);
            group.RemoveSubstate(state);
        }

        public void ChangeState(T layer)
        {
            this.currenList?.ExitState();
            this.currenList = this.GetOrCreateList(layer);
            this.currenList.EnterState();
            this.currentLayer = layer;
        }

        public void Update(float deltaTime)
        {
            this.currenList?.UpdateState(deltaTime);
        }
        private StateList GetOrCreateList(T layer)
        {
            if (this.layerLists.TryGetValue(layer, out var group))
            {
                return group;
            }

            group = new StateList();
            this.layerLists.Add(layer, group);
            return group;
        }
    }
}