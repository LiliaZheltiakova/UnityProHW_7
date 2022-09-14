namespace Gameplay
{
    public interface IJumpForceComponent
    {
        float JumpForce { get; }
        void SetForce(float force);
    }
}