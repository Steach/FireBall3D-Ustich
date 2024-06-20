using FireBall.Core.Player;
using UnityEngine;

namespace FireBall.Core.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Inventory _playerInventory;
        [Space]
        [SerializeField] private GameObject[] _gameOverScreen;
        [SerializeField] private GameObject[] _gamePlayObjects;
        [Space]
        [Header("Controllers")]
        [SerializeField] private ButtonController _buttonController;
        [SerializeField] private StarController _starController;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private ShowAmmoController _showAmmoController;

        private void Awake()
        {
            SetActiveOrInactiveObjects(false, _gameOverScreen);
            SetActiveOrInactiveObjects(true, _gamePlayObjects);
            _showAmmoController.ChangeUIAmmo(_playerInventory.GetAmmo());

            _gameManager.IsGameOverEvent += SetStars;

            _gameManager.ChangeTimeEvent += ChangeTimer;
            _playerInventory.AmmoIsChanged += ChangeAmmoUI;
        }

        private void SetStars(bool ChestStatus, bool AmmoStatus, float gameTime)
        {
            _starController.CheckGameInvariable(ChestStatus, AmmoStatus, gameTime);
            SetActiveOrInactiveObjects(true, _gameOverScreen);
            SetActiveOrInactiveObjects(false, _gamePlayObjects);
        }

        private void ChangeTimer(float time) => _timerController.ChangeTimer(time);

        private void ChangeAmmoUI(int ammoCount) => _showAmmoController.ChangeUIAmmo(ammoCount);

        private void SetActiveOrInactiveObjects(bool _state, GameObject[] objects)
        {
            foreach (var obj in objects)
                obj.SetActive(_state);
        }
    }
}