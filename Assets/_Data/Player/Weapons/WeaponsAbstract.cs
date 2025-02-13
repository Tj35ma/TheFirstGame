using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponsAbstract : TFGMonoBehaviour
{
    [SerializeField] protected AttackPoint attackPoint;
    public AttackPoint AttackPoint => attackPoint;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttackPoint();
    }

    protected virtual void LoadAttackPoint()
    {
        if (this.attackPoint != null) return;
        this.attackPoint = GetComponentInChildren<AttackPoint>();
        Debug.Log(transform.name + ": LoadAttackPoint", gameObject);
    }
}
