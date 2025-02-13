using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]

public class EnemyDamageRecever : DamageRecever
{
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.center = new Vector3(0f, 1.37f, -0.04f);
        this.capsuleCollider.radius = 0.4f;
        this.capsuleCollider.height = 3f;
        Debug.Log(transform.name + ": LoadCapsuleCollider", gameObject);
    }

    protected virtual void LoadEnemyCtrl()
    {

        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.enemyCtrl.Animator.SetBool("isDead", this.isDead);
        this.capsuleCollider.enabled = false;
        this.RewardOnDead();
        Invoke(nameof(this.Disappear), 3f);
    }

    protected override void OnHurt()
    {
        base.OnHurt();
        this.enemyCtrl.Animator.SetTrigger("isHurt");
    }

    protected virtual void Disappear()
    {
        this.enemyCtrl.Despawn.DoDespawn();
    }

    protected override void OnReborn()
    {
        base.OnReborn();
        this.capsuleCollider.enabled = true;
    }

    protected virtual void RewardOnDead()
    {
        ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByEnum(ItemEnum.Gold);
        item.itemCount = 1;
        InventoryManager.Instance.Monies().AddItem(item);
    }
}
