using UnityEngine;

namespace Gameplay
{
    public class MoveSpeedComponent : MonoBehaviour, IMoveSpeedComponent
    {
        [SerializeField] private MoveSpeedMechanic moveMechanic;
        public float Speed => this.moveMechanic.Speed;

        void IMoveSpeedComponent.SetSpeed(float speed)
        {
            this.moveMechanic.SetSpeed(speed);
        }
    }
}