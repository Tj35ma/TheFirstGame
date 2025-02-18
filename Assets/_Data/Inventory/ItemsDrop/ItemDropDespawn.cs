using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropDespawn : Despawn<ItemDropCtrl>
{
    public override void DoDespawn()
    {
        ItemDropCtrl itemDropCtrl = (ItemDropCtrl)this.parent;

        ItemInventory item = new();
        item.itemProfile = InventoryManager.Instance.GetProfileByEnum(itemDropCtrl.ItemEnum);        
        item.itemCount = itemDropCtrl.ItemCount;
        InventoryManager.Instance.GetByEnum(itemDropCtrl.InventoryEnum).AddItem(item);

        base.DoDespawn();
    }
}
