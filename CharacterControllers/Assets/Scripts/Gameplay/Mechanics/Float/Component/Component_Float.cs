using UnityEngine;

namespace Gameplay
{
    public class Component_Float : MonoBehaviour, IComponent_GetFloat, IComponent_SetFloat
    {
        [SerializeField] private FloatMechanic floatMechanic;
        public float Value => this.floatMechanic.Value;
        
        public void SetValue(float newValue)
        {
            this.floatMechanic.SetValue(newValue);
        }
    }
}