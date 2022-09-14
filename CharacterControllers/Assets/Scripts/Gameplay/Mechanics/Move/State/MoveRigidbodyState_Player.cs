using UnityEngine;
using StateMachine;

namespace Gameplay
{
    public class MoveRigidbodyState_Player : MonoState
    {
        [SerializeField] private MoveMechanic moveMechanic;
        [SerializeField] private Rigidbody2D rigidbody;

        [Space]
        [Header("Move values")]
        [SerializeField] private MoveSpeedMechanic speedMechanic;
        [SerializeField] private MoveAccelerationMechanic accelerationMechanic;
        [SerializeField] private MoveDeccelerationMechanic deccelerationMechanic;
        [SerializeField] private MoveVelocityPowerMechanic velPowerMechanic;

        public override void UpdateState(float deltaTime)
        {
            this.UpdateMove(deltaTime);
        }

        private void UpdateMove(float deltaTime)
        {
            if (!this.moveMechanic.IsMoving)
            {
                return;
            }
                

            var direction = this.moveMechanic.Direction;
            float targetSpeed = direction.x * speedMechanic.Speed;
            float speedDif = targetSpeed - rigidbody.velocity.x;
            float accelRate;

            if (Mathf.Abs(targetSpeed) > .01f)
            {
                accelRate = accelerationMechanic.Acceleration;
            }
                

            else
            {
                accelRate = deccelerationMechanic.Decceleration;
            }
                

            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPowerMechanic.VelocityPower);

            rigidbody.AddForce(movement * direction);

            float scaleX = rigidbody.gameObject.transform.localScale.x;
            if (Mathf.Sign(scaleX) != Mathf.Sign(direction.x))
            {
                rigidbody.gameObject.transform.localScale = new Vector3(scaleX * -1f, 1f, 1f);
            }
        }
    }
}