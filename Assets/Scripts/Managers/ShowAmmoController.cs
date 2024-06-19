using TMPro;
using UnityEngine;

namespace FireBall.Core.Managers
{
    public class ShowAmmoController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ammoText;

        public void ChangeUIAmmo(int count) => _ammoText.text = "Ammo: " + count.ToString();
    }
}