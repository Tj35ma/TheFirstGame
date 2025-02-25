using com.cyborgAssets.inspectorButtonPro;
using System.Collections.Generic;
using UnityEngine;

public class InventoryTester : TFGMonoBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.AddTestItems(ItemEnum.Gold, 1000);
    }

    [ProButton]
    public virtual void AddTestItems(ItemEnum itemEnum, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.AddItem(itemEnum, 1);
        }
    }

    [ProButton]
    public virtual void RemoveTestItems(ItemEnum itemEnum, int count)
    {
        for (int i = 0; i < count; i++)
        {
            InventoryManager.Instance.RemoveItem(itemEnum, 1);
        }
    }
}