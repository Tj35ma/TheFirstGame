using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : TFGMonoBehaviour
{
    [SerializeField] protected List<WeaponsAbstract> weapons;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform)
        {
            WeaponsAbstract weaponsAbstract = child.GetComponent<WeaponsAbstract>();
            if (weaponsAbstract == null) continue;
            this.weapons.Add(weaponsAbstract);
        }
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    public virtual WeaponsAbstract GetCurrentWeapon()
    {
        return this.weapons[0];
    }
}
