using UnityEngine;

namespace FireBall.Core.Camera
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private float _followSpeed;
        [SerializeField] private Vector3 _offset;

        private void Update()
        {
            var cameraPosition = transform.position;
            var targetPosition = _target.transform.position + _offset;
            transform.position = Vector3.Lerp(cameraPosition, targetPosition, _followSpeed);
        }
    }
}