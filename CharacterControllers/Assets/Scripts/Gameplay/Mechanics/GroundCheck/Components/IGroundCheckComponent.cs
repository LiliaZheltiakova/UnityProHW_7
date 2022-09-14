using UnityEngine;

namespace Gameplay
{
    public interface IGroundCheckComponent
    {
        bool IsGrounded { get; }
    }
}