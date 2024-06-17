using FireBall.Core.Managers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace FireBall.Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private Transform _posTransform;
        [SerializeField] private NavMeshAgent _agent;
        [Space]
        [Header("Shooting")]
        [SerializeField] private ExecutorBase _executor;
        [SerializeField] SpawnManager.SpawnInformation _spawnInfo;

        private InputSystem.PlayerInput _playerInput;

        private void Awake()
        {
            _playerInput = new InputSystem.PlayerInput();
            _agent.SetDestination(_posTransform.position);
            _playerInput.Controller.Shoot.performed += Shooting;
        }

        private void Shooting(InputAction.CallbackContext callback)
        {
            if (!_agent.hasPath)
            {
                _spawnInfo._startPosition = _spawnInfo._parentObject.transform.position;
                _executor.Execute(_spawnInfo);
            }
        }

        private void OnEnable() => _playerInput.Enable();
        private void OnDisable() => _playerInput.Disable();
    }
}