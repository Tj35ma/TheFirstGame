using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        this.LoadEnemies();
    }

    protected virtual void LoadEnemies()
    {
        foreach (Transform childObj in transform)
        {
            Enemy enemy = childObj.GetComponent<Enemy>();
            if (enemy == null) continue;
            this.enemies.Add(enemy);
            //Debug.Log(childObj.name);
        }
    }
}
