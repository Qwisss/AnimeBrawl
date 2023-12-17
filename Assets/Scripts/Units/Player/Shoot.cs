using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Bullet BulletPrefab;
    public int RateOfFire = 2;
    private ObjectPool BulletPool;

    private void Awake()
    {
        BulletPool = ObjectPool.CreateInstance(BulletPrefab, 100);
    }

    private void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / RateOfFire);

        while (true)
        {
            PoolableObject instance = BulletPool.GetObject();

            if (instance != null)
            {
                instance.transform.SetParent(transform, false);
                instance.transform.localPosition = Vector3.zero;
            }

            yield return Wait;
        }
    }

}
