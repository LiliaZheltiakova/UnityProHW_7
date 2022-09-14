using UnityEngine;

namespace Gameplay
{
    public class MoveDeccelerationComponent : MonoBehaviour, IMoveDecellerationComponent
    {
        [SerializeField] private MoveDeccelerationMechanic decclMech;
        public float Decceleration => this.decclMech.Decceleration;

        public void SetDecceleration(float decceleration)
        {
            this.decclMech.SetDecceleration(decceleration);
        }
    }
}