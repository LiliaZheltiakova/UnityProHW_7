using UnityEngine;

namespace Gameplay
{
    public class MoveVelocityPowerComponent : MonoBehaviour, IMoveVelocityPowerComponent
    {
        [SerializeField] private MoveVelocityPowerMechanic velPowerMech;
        public float VelocityPower => this.velPowerMech.VelocityPower;

        public void SetVelocityPower(float velPower)
        {
            this.velPowerMech.SetVelocityPower(velPower);
        }
    }
}