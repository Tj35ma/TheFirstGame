using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 0.5f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        this.bulletCtrl = GetComponentInParent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }
    protected override void Send(DamageRecever damageRecever)
    {
        base.Send(damageRecever);
        this.bulletCtrl.Despawn.DoDespawn();
    }
}
