using UnityEngine;

namespace FireBall.Core.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameObject[] _gameOverScreen;
        [SerializeField] private ButtonController _buttonController;
        [SerializeField] private StarController _starController;

        private void Awake()
        {
            foreach (var screenObject in _gameOverScreen)
                screenObject.SetActive(false);

            _gameManager.GameOverWithTime += SetStars;
        }

        private void SetStars(float gameTime)
        {
            _starController.SetStarsSprites(gameTime);

            foreach (var screenObject in _gameOverScreen)
                screenObject.SetActive(true);
        }
    }
}