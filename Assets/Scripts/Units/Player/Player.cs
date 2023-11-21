using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatType
{
    Speed,
    Damage, 
    AttackSpeed,
    AttackCooldown
}

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerLocomotion))]
public class Player : MonoBehaviour, IDamageable
{
    [Header("Components")]
    public CharacterController characterController;

    [Header("Bars")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ArmorBar _armorBar;
    [SerializeField] private ManaBar _manaBar;

    [Header("Lists")]
    public List<Upgrade> ActiveUpgrades = new List<Upgrade>();
    public List<Weapon> ActiveWeapon = new List<Weapon>();

    [Header("Data")]
    [Range(1, 10)] public float Speed = 5f;
    [Range(100, 1000)] public float RotationSpeed = 750f;

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
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        _currentHealth = _maxHealth;

        if (_healthBar == null)
        {
            _healthBar = FindObjectOfType<HealthBar>();
        }

        if (_armorBar == null)
        {
            _armorBar = FindObjectOfType<ArmorBar>();
        }

        if (_manaBar == null)
        {
            _manaBar = FindObjectOfType<ManaBar>();
        }

        _healthBar.UpdateBar(_maxHealth, _currentHealth);

    }

    public virtual void TakeDamage(int damageValue)
    {
        if(damageValue <= 0)
        {
            damageValue = 0;
        }
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
