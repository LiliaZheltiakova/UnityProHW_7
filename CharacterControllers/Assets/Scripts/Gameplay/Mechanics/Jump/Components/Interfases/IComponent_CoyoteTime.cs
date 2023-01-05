namespace Gameplay
{
    public interface IComponent_CoyoteTime
    {
        float CoyoteTime { get; }
        float LastJumpTime { get; }

        void SetCoyoteTime(float time);
        void SetLastJumpTime(float time);
    }
}