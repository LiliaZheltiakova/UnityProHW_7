using UnityEngine;
namespace Player
{
    [CreateAssetMenu(
        fileName = "PlayerAnimationInfo",
        menuName = "Player/New PlayerAnimationInfo"
        )]
    public class PlayerAnimationInfo : ScriptableObject
    {
        [SerializeField] public PlayerStateEnum animation;
        [Range(.1f, 5f)]
        [SerializeField] public float speed;
    }
}