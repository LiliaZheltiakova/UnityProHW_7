namespace Gameplay
{
    public interface ICoyoteTimeComponent
    {
        float CoyoteTime { get; }
        float LastJumpTime { get; }

        void SetCoyoteTime(float time);
        void SetLastJumpTime(float time);
    }
}