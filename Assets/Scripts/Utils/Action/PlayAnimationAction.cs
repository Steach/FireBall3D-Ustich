using UnityEngine;

namespace FireBall.Core
{
    public class PlayAnimationAction : ActionBase
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AnimationClip _animationClip;
        public override void Execute(object data = null)
        {
        }
    }
}