using UnityEngine;
using System;
using System.Collections.Generic;

namespace Homework
{
    public abstract class StateMachine<TState> : MonoBehaviour, ISerializationCallbackReceiver where TState : Enum
    {
        [SerializeField] private List<StateInfo> state = new List<StateInfo>();

        [Serializable]
        public class StateInfo
        {
            public TState type;
            public State state;
        }

        private Dictionary<TState, State> statesMap = new Dictionary<TState, State>();
        private State currentState;

        public void GoToState(TState stateType)
        {
            if (!statesMap.TryGetValue(stateType, out var stateN))
            {
                Debug.LogError($"No such state {stateType}");
                return;
            }
            
            if(currentState != null)
                currentState.ExitState();



            currentState = stateN;
            stateN.EnterState();
        }

        private void Update()
        {
            if(currentState != null)
                currentState.UpdateState(Time.deltaTime);
        }

        public void OnBeforeSerialize() { }

        public void OnAfterDeserialize()
        {
            foreach (var stateInfo in state)
            {
                statesMap[stateInfo.type] = stateInfo.state;
            }
        }
    }
}