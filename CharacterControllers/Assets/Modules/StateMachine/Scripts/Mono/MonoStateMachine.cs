using System;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public abstract class MonoStateMachine<TState> : MonoBehaviour, ISerializationCallbackReceiver where TState : Enum
    {
        public TState CurrentState => this.mode;
        [SerializeField] private TState mode;

        [SerializeField] private StateInfo[] states = Array.Empty<StateInfo>();

        private Dictionary<TState, MonoState> stateMap;
        private MonoState currentState;
        private float deltaTime;

        public void ChangeState(TState state)
        {
            if (this.currentState != null)
            {
                this.currentState.ExitState();
            }

            this.currentState = this.stateMap[state];
            this.currentState.EnterState();
            this.mode = state;
        }

        private void Start()
        {
            this.deltaTime = Time.deltaTime;
            if (this.currentState == null)
            {
                this.currentState = this.stateMap[this.mode];
                this.currentState.EnterState();
            }
        }

        private void FixedUpdate()
        {
            this.currentState.UpdateState(this.deltaTime);
        }
        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.stateMap = new Dictionary<TState, MonoState>();
            foreach (var info in this.states)
            {
                this.stateMap[info.mode] = info.state;
            }
        }

        [Serializable]
        public struct StateInfo
        {
            [SerializeField] public TState mode;
            [SerializeField] public MonoState state;
        }
    }
}