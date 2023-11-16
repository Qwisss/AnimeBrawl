using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyLocomotion))]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    [Header("Components")]
    public EnemyLocomotion EnemyLocomotion;

    [Header("Data")]
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;

    [SerializeField] private int _attackDamage = 10;
    [SerializeField] private float _attackCooldown = 1.2f;
    [SerializeField] private bool _isCooldown;

    public int Health
    { 
        get { return _currentHealth; }
        set
        {
            _currentHealth = value; if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }

        }
    }

    private void Awake()
    {
        tag = "Enemy";
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        _currentHealth = _maxHealth;
        EnemyLocomotion = GetComponent<EnemyLocomotion>();
        StartCoroutine(AttackCooldown());
    }

    private void Update()
    {
        if (_isCooldown == false)
        { 
            Attack();
   
        }
    }
    public virtual void TakeDamage(int damageValue)
    {
        Health -= damageValue;
    }

    public virtual void Attack()
    {
        StartCoroutine(AttackCooldown());
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator AttackCooldown()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_attackCooldown);
        _isCooldown = false;
    }
}
