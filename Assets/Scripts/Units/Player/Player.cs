using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
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
    public Animator animator;
    public PlayerLocomotion PlayerLocomotion;

    [Header("Bars")]
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private ArmorBar _armorBar;
    [SerializeField] private ManaBar _manaBar;

    [Header("Lists")]
    public List<Upgrade> ActiveUpgrades = new List<Upgrade>();
    public List<Weapon> ActiveWeapon = new List<Weapon>();

    [Header("Data")]
    [Range(1, 10)][SerializeField] private float _speed = 5f;
    [Range(100, 1000)][SerializeField] private float _rotationSpeed = 750f;

    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _currentHealth;



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

    public float Speed
    {
        get 
        { 
            return _speed; 
        }
        private set
        { 
            Speed = value; 
        } 
    }

    public float RotationSpeed
    {
        get
        {
            return _rotationSpeed;
        }
        private set
        {
            RotationSpeed = value;
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

        if(_healthBar == null)
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

    public void TakeDamage(int damageValue)
    {
        if(damageValue <= 0)
        {
            damageValue = 0;
        }
        Health -= damageValue;
    }

/*    public void Attack()
    {
        if (!_isCooldown)
        {
            StartCoroutine(AttackCooldown());
            foreach (Enemy target in targets)
            {
                if (target != null)
                {
                    target.TakeDamage(_attackDamage);
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
    }*/

    public void Die()
    {
        Destroy(gameObject);
    }
}
