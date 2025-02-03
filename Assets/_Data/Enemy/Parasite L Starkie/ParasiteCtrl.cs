using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteCtrl : EnemyCtrl
{
    [SerializeField] protected EnemyEnum enemyEnum;
    public override string GetName() => this.enemyEnum.ToString();
   
}
