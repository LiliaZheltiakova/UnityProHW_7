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
        [SerializeField] private FloatMechanic speedMechanic;
        [SerializeField] private FloatMechanic accelerationMechanic;
        [SerializeField] private FloatMechanic deccelerationMechanic;
        [SerializeField] private FloatMechanic velPowerMechanic;

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
            float targetSpeed = direction.x * speedMechanic.Value;
            float speedDif = targetSpeed - rigidbody.velocity.x;
            float accelRate;

            if (Mathf.Abs(targetSpeed) > .01f)
            {
                accelRate = accelerationMechanic.Value;
            }
                

            else
            {
                accelRate = deccelerationMechanic.Value;
            }
                

            float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPowerMechanic.Value);

            rigidbody.AddForce(movement * direction);

            float scaleX = rigidbody.gameObject.transform.localScale.x;
            if (Mathf.Sign(scaleX) != Mathf.Sign(direction.x))
            {
                rigidbody.gameObject.transform.localScale = new Vector3(scaleX * -1f, 1f, 1f);
            }
        }
    }
}