using Unity.VisualScripting;

namespace FireBall.Core
{
    public class PlayAnimationAction : ActionBase
    {
        public System.Action<int> AnimAction;
        public System.Action<bool> GameOver;
        public override void Execute(object data = null)
        {
            if (data is AnimExecutorOnPhysics.AnimationForExecute _animInformation)
            {

                var _Animator = _animInformation.Animator;
                var _AnimatorController = _animInformation.AnimatorController;
                var _AnimationClipShoot = _animInformation.AnimationClipShoot;
                var _AnimationClipOpen = _animInformation.AnimationClipOpen;
                var _Collision = _animInformation.Collision;
                var _Collider = _animInformation.Collider;
                var _Count = _animInformation.ShootCount;

                if (_Collision != null)
                {
                    AnimAction.Invoke(1);
                    _Count = _animInformation.ShootCount;

                    _Animator.runtimeAnimatorController = _AnimatorController;

                    if(_Count < 3)
                        _Animator.Play(_AnimationClipShoot.name);

                    if (_Count >= 3)
                    {
                        _Animator.Play(_AnimationClipOpen.name);
                        GameOver?.Invoke(true);
                    }
                }
            }
        }
    }
}