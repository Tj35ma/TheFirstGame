using TMPro;
using UnityEngine;

public class TextExpCount : TextAbstract
{
    protected virtual void FixedUpdate()
    {
        this.LoadExpCount();
    }  

    protected virtual void LoadExpCount()
    {
        ItemInventory item = InventoryManager.Instance.Currency().FindItem(ItemEnum.PlayerExp);
        string expCount; 

        if (item == null) expCount = "0";
        else expCount = item.itemCount.ToString();

        this.textPro.text = expCount;
    }
}
