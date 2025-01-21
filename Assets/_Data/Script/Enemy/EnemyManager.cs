using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    public List<Enemy> Enemies => this.enemies;

    Enemy smallestenemy;
    Enemy biggestenemy;

    private void Awake()
    {
        this.LoadEnemies();
    }

    private void Start()
    {
        //this.LoadSmallestEnemy();
        //this.LoadBiggestEnemy();
    }

    protected virtual void LoadSmallestEnemy()
    {
        Enemy firstenemy = this.enemies[0];
        float smallestWeight = firstenemy.GetMaxWeight();

        foreach (Enemy enemy in this.enemies) 
        {
            float enemyWeight = enemy.GetWeight();
            if (enemyWeight < smallestWeight)
            {
                smallestWeight = enemyWeight;
                this.smallestenemy = enemy;
            }

            Debug.Log(enemy.GetObjName() + " " + enemy.GetWeight());
        }
    }

    protected virtual void LoadBiggestEnemy()
    {
        Enemy firstenemy = this.enemies[0];
        float biggestWeight = firstenemy.GetMinWeight();

        foreach (Enemy enemy in this.enemies)
        {
            float enemyWeight = enemy.GetWeight();
            if (enemyWeight > biggestWeight)
            {
                biggestWeight = enemyWeight;
                this.biggestenemy = enemy;
            }
            
        }
    }
    protected virtual void LoadEnemies()
    {
        foreach (Transform childObj in transform)
        {
            Enemy enemy = childObj.GetComponent<Enemy>();
            if (enemy == null) continue;
            this.enemies.Add(enemy);            
        }
    }
}
