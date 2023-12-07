using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private float smoothTime = 0.9f;
    [SerializeField] private Vector3 _offset;

    private Vector3 _velocity = Vector3.zero;
    private Player _target;

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<Player>();
        }
    }

    private void Update()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.transform.position + _offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);
        }
    }
}

