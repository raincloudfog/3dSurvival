using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
interface IWeaponType
{
    public void Attack();
}
public class WeaponManager : SingletonMono<WeaponManager>
{
    IWeaponType weaponType;

    Dictionary<KeyCode, Itemscript> itemChange = new Dictionary<KeyCode, Itemscript>();
    private void FixedUpdate()
    {
        
    }

    void SetWeaponType(IWeaponType weaponType)
    {
        this.weaponType = weaponType;
    }
    public void AdditemNumber()
    {

    }
}
