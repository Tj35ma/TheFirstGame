using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySort : MonoBehaviour
{
    List<Enemy> enemiesSorted = new List<Enemy>();
    EnemyManager enemyManager;

    private void Awake()
    {
        this.LoadComponents();
    }

    private void Reset()
    {
        this.LoadComponents ();              
    }

    private void Start()
    {
        this.Sorting();        
    }

    protected virtual void LoadComponents()
    {
        if(this.enemyManager != null) return;
        this.enemyManager = GetComponent<EnemyManager>();
        Debug.Log(transform.name + ": LoadComponents");
    }

    protected virtual void Sorting()
    {
        this.enemiesSorted = this.enemyManager.Enemies;
        int n = this.enemiesSorted.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - 1 - i; j++)
            {                
                if (this.enemiesSorted[j].GetWeight() > this.enemiesSorted[j + 1].GetWeight())
                {                    
                    var temp = this.enemiesSorted[j];
                    this.enemiesSorted[j] = this.enemiesSorted[j + 1];
                    this.enemiesSorted[j + 1] = temp;
                }
            }
        }
    }   
}

