using UnityEngine;

namespace Gameplay
{
    public interface IMoveComponent
    {
        void Move(Vector2 direction);
        void StopMove();
    }
}