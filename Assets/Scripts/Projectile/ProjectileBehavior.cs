using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Awake()
    {
        gameObject.transform.parent = null;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed);
    }
}
