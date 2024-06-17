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
        public System.Action<float> GameOverWithTime;

        public bool IsGameOver { get; private set; }

        private void Awake()
        {
            IsGameOver = false;
        }

        public void Init(PlayAnimationAction action)
        {

            _playAnimationAction = action;
            _playAnimationAction.GameOver += GameOver;
        }

        private void Update()
        {
            if(!IsGameOver)
                _gameTime += Time.deltaTime;
        }

        private void GameOver(bool _isGameOver)
        {
            IsGameOver = _isGameOver;
            Debug.Log(IsGameOver);
            GameOverWithTime.Invoke(_gameTime);
        }
    }
}