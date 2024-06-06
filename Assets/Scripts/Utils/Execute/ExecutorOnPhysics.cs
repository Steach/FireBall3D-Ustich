using UnityEngine;

namespace FireBall.Core
{
    public class ExecutorOnPhysics : ExecutorBase
    {
        public enum State { Enter, Exit, Stay }

        [SerializeField] private State _state;
        [SerializeField] private bool _onCollision;
        [SerializeField] private bool _onTrigger;

        private void OnCollisionEnter(Collision collision)
        {
            if(_state == State.Enter && _onCollision)
                Execute(collision);
        }

        private void OnCollisionExit(Collision collision) 
        {
            if (_state == State.Exit && _onCollision)
                Execute(collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            if (_state == State.Stay && _onCollision)
                Execute(collision);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (_state == State.Enter && _onTrigger)
                Execute(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (_state == State.Exit && _onTrigger)
                Execute(other);
        }

        private void OnTriggerStay(Collider other)
        {
            if (_state == State.Stay && _onTrigger)
                Execute(other);
        }
    }
}