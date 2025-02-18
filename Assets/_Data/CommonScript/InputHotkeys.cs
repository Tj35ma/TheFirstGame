using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotkeys : TFGSingleton<InputHotkeys> 
{
    protected bool isToggleInventoryUI =false;
    public bool IsToggleInventoryUI => isToggleInventoryUI;

    protected virtual void Update()
    {
        this.OpenInventory();
    }

    protected virtual void OpenInventory()
    {
        this.isToggleInventoryUI = Input.GetKeyUp(KeyCode.I);
    }
}
