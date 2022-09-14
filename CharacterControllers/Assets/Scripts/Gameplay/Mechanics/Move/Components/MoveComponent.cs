using UnityEngine;

namespace Gameplay
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private MoveMechanic moveMech;

        void IMoveComponent.Move(Vector2 direction)
        {
            this.moveMech.Move(direction);
        }

        void IMoveComponent.StopMove()
        {
            this.moveMech.StopMove();
        }
    }
}