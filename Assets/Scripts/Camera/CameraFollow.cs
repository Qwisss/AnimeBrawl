using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] private float _smoothTime = 0.9f;
    [SerializeField] private Vector3 _offset = new Vector3(0 , 19, -7);

    private Vector3 _velocity = Vector3.zero;
    private CharacterMovement _target;

    [Header("Zoom")]
    [SerializeField] private InputController _inputController;
    private float _zoomSpeed = 0.01f;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;

    private void Start()
    {
        Initialize();

        _inputController.OnCameraZoomScrollEvent += Zoom;
    }

    private void Initialize()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<CharacterMovement>();
        }

        if (_inputController == null)
        {
            _inputController = FindObjectOfType<InputController>();
        }
        _maxZoom = _offset.y * 1.5f;
        _minZoom = _offset.y / 5f;
    }

    private void Update()
    {
        Follow();
    }

    #region Follow

    private void Follow()
    {
        if (_target != null)
        {
            Vector3 targetPosition = _target.transform.position + _offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
        }
    }

    #endregion

    #region Zoom

    private void Zoom(float delta)
    {
        Debug.Log("2");
        float zoomAmount = Mathf.Clamp(_offset.y - (delta * _zoomSpeed), _minZoom, _maxZoom);

        float zoomFactor = zoomAmount / _maxZoom;

        _offset.z = Mathf.Lerp(0f, -7f, zoomFactor);
        _offset.y = zoomAmount;
    }

    #endregion



}

