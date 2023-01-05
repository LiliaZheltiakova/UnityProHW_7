using UnityEngine;

namespace Gameplay
{
    public interface IComponent_Move
    {
        void Move(Vector2 direction);
        void StopMove();
    }
}