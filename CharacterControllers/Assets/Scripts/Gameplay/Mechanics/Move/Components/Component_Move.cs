using UnityEngine;

namespace Gameplay
{
    public class Component_Move : MonoBehaviour, IComponent_Move
    {
        [SerializeField] private MoveMechanic moveMech;

        void IComponent_Move.Move(Vector2 direction)
        {
            this.moveMech.Move(direction);
        }

        void IComponent_Move.StopMove()
        {
            this.moveMech.StopMove();
        }
    }
}