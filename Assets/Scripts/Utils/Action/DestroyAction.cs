using UnityEngine;

namespace FireBall.Core
{
    public class DestroyAction : ActionBase
    {
        public enum ToDestroy { Self, Collision, Trigger }

        [Space]
        [Header("Destroy object configuration")]
        [SerializeField] private ToDestroy _toDestroy;
        
        [Space]
        [Header("Configuration for self destroy")]
        [SerializeField] private bool _self;
        [SerializeField] private bool _parent;
        [SerializeField] private GameObject _parentObjectToDestoy;
        [SerializeField] private bool _withDelay;
        [SerializeField] private float _delay;

        [Space]
        [Header("Tags")]
        [SerializeField] private string _gameobjectTagToDestoy;
        [SerializeField] private string _gameobjectTagShiled;

        public override void Execute(object data = null)
        {
            if (data is GameObject objectToDestroy)
            {
                if (_toDestroy == ToDestroy.Self && _withDelay)
                {
                    Destroy(objectToDestroy, _delay);
                    return;
                }
            }

            if (data is Collision collision)
            {
                var tag = collision.gameObject.tag;

                if (_toDestroy == ToDestroy.Collision && tag == _gameobjectTagToDestoy)
                    Destroy(collision.gameObject);

                if (_toDestroy == ToDestroy.Self && _self)
                    Destroy(gameObject);

                if (_toDestroy == ToDestroy.Self && _parent)
                    Destroy(_parentObjectToDestoy);

                if(tag == _gameobjectTagShiled)
                    Destroy(_parentObjectToDestoy);
            }
        }
    }
}