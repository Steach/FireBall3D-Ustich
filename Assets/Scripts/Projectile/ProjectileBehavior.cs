using UnityEngine;

namespace FireBall.Core.Projectile
{
    public class ProjectileBehavior : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private ActionBase _actionDestroyAfterTime;
        [SerializeField] private ExecutorOnPhysics _executor;

        private void Awake()
        {
            _actionDestroyAfterTime.Execute(gameObject);
            gameObject.transform.parent = null;
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed);
        }
    }
}