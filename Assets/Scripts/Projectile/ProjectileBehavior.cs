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

        private void Awake()
        {
            _actionDestroyAfterTime.Execute(gameObject);
            gameObject.transform.parent = null;
            _executorBase.Execute();
        }
    }
}