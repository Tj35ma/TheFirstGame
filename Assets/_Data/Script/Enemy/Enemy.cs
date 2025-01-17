using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 10;
    int maxHp = 100;
    float enemyWeight = 2.5f;
    bool isDead = true;
    bool isBoss = false;

   
    public virtual bool IsDead()
    {
        if(this.currentHp > 0) this.isDead = false;
        else this.isDead = true;

        return this.isDead;
    }

    public abstract string GetName();

    void GetisDead()
    {

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

    float GetWeight()
    {
        return this.enemyWeight;
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
