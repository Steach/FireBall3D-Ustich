using UnityEngine;

namespace FireBall.Core
{
    public class ButtonShootAction : ActionBase
    {
        [SerializeField] private float _delay;
        [SerializeField] private float _currentDelay;
        public System.Action ShootButtonEvent;

        public override void Execute(object data = null)
        {
            if (_currentDelay > 0)
                _currentDelay -= Time.deltaTime;

            if (_currentDelay <= 0)
            {
                _currentDelay = _delay;
                ShootButtonEvent?.Invoke();
            }
        }
    }
}