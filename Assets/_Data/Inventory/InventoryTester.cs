using com.cyborgAssets.inspectorButtonPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : TFGMonoBehaviour
{
    [ProButton]
    public virtual void AddTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByEnum(InventoryEnum.Monies);

        ItemInventory gold = new();
        gold.itemProfile = InventoryManager.Instance.GetProfileByEnum(ItemEnum.Gold);
        gold.itemName = gold.itemProfile.itemName;
        gold.itemCount = count;
        inventoryCtrl.AddItem(gold);
    }

    [ProButton]
    public virtual void RemoveTestGold(int count)
    {
        InventoryCtrl inventoryCtrl = InventoryManager.Instance.GetByEnum(InventoryEnum.Monies);

        ItemInventory gold = new();
        gold.itemProfile = InventoryManager.Instance.GetProfileByEnum(ItemEnum.Gold);
        gold.itemName = gold.itemProfile.itemName;
        gold.itemCount = count;
        inventoryCtrl.RemoveItem(gold);
    }


    [ProButton]
    public virtual void AddTestItems(ItemEnum itemEnum, int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByEnum(InventoryEnum.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = InventoryManager.Instance.GetProfileByEnum(itemEnum);
            wand.itemName = wand.itemProfile.itemName;
            wand.itemCount = 1;
            items.AddItem(wand);
        }
    }


    [ProButton]
    public virtual void RemoveTestItems(ItemEnum itemEnum, int count)
    {
        InventoryCtrl items = InventoryManager.Instance.GetByEnum(InventoryEnum.Items);
        for (int i = 0; i < count; i++)
        {
            ItemInventory wand = new();
            wand.itemProfile = InventoryManager.Instance.GetProfileByEnum(itemEnum);
            wand.itemName = wand.itemProfile.itemName;
            wand.itemCount = 1;
            items.RemoveItem(wand);
        }
    }
}