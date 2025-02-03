using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyCtrl : PoolObj
{
    [SerializeField] protected Transform model;
    [SerializeField] protected NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    [SerializeField] protected Animator animator;
    public Animator Animator => animator;

    [SerializeField] protected TowerTargetable towerTargetable;
    public TowerTargetable TowerTargetable => towerTargetable;

    [SerializeField] protected EnemyDamageRecever enemyDamageRecever;
    public EnemyDamageRecever EnemyDamageRecever => enemyDamageRecever;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadNavMeshAgent();
        this.LoadModel();
        this.LoadAnimator();
        this.LoadTowerTargetable();
        this.LoadEnemyDamageRecever();
    }

    protected virtual void LoadEnemyDamageRecever()
    {
        if (this.enemyDamageRecever != null) return;
        this.enemyDamageRecever = GetComponentInChildren<EnemyDamageRecever>();
        Debug.Log(transform.name + ": LoadEnemyDamageRecever", gameObject);
    }

    protected virtual void LoadNavMeshAgent()
    {
        if (this.agent != null) return;
        this.agent = GetComponent<NavMeshAgent>();
        this.agent.speed = 2f;
        this.agent.angularSpeed = 200f;
        this.agent.acceleration = 150f;
        Debug.Log(transform.name + ": LoadNavMeshAgent",gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadTowerTargetable()
    {
        if (this.towerTargetable != null) return;
        this.towerTargetable = transform.GetComponentInChildren<TowerTargetable>();
        Debug.Log(transform.name + ": TowerTargetable", gameObject);
    }

    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren <Animator>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

}
    
