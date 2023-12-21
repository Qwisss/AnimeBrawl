using UnityEngine;

public abstract class HealthSystemBase : MonoBehaviour, IDamageable
{
    [Header("Components")]
    [SerializeField] protected BarBase _healthBar;

    [Header("Value")]
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _currentHealth;

    public virtual int Health
    {
        get { return _currentHealth; }
        set
        {
            _currentHealth = value;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }
            _healthBar.UpdateBar(_maxHealth, _currentHealth);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        _healthBar = GetComponent<BarBase>();
    }

    public virtual void SetupConfiguration(int maxHealth, int currentHealth)
    {
        _maxHealth = maxHealth;
        Health = currentHealth;
    }

    public virtual void TakeDamage(int damageValue)
    {
        if (damageValue <= 0)
        {
            damageValue = 0;
        }
        Health -= damageValue;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
