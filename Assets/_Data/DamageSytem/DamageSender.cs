using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public abstract class DamageSender : TFGMonoBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected Rigidbody rigid;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    public virtual void OnTriggerEnter(Collider collider)
    {
        DamageRecever damageRecever = collider.GetComponent<DamageRecever>();
        if (damageRecever == null) return;
        this.Send(damageRecever);
        Debug.Log("OnTriggerEnter: " + collider.name); 
    }

    protected virtual void Send(DamageRecever damageRecever)
    {
        damageRecever.Deduct(this.damage);
    }

    protected virtual void LoadRigidbody()
    {
        if (rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
}
