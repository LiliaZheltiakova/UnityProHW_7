using UnityEngine;

namespace Gameplay
{
    public class Component_TimeCounter : MonoBehaviour, IComponent_TimeCounter
    {
        [SerializeField] private TimeCounterMechanic timeCounterMechanic;
        public float TimerCounter => this.timeCounterMechanic.TimeCounter;

        public void ResetTimeCounter(float time)
        {
            this.timeCounterMechanic.ResetTimeCounter(time);
        }

        public void UpdateTimeCounter(float deltaTime)
        {
            this.timeCounterMechanic.UpdateTimeCounter(deltaTime);
        }
    }
}