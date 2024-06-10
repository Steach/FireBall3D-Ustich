using UnityEngine;

namespace FireBall.Core.Managers
{
    public class RotateObstacle : MonoBehaviour
    {
        [Header("Turning")]
        [SerializeField] private float _turnSpeed;
        private float _startAngle = 0;
        [Space]
        [Header("Spawning")]
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private int numCubes = 20;
        [SerializeField] private float radius = 5f;
        [SerializeField] private Vector3 spawnOrigin = Vector3.zero;

        private void Start()
        {
            Spawning();
        }

        private void Update()
        {
            Turning();
        }

        private void Turning()
        {
            _startAngle += _turnSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(transform.rotation.x, _startAngle, transform.rotation.z);
        }

        private void Spawning()
        {
            for (int i = 0; i < numCubes; i++)
            {
                float angle = (i * 360f) / numCubes;
                float radians = angle * Mathf.Deg2Rad;
                Vector3 position = spawnOrigin + new Vector3(radius * Mathf.Cos(radians), spawnOrigin.y, radius * Mathf.Sin(radians));
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, this.transform);
                cube.transform.LookAt(spawnOrigin);
            }
        }
    }
}