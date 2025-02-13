using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryCtrl : TFGMonoBehaviour
{
    protected List<ItemInventory> items = new();

    public abstract InventoryEnum GetName();

    public virtual void AddItem(ItemInventory item)
    {
        ItemInventory itemExist = this.FindItem(item.itemProfile.itemEnum);
        if (!item.itemProfile.isStackable || itemExist == null) 
        {
            this.items.Add(item);
            return;
        }
        itemExist.itemCount += item.itemCount;
    }

    public virtual ItemInventory FindItem(ItemEnum itemEnum)
    {
        //if (this.items.Count <= 0) return null;
        foreach (ItemInventory itemInventory in this.items)
        {
            if(itemInventory.itemProfile.itemEnum == itemEnum) return itemInventory;
        }
        return null;
    }
}
