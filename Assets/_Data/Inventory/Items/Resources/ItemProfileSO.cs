using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
public class ItemProfileSO : ScriptableObject
{
    public InventoryEnum inventoryEnum;
    public ItemEnum itemEnum;
    public string itemName;
    public bool isStackable = false;

    protected virtual void Reset()
    {
        this.ResetValue();
    }

    protected virtual void ResetValue()
    {
        this.AutoLoadItemEnum();
        this.AutoLoadItemName();
    }

    protected virtual void AutoLoadItemEnum()
    {
        string className = this.GetType().Name;
        Debug.Log("className: " + className);
        this.itemEnum = ItemCodeParse.Parse("Item1");
    }

    protected virtual void AutoLoadItemName()
    {
        Debug.Log("name: " + this.name);
        this.itemName = "Item1";
    }
}