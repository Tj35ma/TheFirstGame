using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemDropCtrl : PoolObj
{
    [SerializeField] protected Rigidbody _rigid;
    public Rigidbody Rigidbody => _rigid;

    protected InventoryEnum inventoryEnum = InventoryEnum.Items;
    public InventoryEnum InventoryEnum => inventoryEnum;

    protected ItemEnum itemEnum;

    public ItemEnum ItemEnum => itemEnum;

    protected int itemCount = 1;
    public int ItemCount => itemCount;

    public override string GetName()
    {
        return "ItemDrop";
    }

    public virtual void SetValue(ItemEnum itemEnum, int itemCount)
    {
        this.itemEnum = itemEnum;
        this.itemCount = itemCount;

    }

    public virtual void SetValue(ItemEnum itemEnum, int itemCount, InventoryEnum inventoryEnum)
    {
        this.itemEnum = itemEnum;
        this.itemCount = itemCount;
        this.inventoryEnum = inventoryEnum;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigibody();
    }

    protected virtual void LoadRigibody()
    {
        if (this._rigid != null) return;
        this._rigid = GetComponent<Rigidbody>();
        Debug.Log(transform.name + ": LoadRigibody", gameObject);
    }
}