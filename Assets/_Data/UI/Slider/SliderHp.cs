using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliderHp : SliderAbstract
{
    protected virtual void FixedUpdate()
    {
        this.UpdateValue();
    }

    protected virtual void UpdateValue()
    {
        this.slider.value = this.GetValue();
    }

    protected abstract float GetValue();
}

