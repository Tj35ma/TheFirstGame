using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2Ctrl : EffectFlyAbstract
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.effectEnum = EffectEnum.Fire2;
        this.transform.name = this.effectEnum.ToString();
    }
}