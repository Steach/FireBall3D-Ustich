using UnityEngine;

namespace FireBall.Core.Player
{
    public class Inventory : MonoBehaviour
    {
        public System.Action<bool, bool> AmmoIsRunOut;
        public System.Action<int> AmmoIsChanged;

        [SerializeField] private int _ammo;

        private void Update()
        {
            if (_ammo <= 0)
                AmmoIsRunOut?.Invoke(true, false);
        }

        public int Ammo
        {
            get { return _ammo; } 
            private set { _ammo = value; }
        }

        public void AddAmmo(int newAmmo)
        {
            if (newAmmo > 0)
            {
                Ammo += newAmmo;
                AmmoIsChanged?.Invoke(Ammo);
            }
                
        }

        public int GetAmmo() { return Ammo; }

        public void SpendAmmo(int spendedAmmo)
        {
            if (spendedAmmo == 1 && Ammo > 0)
            {
                Ammo -= spendedAmmo;
                AmmoIsChanged?.Invoke(Ammo);
            }   
        }
    }
}