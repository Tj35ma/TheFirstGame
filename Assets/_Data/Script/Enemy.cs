using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 10;
    int maxHP = 100;
    float enemyWeight = 2.5f;
    bool isDead = true;
    bool isBoss = false;

    int GetCurrentHp()
    {
        return this.currentHp;
    }

    float GetWeight()
    {
        return this.enemyWeight;
    }

    protected abstract string GetName();
    
    void GetisDead()
    {

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
