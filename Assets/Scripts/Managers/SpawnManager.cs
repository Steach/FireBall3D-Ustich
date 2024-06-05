using System;
using UnityEngine;

namespace FireBall.Core.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private ExecutorBase _executor;
        [Space]
        [Header("Spawn Configuration")]
        [SerializeField] private SpawnInformation _spawnInformation;

        private void Start()
        {
            _executor.Execute(_spawnInformation);
        }

        [Serializable]
        public struct SpawnInformation
        {
            public Vector3 _startPosition;
            public float _stepSpawn;
            public int _countSpawn;
            public GameObject _prefabToSpawn;
            public GameObject _parentObject;
        }
    }
}