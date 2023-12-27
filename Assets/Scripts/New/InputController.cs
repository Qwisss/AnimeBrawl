using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [Header("Components")]
    private Camera _camera;

    [Header("MousePosition")]
    [HideInInspector] public Vector3 MouseInputPosition;


    public event Action<float> OnCameraZoomScrollEvent;
    public event Action<Vector3> OnMoveClickEvent;
    public event Action OnAttackClickEvent;



    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        UpdateCurrentMousePosition();
    }


    private void UpdateCurrentMousePosition()
    {
        Ray ray = _camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            MouseInputPosition = hit.point;

        }

    }


    #region Actions

    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveClickEvent?.Invoke(MouseInputPosition);
       /* Vector2 mousePos = Mouse.current.position.ReadValue();*/
        //OnMoveClick?.Invoke(mousePos);
        /*        Ray ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue());

                if (Physics.RaycastNonAlloc(ray, _hits) > 0)
                {
                    Move();
                }*/
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        OnAttackClickEvent?.Invoke();
    }

    public void OnCameraZoom(InputAction.CallbackContext context)
    {
        Debug.Log("1");
        float scrollDelta = context.ReadValue<Vector2>().y;
        OnCameraZoomScrollEvent?.Invoke(scrollDelta);

    }

    #endregion
}
