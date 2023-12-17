using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public ObjectPool Parent;

    public virtual void OnDisable()
    {
        Debug.Log("Return To Pool");
        Parent.ReturnObjectToPool(this);
    }
}
