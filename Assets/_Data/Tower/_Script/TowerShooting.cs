using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbtrast
{
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected float rotationSpeed = 2f;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), 1f);
    }

    protected void FixedUpdate()
    {
        this.LookingAtTarget();
        //this.ShootAtTarget();
        //this.TargetLoading();
    }

    protected virtual void LookingAtTarget()
    {
        if (this.target == null) return;
        
        Vector3 targetPosition = this.target.TowerTargetable.transform.position;
        
        Vector3 direction = targetPosition - this.towerCtrl.Rotator.position;
        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        this.towerCtrl.Rotator.rotation = Quaternion.Lerp(this.towerCtrl.Rotator.rotation,targetRotation,Time.deltaTime * rotationSpeed);
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), 1f);
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }
}
