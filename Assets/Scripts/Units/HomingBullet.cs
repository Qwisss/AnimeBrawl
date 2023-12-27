using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    public AnimationCurve PositionCurve;
    private Coroutine HomingCoroutine;

    public override void Spawn(Vector3 forward, int damage, Transform target)
    {
        Damage = damage;
        Target = target;

        if (HomingCoroutine != null )
        {
            StopCoroutine(HomingCoroutine);
        }

        HomingCoroutine = StartCoroutine(FindTarget());

    }

    private IEnumerator FindTarget()
    {
        Vector3 startPosition = transform.position;
        float time = 0;

        while ( time < 1 ) 
        {
            transform.position = Vector3.Lerp(startPosition, Target.position + new Vector3(0, startPosition.y, 0), time);

            time += Time.deltaTime * MoveSpeed;

            yield return null;
        }
    }
}
