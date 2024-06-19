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
        [SerializeField] private Inventory _inventory;

        private InputSystem.PlayerInput _playerInput;

        public System.Action<bool> PlayerAtDestinationEvent;

        public bool PlayerAtDestination { get; private set; }
        private bool _sendEventAtOnse = true;
        private int _count = 0;

        private void Awake()
        {
            _playerInput = new InputSystem.PlayerInput();
            _agent.SetDestination(_posTransform.position);
            _playerInput.Controller.Shoot.performed += Shooting;
        }

        private void Update()
        {
            if (_sendEventAtOnse && _count < 1)
            {
                if (!_agent.hasPath)
                {
                    _count =+ 1;
                    PlayerAtDestination = true;
                    PlayerAtDestinationEvent?.Invoke(PlayerAtDestination);
                }
            }
            
        }

        private void Shooting(InputAction.CallbackContext callback)
        {
            if (!_agent.hasPath && _inventory.GetAmmo() > 0)
            {
                _spawnInfo._startPosition = _spawnInfo._parentObject.transform.position;
                _executor.Execute(_spawnInfo);
                _inventory.SpendAmmo(1);
            }
        }

        private void OnEnable() => _playerInput.Enable();
        private void OnDisable() => _playerInput.Disable();
    }
}