using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbstract : TFGMonoBehaviour
{
    [SerializeField] protected EffectSpawner effectSpawner;
    [SerializeField] protected EffectPrefabs effectPrefabs;
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected void Update()
    {
        this.Attacking();
    }
    protected abstract void Attacking();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
        this.LoadEffectSpawner();
        this.LoadEffectPrefabs();
    }

    protected virtual void LoadEffectSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = GameObject.FindAnyObjectByType<EffectSpawner>();
        Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
    }

    protected virtual void LoadEffectPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        Debug.Log(transform.name + ": LoadEffectPrefabs", gameObject);
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
    protected virtual AttackPoint GetAttackPoint()
    {
        return this.playerCtrl.Weapons.GetCurrentWeapon().AttackPoint;
    }
}
