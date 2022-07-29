using UnityEngine;

namespace Homework
{
    public class MoveComponent : MonoBehaviour, IMoveComponent
    {
        [SerializeField] private MoveMechanic moveMech;

        void IMoveComponent.Move(Vector2 direction)
        {
            this.moveMech.Move(direction);
        }
    }
}