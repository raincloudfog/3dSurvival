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

        ChangeWeapon();
    }

    /// <summary>
    /// 손에 들고 있는 무기 변경 시켜주는 코드
    /// </summary>
    void ChangeWeapon()
    {
        if (weaponenum == WeaponType.pickAxe)
        {
            if (Tools == null)
            {
                return;
            }
            Tools[1].SetActive(false);
            Tools[0].SetActive(true);

        }
        else if (weaponenum == WeaponType.Axe)
        {
            if (Tools == null)
            {
                return;
            }
            Tools[0].SetActive(false);
            Tools[1].SetActive(true);

        }
        else if (weaponenum == WeaponType.End)
        {
            if (Tools == null)
            {
                return;
            }
            Tools[0].SetActive(false);
            Tools[1].SetActive(false);
        }
    }


    /// <summary>
    /// 무기 타입 변경 시켜주는 코드
    /// </summary>
    /// <param name="weaponType"></param>
    public void SetWeaponType(WeaponType weaponType)
    {
        weaponenum = weaponType;
        this.weaponType = weapons[weaponType];
    }

}
