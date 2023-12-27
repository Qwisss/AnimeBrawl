
using UnityEngine;

public class EnemyHealthSystem : HealthSystemBase
{

    [SerializeField] new protected BarBase _healthBar;

    public override void Initialize()
    {

        _healthBar = GetComponent<EnemyHealthBar>();
    }
}
