using System;
using System.Linq;
using UnityEngine;

namespace InputSystem
{
    public class InputStateManager : MonoBehaviour, IInputStateManager
    {
        public InputLayer CurrentLayer
        {
            get
            { return this.stateManager.CurrentLayer; }
        }

        [SerializeField] private InputLayer currentLayer;
        [SerializeField] private LayerList[] lists;
        
        [Serializable]
        private struct LayerList
        {
            [SerializeField] public InputLayer layer;
            [SerializeField] public MonoBehaviour[] states;
        }

        private readonly _InputStateManager stateManager;

        public InputStateManager()
        {
            this.stateManager = new _InputStateManager();
        }

        private void Awake()
        {
            foreach (var list in this.lists)
            {
                var states = list.states.Select(it => (IInputState)it);
                this.stateManager.AddStates(list.layer, states);
            }
        }

        private void Start()
        {
            this.stateManager.ChangeLayer(this.currentLayer);
        }

        private void Update()
        {
            this.stateManager.Update(Time.deltaTime);
        }
        
        public void AddState(InputLayer layer, IInputState state)
        {
            this.stateManager.AddState(layer,state);
        }

        public void RemoveLayer(InputLayer layer, IInputState state)
        {
            this.stateManager.RemoveLayer(layer, state);
        }

        public void ChangeLayer(InputLayer layer)
        {
            this.currentLayer = layer;
            this.stateManager.ChangeLayer(layer);
        }
    }
}