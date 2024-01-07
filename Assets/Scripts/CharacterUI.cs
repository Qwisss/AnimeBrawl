using UnityEngine;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private HealthBar _healthBar;


    private void Awake()
    {
        if (_character == null)
        {
            _character = GetComponent<Character>();
        }
        if (_healthBar == null)
        {
            _healthBar = FindObjectOfType<HealthBar>();
        }
    }

    private void Update()
    {
        _healthBar.UpdateBar(_character._lifepool.MaxValue.Integer_value, _character._lifepool.CurrentValue);
    }
}
