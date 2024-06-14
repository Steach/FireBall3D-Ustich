using UnityEngine;

namespace FireBall.Core.Obstacle
{
    public class ChestBehavior : MonoBehaviour
    {
        [SerializeField] private ExecutorOnPhysics _executorOnPhysics;
        [SerializeField] private AnimationClip _openChest;
        [SerializeField] private AnimationClip _shootChest;
    }
}