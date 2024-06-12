using UnityEngine;

namespace FireBall.Core
{
    public class PhysicMoveAction : ActionBase
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private Rigidbody _rb;
        public override void Execute(object data = null)
        {
            _rb.AddForce(Vector3.fwd * _moveSpeed * Time.deltaTime, ForceMode.Impulse);
            //_rb.velocity = new Vector3(0, 0, _moveSpeed * Time.deltaTime);
        }
    }
}
