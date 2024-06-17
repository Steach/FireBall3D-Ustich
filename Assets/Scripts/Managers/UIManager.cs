using UnityEngine;

namespace FireBall.Core.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject _gameOverScreen;
        [SerializeField] private ButtonController _buttonController;
        [SerializeField] private StarController _starController;

        private void Awake()
        {
            _gameOverScreen.SetActive(false);
            _gameManager.GameOverWithTime += SetStars;
        }

        private void SetStars(float gameTime)
        {
            _starController.SetStarsSprites(gameTime);
            _gameOverScreen.SetActive(true);
        }
    }
}