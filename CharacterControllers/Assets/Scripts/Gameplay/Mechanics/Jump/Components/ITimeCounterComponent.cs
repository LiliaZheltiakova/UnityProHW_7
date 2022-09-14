namespace Gameplay
{
    public interface ITimeCounterComponent
    {
        float TimerCounter { get; }
        void ResetTimeCounter(float time);
        void UpdateTimeCounter(float deltaTime);
    }
}