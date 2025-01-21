using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : TFGMonoBehaviour
{
    public GameObject target;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        this.Moving();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadTarget();
    }

    protected virtual void LoadEnemyCtrl()
    {

        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

    protected virtual void Moving()
    {
        this.enemyCtrl.Agent.SetDestination(target.transform.position);
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.Find("TargetMoving");
        Debug.Log(transform.name + ": LoadNavMeshAgent", gameObject);
    }

}
