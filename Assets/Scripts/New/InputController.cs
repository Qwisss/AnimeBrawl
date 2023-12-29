using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [Header("Components")]
    private Camera _camera;

    [Header("MousePosition")]
    [HideInInspector] public Vector3 MouseInputPosition;
    Ray _ray;
    RaycastHit _hit;

    private GameObject _currentHoverOverObject;

    public event Action<float> OnCameraZoomScrollEvent;
    public event Action<Vector3> OnMoveClickEvent;
    public event Action OnLeftClickEvent;
    public event Action<RaycastHit> OnInteractableObjectEvent;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Start()
    {

        StartCoroutine(UpdateTimer());
    }

    private void UpdateCurrentMousePosition()
    {
        _ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(_ray, out _hit, float.MaxValue))
        {
            MouseInputPosition = _hit.point;
            if (_currentHoverOverObject != _hit.transform.gameObject)
            {
                _currentHoverOverObject = _hit.transform.gameObject;
                OnInteractableObjectEvent?.Invoke(_hit);
            }
        }
    }

    #region Actions

    public void OnRightClick(InputAction.CallbackContext context)
    {
        OnMoveClickEvent?.Invoke(MouseInputPosition);
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        OnLeftClickEvent?.Invoke();
    }

    public void OnScroll(InputAction.CallbackContext context)
    {
        float scrollDelta = context.ReadValue<Vector2>().y;

        OnCameraZoomScrollEvent?.Invoke(scrollDelta);

    }

    #endregion


    private IEnumerator UpdateTimer()
    {
        WaitForSeconds Wait = new WaitForSeconds(DataConfig.UpdateRate);

        while (true)
        {
            UpdateCurrentMousePosition();

            yield return Wait;
        }

    }
}
