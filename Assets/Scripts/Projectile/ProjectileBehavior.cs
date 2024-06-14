using UnityEngine;

namespace FireBall.Core.Projectile
{
    public class ProjectileBehavior : MonoBehaviour
    {
        [Header("Awake Action")]
        [SerializeField] private ActionBase _actionDestroyAfterTime;
        [Space]
        [Header("Executors")]
        [SerializeField] private ExecutorBase _executorBase;
        [SerializeField] private ExecutorOnPhysics _executorPhysics;
        [Space]
        [Header("Position settings")]
        [SerializeField] private Vector3 _startPosition;

        private void Awake()
        {
            _actionDestroyAfterTime.Execute(gameObject);
            gameObject.transform.parent = null;
            gameObject.transform.position = new Vector3(transform.position.x, _startPosition.y, transform.position.z);
            _executorBase.Execute();
        }
    }
}