using UnityEngine;

public class EnemyHealthBar : BarBase
{

    private Camera _carema;

    public override void Iniatialize()
    {
        base.Iniatialize();

        _carema = Camera.main;
    }

    private void Update()
    {
        RotateToCamera();
    }

    private void RotateToCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _carema.transform.position);
    }



}
