using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiegirlMoving : EnemyMoving
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.pathName = "Path_0";
    }
}
