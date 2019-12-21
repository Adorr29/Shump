using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Entity
{
    Weapon[] weaponList;

    protected virtual new void Awake()
    {
        base.Awake();
        weaponList = GetComponentsInChildren<Weapon>();
    }

    protected void Shoot()
    {
        foreach (Weapon weapon in weaponList)
            weapon.Shoot();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        foreach (Weapon weapon in weaponList)
            weapon.Update();
    }
}
