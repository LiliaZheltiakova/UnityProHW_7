using UnityEngine;

namespace Gameplay
{
    public class TimeCounterMechanic : MonoBehaviour
    {
        private float timeCounter = 0f;
        public float TimeCounter => this.timeCounter;

        public void ResetTimeCounter(float time)
        {
            this.timeCounter = time;
        }

        public void UpdateTimeCounter(float deltaTime)
        {
            this.timeCounter -= deltaTime;
            this.ResetTimeCounter(this.timeCounter);
        }
    }
}