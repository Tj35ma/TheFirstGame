using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairPointer : TFGMonoBehaviour
{
    protected float maxDistance = 100f;
    protected Collider hitObj;
    [SerializeField] LayerMask layerMask;
    
    protected virtual void Update()
    {
        this.Pointing();
    }

    protected virtual void Pointing()
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance, layerMask))
        {
            transform.position = hitInfo.point;
            this.hitObj = hitInfo.collider;
        }
    }
}
