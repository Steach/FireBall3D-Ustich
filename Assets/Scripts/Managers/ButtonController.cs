using UnityEngine;
using UnityEngine.UI;

namespace FireBall.Core.Managers
{
    public class ButtonController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [Space]
        [Header("Button Actions")]
        [SerializeField] private ActionBase _exitAction;
        [SerializeField] private ActionBase _restartAction;

        private void Awake()
        {
            _exitButton.onClick.AddListener(ExecuteExitButton);
            _restartButton.onClick.AddListener(ExecuteRestartButton);
        }

        private void ExecuteExitButton() => _exitAction.Execute();

        private void ExecuteRestartButton() => _restartAction.Execute();

    }
}