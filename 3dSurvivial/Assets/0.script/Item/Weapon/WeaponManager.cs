using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public interface IWeaponType
{
    public void Attack();
}

public class WeaponManager : SingletonMono<WeaponManager>
{
    public int text;
    
    IWeaponType weaponType;
    [SerializeField] GameObject[] Tools;

    public enum WeaponType
    {
        pickAxe = 0,
        Axe,

        End
    }
    public WeaponType weaponenum = WeaponType.End;
    Dictionary<KeyCode, Itemscript> itemChange = new Dictionary<KeyCode, Itemscript>();
    Dictionary<WeaponType, IWeaponType> weapons = new Dictionary<WeaponType, IWeaponType>()
    {
        { WeaponType.pickAxe, new PickAxe()}, {WeaponType.Axe, new Axe() }
    };

    private void FixedUpdate()
    {

        if (weaponenum == WeaponType.pickAxe)
        {
            Tools[1].SetActive(false);
            Tools[0].SetActive(true);

        }
        else if (weaponenum == WeaponType.Axe)
        {
            Tools[0].SetActive(false);
            Tools[1].SetActive(true);

        }
    }

    public void SetWeaponType(WeaponType weaponType)
    {
        weaponenum = weaponType;
        this.weaponType = weapons[weaponType];
    }

}
