using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyLocomotion))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [Header("Components")]
    public EnemyLocomotion EnemyLocomotion;


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

    private void Awake()
    {

    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        _currentHealth = _maxHealth;
        if (EnemyLocomotion == null)
        {
            EnemyLocomotion = GetComponent<EnemyLocomotion>();
        }
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
            print("dont attacking");
            StopCoroutine(AttackCooldown(target));
            return;
        }

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
            print("attacking");
            Attack(target);
        }

    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
