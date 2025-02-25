using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsDropManager : TFGSingleton<ItemsDropManager>
{
    [SerializeField] protected ItemDropSpawner spawner;
    public ItemDropSpawner Spawner => spawner;

    public float spawnHeight = 1.0f;
    public float forceAmount = 5.0f;    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<ItemDropSpawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }

    public virtual void DropMany(ItemEnum itemEnum, int dropCount, Vector3 dropPosition)
    {
        for (int i = 0; i < dropCount; i++)
        {
            this.Drop(itemEnum, 1, dropPosition);
        }
    }

    public virtual void Drop(ItemEnum itemEnum, int dropCount, Vector3 dropPosition)
    {
        Vector3 spawnPosition = dropPosition + new Vector3(Random.Range(-0.5f, 0.5f), spawnHeight, Random.Range(-0.5f, 0.5f));
        ItemDropCtrl itemPrefab = this.spawner.PoolPrefabs.GetbyName(itemEnum.ToString());
        if (itemPrefab == null) itemPrefab = this.spawner.PoolPrefabs.GetbyName("DefaultDrop");

        ItemDropCtrl newItem = this.spawner.Spawn(itemPrefab, spawnPosition);
        newItem.SetValue(itemEnum, dropCount, InventoryEnum.Currency);
        newItem.gameObject.SetActive(true);

        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        newItem.Rigidbody.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
    }
}
