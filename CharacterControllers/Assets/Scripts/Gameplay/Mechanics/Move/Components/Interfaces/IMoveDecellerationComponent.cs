namespace Gameplay
{
    public interface IMoveDecellerationComponent
    {
        float Decceleration { get; }
        void SetDecceleration(float decceleration);
    }
}