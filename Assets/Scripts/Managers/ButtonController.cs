using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FireBall.Core.Managers
{
    public class ButtonController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _shootButton;
        [Space]
        [Header("Button Actions")]
        [SerializeField] private ActionBase _exitAction;
        [SerializeField] private ActionBase _restartAction;
        [SerializeField] private ActionBase _shootAction;

        private bool _isButtonPressed = false;

        private void Awake()
        {
            _exitButton.onClick.AddListener(ExecuteExitButton);
            _restartButton.onClick.AddListener(ExecuteRestartButton);
        }

        private void Update()
        {
            if (_isButtonPressed)
                _shootAction.Execute();
        }

        public void TestOnPointerDown() => _isButtonPressed = true;

        public void TestOnPointerUp() => _isButtonPressed = false;

        private void ExecuteExitButton() => _exitAction.Execute();

        private void ExecuteRestartButton() => _restartAction.Execute();
    }
}