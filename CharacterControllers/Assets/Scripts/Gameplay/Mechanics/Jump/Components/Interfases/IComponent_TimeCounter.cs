namespace Gameplay
{
    public interface IComponent_TimeCounter
    {
        float TimerCounter { get; }
        void ResetTimeCounter(float time);
        void UpdateTimeCounter(float deltaTime);
    }
}