using UnityEngine;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
    [SerializeField] private Sprite _grandedStar512;
    [SerializeField] private Sprite _grandedStar1024;
    [SerializeField] private Sprite _ungrandedStar512;
    [SerializeField] private Sprite _ungrandedStar1024;
    [SerializeField] private Image[] _starsImage;

    public void CheckGameInvariable(bool chestStatus, bool ammoStatus, float gameTime)
    {
        if (!chestStatus && ammoStatus)
        {
            LooseGameZeroSrats();
            return;
        }

        if (chestStatus)
        {
            SetStarsSprites(gameTime);
            return;
        }
            

        if (chestStatus && ammoStatus)
        {
            SetStarsSprites(gameTime);
        }
    }

    private void SetStarsSprites(float time)
    {
        if (time <= 10)
            RewardThreeStars();

        if (time > 10 && time <= 20)
            RewardTwoStars();

        if (time > 20 && time <= 30)
            RewardOneStar();

        if (time > 30)
            LooseGameZeroSrats();
    }

    private void SetStarsSprites(bool ammoIsOut)
    {
        if (ammoIsOut)
        {
            LooseGameZeroSrats();
        }
    }

    private void RewardOneStar()
    {
        for (int i = 0; i < _starsImage.Length; i++)
        {
            if (i == 0)
            {
                _starsImage[i].sprite = _grandedStar1024;
                continue;
            }

            _starsImage[i].sprite = _ungrandedStar512;
        }
    }

    private void RewardTwoStars()
    {
        for (int i = 0; i < _starsImage.Length; i++)
        {
            if (i == 0)
            {
                _starsImage[i].sprite = _grandedStar1024;
                continue;
            }

            if (i == 1)
            {
                _starsImage[i].sprite = _grandedStar512;
                continue;
            }

            if (i == 2)
            {
                _starsImage[i].sprite = _ungrandedStar512;
            }
        }
    }

    private void RewardThreeStars()
    {
        for (int i = 0; i < _starsImage.Length; i++)
        {
            if (i == 0)
            {
                _starsImage[i].sprite = _grandedStar1024;
                continue;
            }

            _starsImage[i].sprite = _grandedStar512;
        }
    }

    private void LooseGameZeroSrats()
    {
        for (int i = 0; i < _starsImage.Length; i++)
        {
            if (i == 0)
            {
                _starsImage[i].sprite = _ungrandedStar1024;
                continue;
            }

            _starsImage[i].sprite = _ungrandedStar512;
        }
    }
}
