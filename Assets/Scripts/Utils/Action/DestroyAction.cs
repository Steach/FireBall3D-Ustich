using System.Collections;
using UnityEngine;

namespace FireBall.Core
{
    public class DestroyAction : ActionBase
    {
        public enum ToDestroy { Self, Collision, Trigger }

        [SerializeField] private ToDestroy _toDestroy;
        [SerializeField] private bool _withDelay;
        [SerializeField] private float _delay;

        [SerializeField] private GameObject _parentObjectToDestoy;
        [SerializeField] private bool _self;
        [SerializeField] private bool _parent;

        public override void Execute(object data = null)
        {
            if (data is GameObject objectToDestroy)
            {
                if (_toDestroy == ToDestroy.Self && _withDelay)
                {
                    Debug.Log("SelfDestroy");
                    Destroy(objectToDestroy, _delay);
                    return;
                }
            }

            if (data is Collision collision)
            {
                if (_toDestroy == ToDestroy.Collision)
                    Destroy(collision.gameObject);

                if (_toDestroy == ToDestroy.Self && _self)
                    Destroy(gameObject);

                if (_toDestroy == ToDestroy.Self && _parent)
                    Destroy(_parentObjectToDestoy);
            }
        }
    }
}