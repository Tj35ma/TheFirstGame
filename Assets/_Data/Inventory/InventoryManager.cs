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
        this.LoadItemProfiles();
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

    public virtual InventoryCtrl Currency()
    {
        return this.GetByEnum(InventoryEnum.Currency);
    }

    public virtual InventoryCtrl Items()
    {
        return this.GetByEnum(InventoryEnum.Items);
    }

    public virtual void AddItem(ItemInventory itemInventory)
    {
        InventoryEnum inventoryEnum = itemInventory.ItemProfile.inventoryEnum;
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByEnum(inventoryEnum);
        inventoryCtrl.AddItem(itemInventory);
    }

    public virtual void AddItem(ItemEnum itemEnum, int itemCount)
    {
        ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByEnum(itemEnum);
        ItemInventory item = new(itemProfile, itemCount);
        this.AddItem(item);
    }

    public virtual void RemoveItem(ItemEnum itemEnum, int itemCount)
    {
        ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByEnum(itemEnum);
        ItemInventory item = new(itemProfile, itemCount);
        this.RemoveItem(item);
    }

    public virtual void RemoveItem(ItemInventory itemInventory)
    {
        InventoryEnum inventoryEnum = itemInventory.ItemProfile.inventoryEnum;
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByEnum(inventoryEnum);
        inventoryCtrl.RemoveItem(itemInventory);
    }

    protected virtual void LoadItemProfiles()
    {
        if (this.itemProfiles.Count > 0) return;
        ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
        this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
        Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
    }
}
