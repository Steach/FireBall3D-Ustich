using TMPro;
using UnityEngine;

namespace FireBall.Core.Managers
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        public void ChangeTimer(float time)
        {
            string formattedTime = time.ToString("0.00");
            _timerText.text = "Timer: " + formattedTime;
        } 
    }
}