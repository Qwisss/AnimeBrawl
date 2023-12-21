
public class EnemyHealthSystem : HealthSystemBase
{

    new protected EnemyHealthBar _healthBar;

    public override void Initialize()
    {

        _healthBar = GetComponent<EnemyHealthBar>();
    }
}
