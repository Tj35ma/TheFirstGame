using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPrefabs<T> : TFGMonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected List<T> prefabs = new();

    protected override void Awake()
    {
        base.Awake();
        this.HidePrefabs();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if(this.prefabs.Count > 0) return;
        foreach (Transform child in transform) 
        {
            T prefab = child.GetComponent<T>();
            if (prefab) this.prefabs.Add(prefab);
        }
        Debug.Log(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {
        foreach(T prefab in this.prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual T GetRandom()
    {
        int rand = Random.Range(0,this.prefabs.Count);
        return this.prefabs[rand];
    }

    public virtual T GetbyName(string prefabName)
    {
        foreach (T prefab in this.prefabs)
        {
            if (prefab.name != prefabName) continue;
            return prefab;
        }
        return null;
    }
}
