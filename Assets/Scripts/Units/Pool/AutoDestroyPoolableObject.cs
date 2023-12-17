
public class AutoDestroyPoolableObject : PoolableObject
{
    public float AutoDestroyTime = 5;
    private const string DisableMetodName = "Disable";

    public virtual void OnEnable()
    {
        CancelInvoke(DisableMetodName);
        Invoke(DisableMetodName, AutoDestroyTime);
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }

}
