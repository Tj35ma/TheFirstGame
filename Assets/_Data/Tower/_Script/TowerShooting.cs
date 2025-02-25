using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbtrast
{
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float shootSpeed = 0.1f;
    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;    
    [SerializeField] protected BulletCtrl bullet;
    [SerializeField] public int totalKill = 0;
    [SerializeField] public int killCount = 0;
    public int KillCount => killCount;  

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootSpeed);
    }

    protected void FixedUpdate()
    {
        this.Looking();        
        this.IsTargetDead();        
    }    

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;        
        Vector3 targetPosition = this.target.TowerTargetable.transform.position;        
        Vector3 direction = targetPosition - this.towerCtrl.Rotator.position;        
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        this.towerCtrl.Rotator.rotation = Quaternion.Lerp(this.towerCtrl.Rotator.rotation,targetRotation,Time.deltaTime * rotationSpeed);
    }
    

    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.target == null) return;

        FirePoint firePoint = this.GetFirePoint();
        BulletCtrl newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet, firePoint.transform.position);
        Vector3 rotatorDirection = this.towerCtrl.Rotator.transform.forward;
        newBullet.transform.forward = rotatorDirection;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoint[this.currentFirePoint];
        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.FirePoint.Count) this.currentFirePoint = 0;
        return firePoint;
    }

    protected virtual bool IsTargetDead()
    {
        if (this.target == null) return true;
        if (!this.target.EnemyDamageRecever.IsDead()) return false;
        this.killCount++;
        this.totalKill++;
        this.target = null;
        return true;
    }

    public virtual bool DeductKillCount(int count)
    {
        if (this.killCount < count) return false;
        this.killCount -= count;
        return true;
    }
}
