using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : TFGMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
