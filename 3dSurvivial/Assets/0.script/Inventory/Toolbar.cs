using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    [SerializeField] Slot[] slots;

    /*Dictionary<int, KeyCode> numbers = new Dictionary<int, KeyCode>
    {
        { 0, KeyCode.Alpha1 },
        { 1, KeyCode.Alpha2},
        { 2, KeyCode.Alpha3},
        { 3, KeyCode.Alpha4},
        { 4, KeyCode.Alpha5},
        { 5, KeyCode.Alpha6},
        { 6, KeyCode.Alpha7},
        { 7, KeyCode.Alpha8},
        { 8, KeyCode.Alpha9},
        { 9, KeyCode.Alpha0}

    };*/

    // Start is called before the first frame update
    void Start()
    {
        //slots = GetComponentsInChildren<Slot>();
       
    }

    // Update is called once per frame
    void Update()
    { 
        Inputtoolbar();
    }
    /// <summary>
    /// ���ٿ� ������ ���
    /// </summary>
    void Inputtoolbar()
    {

        if (Input.anyKeyDown)
        {
            // �Էµ� Ű�� ���ڿ��� ����
            string key = Input.inputString;

            // Ű�� ���� ������ �Լ� ����
            switch (key)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":                
                    Equip(key);
                    break;
                default:
                    // �Էµ� Ű�� ���� ó���� ���� ���
                    break;
            }
        }
    }
    /// <summary>
    /// ��� ����
    /// </summary>
    /// <param name="key"></param>
    void Equip(string key)
    {
        int number;
        if(int.TryParse(key, out number))
        {
            number = int.Parse(key);
            
        }
        
        
       /* if (*//*
            slots[number+1].item.itemType == Item.ItemType.Equipment
                )*/
        
        if(slots[number - 1].item == null) // ���� ������ ���Կ� �������� ������ �׳� �Ѿ�ϴ�.
        {
            return;
        }
        if(slots[number-1].item.itemName == "PickAxe") // ���� ����ĭ�� ��̰� �ִٸ� ���⸦ Ȱ��ȭ�ؼ� ��̸� �������ݴϴ�.
        {
            if(WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.pickAxe )
            {
                WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.End;
                return;
            }
            WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.pickAxe;

        }
        else if (slots[number-1].item.itemName == "Axe") // ���� ����ĭ�� ������ �ִٸ� ���⸦ Ȱ��ȭ�ؼ� ������ �������ݴϴ�.
        {
            if (WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.Axe)
            {
                WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.End;
                return;
            }
            WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.Axe;
        }
        
    }
}
