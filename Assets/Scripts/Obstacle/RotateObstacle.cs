using UnityEngine;

namespace FireBall.Core.Managers
{
    public class RotateObstacle : MonoBehaviour
    {
        [Header("Turning")]
        private float _turnSpeed = 140;
        private float _startAngle = 0;
        [Space]
        [Header("Spawning")]
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private int numCubes = 20;
        [SerializeField] private float radius = 5f;
        [SerializeField] private Vector3 spawnOrigin = Vector3.zero;

        [Space]
        [Header("Changing Turn")]
        [SerializeField] private int _delay = 5;
        [SerializeField] private float _currentTimer;
        [SerializeField] private float _speedRange = 140f;
        [SerializeField] private float _newTurmSpeed;
        [SerializeField] private float _lerpSpeed;

        private void Start()
        {
            Spawning();
            _currentTimer = _delay;
        }

        private void Update()
        {
            ChangeTurnSpeed();
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

        private void ChangeTurnSpeed()
        {
            if (_currentTimer >= _delay)
                _newTurmSpeed = Random.Range(-_speedRange, _speedRange);

            if (_currentTimer >= 0)
            {
                _currentTimer -= Time.deltaTime;
                _turnSpeed = Mathf.Lerp(_turnSpeed, _newTurmSpeed, _lerpSpeed);
            }

            if (_currentTimer <= 0)
                _currentTimer = _delay;
        }
    }
}