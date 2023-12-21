using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(CharacterController))]
public class PlayerLocomotion : MonoBehaviour, IMovable
{
    [Header("Components")]
    [SerializeField] private Player _player;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private CharacterController _characterController;

    private Vector3 _move;
    private Vector2 _mouseLook;
    private Vector3 _rotationTarget;

    [Header("Bool")]
    public bool isPc;
    private bool _isMoving;
    public bool IsAttacking;

    [Header("Stats")]
    [Header("Move")]
    private int _speed;
    private int _rotationSpeed;

    [Header("Attack")]
    private int _attackDamage;
    private float _attackCooldown;
    [SerializeField] private bool _isCooldown;
    [SerializeField] private float animationFinishTime = 0.9f;
    public List<Enemy> targets = new List<Enemy>();

    public event Action OnMoveEvent;
    public event Action OnIdleEvent;
    public event Action OnAttackEvent;
    public event Action OnFightIdleEvent;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _characterController = GetComponent<CharacterController>();
        _animationController = GetComponent<AnimationController>();
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

    public void SetupConfiguration(int speed, int rotationSpeed,int attackDamage, float attackCooldown) 
    {
        _speed = speed;
        _rotationSpeed = rotationSpeed;
        _attackDamage = attackDamage;
        _attackCooldown = attackCooldown;
    }

    private void Update()
    {
        if (IsAttacking && _animationController.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= animationFinishTime)
        {
            IsAttacking = false;
            OnFightIdleEvent?.Invoke();
            if (_isMoving)
            {
                OnMoveEvent?.Invoke();
            }
        }

        if (isPc)
        {
            HandlePCMovement();
        }
        else
        {
            HandleJoystickMovement();
        }
    }

    public void Move(Vector3 move)
    {
        if(IsAttacking)
        {
           return;
        }

        _characterController.Move(move * Time.deltaTime * _speed);
        bool wasMoving = _isMoving;
        _isMoving = move.magnitude > 0.01f;
        if (_isMoving && !wasMoving)
        {
            OnMoveEvent?.Invoke(); 
        }
        else if (!_isMoving && wasMoving)
        {
            OnIdleEvent?.Invoke(); 
        }
    }

    #region PCMovement
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
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
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

    #region Rotate
    private void Rotate(Vector3 move)
    {
        if (move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
        }
    }
    #endregion

    #region Attack

    public void Attack()
    {
        if (!IsAttacking && !_isCooldown)
        {
            IsAttacking = true;
            OnAttackEvent?.Invoke();
            StartCoroutine(AttackCooldown());
            foreach (Enemy target in targets)
            {
                if (target != null)
                {
                    target.EnemyHealthSystem.TakeDamage(_attackDamage);
                    if (target == null)
                    {
                        targets.Remove(target);
                    }
                }
            }
        }
    }
    private IEnumerator AttackCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_attackCooldown);
        _isCooldown = false;
    }

    #endregion

    #region NewInputAction
    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector3>();
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        _mouseLook = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
    }
    #endregion
}
