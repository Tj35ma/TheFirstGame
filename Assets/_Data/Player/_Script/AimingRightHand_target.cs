using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : TFGMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.331f, 0.384f, 0.58f);
        transform.localRotation = Quaternion.Euler(171.934f, 101.597f, 81.023f);
    }
}
