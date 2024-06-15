using UnityEditor.Animations;
using UnityEngine;

namespace FireBall.Core
{
    public class PlayAnimationAction : ActionBase
    {
        public override void Execute(object data = null)
        {
            if (data is AnimExecutorOnPhysics.AnimationForExecute _animInformation)
            {
                var _Animator = _animInformation.Animator;
                var _AnimatorController = _animInformation.AnimatorController;
                var _AnimationClip = _animInformation.AnimationClip;
                var _Collision = _animInformation.Collision;
                var _Collider = _animInformation.Collider;

                if (_Collision != null)
                {
                    _Animator.runtimeAnimatorController = _AnimatorController;
                    _Animator.Play(_AnimationClip.name);
                }
            }
        }
    }
}