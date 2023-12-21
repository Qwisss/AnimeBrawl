
public class PlayerHealthSystem : HealthSystemBase
{
    public override void Initialize()
    {
        _healthBar = FindObjectOfType<HealthBar>();
    }

}
