using FireBall.Core.Player;
using UnityEngine;

namespace FireBall.Core.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("Managers")]
        [SerializeField] private UIManager _uiManager;
        [SerializeField] private SpawnManager _towerSpawnManager;
        [Space]
        [Header("Game Settings")]
        [SerializeField] private float _gameTime;
        [Space]
        [Header("System Actions")]
        [SerializeField] private PlayAnimationAction _playAnimationAction;
        [SerializeField] private Inventory _playerInventory;
        [SerializeField] private PlayerMovement _playerMovement;

        public System.Action<float> GameOverWithTime;
        public System.Action<bool> GameOverByAmmoEvent;
        public System.Action<float> ChangeTimeEvent;

        public System.Action<bool, bool, float> IsGameOverEvent;

        public bool IsGameOver { get; private set; }
        private bool _crashTheChest = false;
        private bool _ammoIsRunOut = false;
        private bool _playerAtDistantion = false;

        private void Awake()
        {
            IsGameOver = false;
            _crashTheChest = false;
            _playerInventory.AmmoIsChanged += GetAmmoCount;
            _playerMovement.PlayerAtDestinationEvent += CheckPlayer;
        }

        public void Init(PlayAnimationAction action)
        {
            _playAnimationAction = action;
            _playAnimationAction.GameOver += GetCrashedChestState;
        }

        private void Update()
        {
            ChangeTime();
            GameStatus();
        }

        private void ChangeTime()
        {
            if (!IsGameOver && _playerAtDistantion)
            {
                _gameTime += Time.deltaTime;
                ChangeTimeEvent?.Invoke(_gameTime);
            } 
        }

        private void GetAmmoCount(int ammoCount)
        {
            if (ammoCount <= 0)
            {
                _ammoIsRunOut = true;
                Debug.Log($"Ammo is runout = {_ammoIsRunOut}");
            }  
        }

        private void GetCrashedChestState(bool _chestIsCrashed) => _crashTheChest = _chestIsCrashed;

        private void GameStatus()
        {
            if (_crashTheChest || _ammoIsRunOut)
                IsGameOver = true;


            if (IsGameOver)
                IsGameOverEvent?.Invoke(_crashTheChest, _ammoIsRunOut, _gameTime);
                
        }

        private void CheckPlayer(bool _isAtDist)
        {
            _playerAtDistantion = _isAtDist;
        }
    }
}