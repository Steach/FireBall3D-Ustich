using UnityEngine;

namespace FireBall.Core.Obstacle
{
    public class ChestBehavior : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private void Awake()
        {
            _animator.StartPlayback();
        }
    }
}