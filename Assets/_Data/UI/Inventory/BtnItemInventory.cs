using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BtnItemInventory : ButtonAbstract
{
    [SerializeField] protected TextMeshProUGUI textItemName;
    [SerializeField] protected TextMeshProUGUI textItemCount;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected virtual void FixedUpdate()
    {
        this.BtnItemUpdating();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemCount();
    }

    protected virtual void LoadItemName()
    {
        if (this.textItemName != null) return;
        this.textItemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemCount()
    {
        if (this.textItemCount != null) return;
        this.textItemCount = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemCount", gameObject);
    }

    public virtual void SetItem(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
    protected override void OnClick()
    {
        Debug.Log("Item click");
    }

    protected virtual void BtnItemUpdating()
    {
        Debug.Log("BtnItemUpdating");
        this.textItemName.text = this.itemInventory.itemName;
        this.textItemCount.text = this.itemInventory.itemCount.ToString();

        if (this.itemInventory.itemCount == 0) Destroy(gameObject);

    }
}
