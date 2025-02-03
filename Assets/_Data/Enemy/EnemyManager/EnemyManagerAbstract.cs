using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerAbstract : TFGMonoBehaviour
{
    [SerializeField] protected EnemyManager enemyManager;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyManager();
    }

    protected virtual void LoadEnemyManager()
    {
        if (enemyManager != null) return;
        this.enemyManager = transform.GetComponentInParent<EnemyManager>();
        Debug.Log(transform.name + ": LoadEnemyManager", gameObject);
    }
}
