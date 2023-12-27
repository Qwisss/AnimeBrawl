using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Windows;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class PlayerLocomotion : MonoBehaviour, IMovable
{
    [Header("Components")]
    [SerializeField] private Player _player;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] private Camera Camera = null;

    [Header("Bool")]
    private bool _isMoving;
    public bool IsAttacking;

    [Header("Stats")]
    [Header("Move")]
    private float _speed;
    private float _rotationSpeed;
    private RaycastHit[] _hits = new RaycastHit[1];
    private AgentLinkMover LinkMover;

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
        _rigidbody = GetComponent<Rigidbody>();
        _animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        Agent = GetComponent<NavMeshAgent>();
        LinkMover = GetComponent<AgentLinkMover>();

/*        LinkMover.OnLinkStart += HandleLinkStart;
        LinkMover.OnLinkEnd += HandleLinkEnd;*/
    }

    public void SetupConfiguration(float speed, float rotationSpeed,int attackDamage, float attackCooldown) 
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

    }

    #region Move
    private void Move()
    {
        Agent.SetDestination(_hits[0].point);
    }

    #endregion  

    #region Rotate
    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = _speed * Time.deltaTime;

        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
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
        Ray ray = Camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.RaycastNonAlloc(ray, _hits) > 0)
        {
            Move();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Attack();
    }

    #endregion
}
