using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotion : MonoBehaviour, IMovable
{

    [SerializeField] private Player _player;
    [SerializeField] private Joystick _joystick;

    private Vector3 _move;
    private Vector2 _mouseLook;
    private Vector3 _rotationTarget;

    public bool isPc;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        if (_joystick == null)
        {
            _joystick = FindObjectOfType<Joystick>();
        }
    }

    private void Update()
    {
        if (isPc)
        {
            HandlePCMovement();
        }
        else
        {
            HandleJoystickMovement();
        }
    }
    #region PCMovement
    //need update
    private void HandlePCMovement()
    {
        _joystick.gameObject.SetActive(false);

        Vector3 move = new Vector3(_move.x, 0, _move.z);
        UpdateRotationTarget();

        Vector3 lookDirection = new Vector3(_rotationTarget.x, 0f, _rotationTarget.z);
        RotateTowardsTarget(lookDirection);

        Move(move);
    }
    private void UpdateRotationTarget()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(_mouseLook);

        if (Physics.Raycast(ray, out hit))
        {
            _rotationTarget = hit.point;
        }
    }

    private void RotateTowardsTarget(Vector3 lookDirection)
    {
        if (lookDirection != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _player.RotationSpeed * Time.deltaTime);
        }
    }

    #endregion  

    #region JoystickMovement

    private void HandleJoystickMovement()
    {
        _joystick.gameObject.SetActive(true);

        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        Move(move);
        Rotate(move);
    }

    #endregion

    private void Move(Vector3 move)
    {
        _player.characterController.Move(move * Time.deltaTime * _player.Speed);
    }

    private void Rotate(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _player.RotationSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector3>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }
}
