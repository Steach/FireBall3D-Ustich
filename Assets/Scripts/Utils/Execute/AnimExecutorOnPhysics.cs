using UnityEngine;

namespace FireBall.Core
{
    public class AnimExecutorOnPhysics : ExecutorBase
    {
        public enum State { Enter, Exit, Stay }

        [SerializeField] private State _state;
        [SerializeField] private bool _onCollision;
        [SerializeField] private bool _onTrigger;

        [Space]
        [SerializeField] private AnimationForExecute _animationForExecute;
        [Space]
        [Header("Invoke Action")]
        [SerializeField] private PlayAnimationAction _playAnimationAction;

        private void Awake()
        {
            _animationForExecute.ShootCount = 0;
            _playAnimationAction.AnimAction += AddShootCount;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_state == State.Enter && _onCollision)
            {
                _animationForExecute.Collision = collision;
                Execute(_animationForExecute);
            }
        }

        private void OnCollisionExit(Collision collision) 
        {
            if (_state == State.Exit && _onCollision)
            {
                _animationForExecute.Collision = collision;
                Execute(_animationForExecute);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (_state == State.Stay && _onCollision)
            {
                _animationForExecute.Collision = collision;
                Execute(_animationForExecute);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_state == State.Enter && _onTrigger)
            {
                _animationForExecute.Collider = other;
                Execute(_animationForExecute);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (_state == State.Exit && _onTrigger)
            {
                _animationForExecute.Collider = other;
                Execute(_animationForExecute);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (_state == State.Stay && _onTrigger)
            {
                _animationForExecute.Collider = other;
                Execute(_animationForExecute);
            }
        }

        private void AddShootCount(int i)
        {
            _animationForExecute.ShootCount += i;
        }

        [System.Serializable]
        public struct AnimationForExecute
        {
            public Animator Animator;
            public UnityEditor.Animations.AnimatorController AnimatorController;
            public AnimationClip AnimationClipOpen;
            public AnimationClip AnimationClipShoot;
            public Collision Collision;
            public Collider Collider;
            public int ShootCount;
        }
    }
}