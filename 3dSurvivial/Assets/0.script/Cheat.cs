using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public class Cheat : SingletonMono<Cheat>
{
    public Item _itme;

    public Inventory inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            
            Debug.Log("���� ����" + inventory.slots.Length);
            //Debug.Log("������ �̸�" + inventory.slots[0].item.itemName);
            inventory.AcquireItem(_itme, 1);
            
        }
    }
}
