using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : TFGSingleton<InventoryManager>
{
    [SerializeField] protected List<InventoryCtrl> inventories;
    [SerializeField] protected List<ItemProfileSO> itemProfiles;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventories();
    }
    

    protected virtual void LoadInventories()
    {
        if (this.inventories.Count > 0) return;
        foreach(Transform child in transform)
        {
            InventoryCtrl inventoryCtrl = child.GetComponent<InventoryCtrl>();
            if (inventoryCtrl == null) continue;
            this.inventories.Add(inventoryCtrl);
        }
        Debug.Log(transform.name + ": LoadInventories", gameObject);
    }

    public virtual InventoryCtrl GetByEnum(InventoryEnum inventoryName)
    {
        foreach (InventoryCtrl inventory in this.inventories)
        {
            if (inventory.GetName() == inventoryName) return inventory;
        }

        return null;
    }

    public virtual ItemProfileSO GetProfileByEnum(ItemEnum itemEnum)
    {
        foreach (ItemProfileSO itemProfile in this.itemProfiles)
        {
            if (itemProfile.itemEnum == itemEnum) return itemProfile;
        }

        return null;
    }

    public virtual InventoryCtrl Monies()
    {
        return this.GetByEnum(InventoryEnum.Monies);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByEnum(InventoryEnum.Items);
    }
}
