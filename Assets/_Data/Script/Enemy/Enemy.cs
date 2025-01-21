using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 10;
    int maxHp = 100;
    float Weight = 1f;
    float minWeight = 1f;
    float maxWeight = 10f;
    bool isDead = true;
    bool isBoss = false;

    private void Reset()
    {
        this.InitData();
    }

    private void OnEnable()
    {
        this.InitData();
    }

    public abstract string GetName();

    public virtual string GetObjName()
    {
        return transform.name;
    }

    protected virtual void InitData()
    {
        this.Weight = this.GetRandomWeight();
    }

    protected virtual float GetRandomWeight()
    {
        return Random.Range(this.minWeight, this.maxWeight);
    }

    public virtual float GetWeight()
    {
        return this.Weight;
    }

    public virtual float GetMinWeight()
    {
        return this.minWeight;
    }

    public virtual float GetMaxWeight()
    {
        return this.maxWeight;
    }

    public virtual bool IsDead()
    {
        if(this.currentHp > 0) this.isDead = false;
        else this.isDead = true;

        return this.isDead;
    }      

    public virtual int GetMaxHp()
    {
        return this.maxHp;
    }

    public virtual int GetCurrentHp()
    {
        return this.currentHp;
    }

    public virtual void SetHp(int newHp)
    {
        this.currentHp = newHp;
    }   
      
    bool IsBoss()
    {
        return this.isBoss;
    }

    public void Moving()
    {
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
    }
}
