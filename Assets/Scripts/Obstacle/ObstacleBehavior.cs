using UnityEngine;

namespace FireBall.Core.Obstacle
{
    public class ObstacleBehavior : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log($"Collision {collision.gameObject.name}");
        }
    }
}