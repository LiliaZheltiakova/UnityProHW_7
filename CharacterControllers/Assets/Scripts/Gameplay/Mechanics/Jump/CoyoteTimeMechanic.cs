using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class CoyoteTimeMechanic : MonoBehaviour
    {
        [SerializeField] private float coyoteTime;
        public float CoyoteTime => this.coyoteTime;

        [SerializeField] private float lastJumpTime;
        public float LastJumpTime => this.lastJumpTime;

        public void SetoyoteTime(float time)
        {
            this.coyoteTime = time;
        }

        public void SetLastJumpTime(float time)
        {
            this.lastJumpTime = time;
        }
    }
}