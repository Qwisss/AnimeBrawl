using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyLocomotion))]

public abstract class Enemy : PoolableObject, IDamageable
{
    [Header("Components")]
    public EnemyLocomotion EnemyLocomotion;
    public Animator animator;
    public EnemyScriptableObject EnemyScriptableObject;
    public NavMeshAgent Agent;
    protected HashAnimationNames _animBase = new HashAnimationNames();

    [Header("Bars")]
    [SerializeField] private BarBase _healthBar;

    [Header("Data")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

    [Range(1, 10)] public float Speed = 5f;
    [Range(100, 1000)] public float RotationSpeed = 750f;

    [SerializeField][Range(1, 100)] protected int _attackDamage = 10;
    [SerializeField] protected float _attackCooldown = 1.2f;
    [SerializeField] protected bool _isCooldown;
    public bool IsAttack;

    public int Health
    { 
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;

            if(_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }
            _healthBar.UpdateBar(_maxHealth, _currentHealth);
        }
    }

    public virtual void OnEnable()
    {
        SetupAgentFromConfiguration();
    }


    public virtual void SetupAgentFromConfiguration()
    {
        Agent.acceleration = EnemyScriptableObject.Acceleration;
        Agent.angularSpeed = EnemyScriptableObject.AngularSpeed;
        Agent.areaMask = EnemyScriptableObject.AreaMask;
        Agent.avoidancePriority = EnemyScriptableObject.AvoidancePriority;
        Agent.baseOffset = EnemyScriptableObject.BaseOffset;
        Agent.height = EnemyScriptableObject.Height;
        Agent.obstacleAvoidanceType = EnemyScriptableObject.obstacleAvoidanceType;
        Agent.radius = EnemyScriptableObject.Radius;
        Agent.speed = EnemyScriptableObject.Speed;
        Agent.stoppingDistance = EnemyScriptableObject.StoppingDistance;

        EnemyLocomotion.UpdateSpeed = EnemyScriptableObject.AIUpdateInterval;
        _maxHealth = EnemyScriptableObject.MaxHealth;
        Health = EnemyScriptableObject.CurrentHealth;
        
    }

    public virtual void TakeDamage(int damageValue)
    {
        if (damageValue <= 0)
        {
            damageValue = 0;
        }
        Health -= damageValue;
    }

    public virtual void Attack(Player target)
    {
        if (target == null || IsAttack == false)
        {
            StopCoroutine(AttackCooldown(target));
            return;
        }
        animator.CrossFade(_animBase.HightKick, 0.1f);
        target.TakeDamage(_attackDamage);
        StartCoroutine(AttackCooldown(target));
    }


    private IEnumerator AttackCooldown(Player target)
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_attackCooldown);
        _isCooldown = false;

        if (IsAttack)
        {
            Attack(target);
        }

    }

    public virtual void Die()
    {
        gameObject.SetActive(false);

    }

    public override void OnDisable()
    {
        base.OnDisable();

        Agent.enabled = false;
    }
}
