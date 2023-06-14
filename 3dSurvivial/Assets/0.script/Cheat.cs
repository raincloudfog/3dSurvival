using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

/// <summary>
/// 치트 입니다.
/// </summary>
public class Cheat : SingletonMono<Cheat>
{
    public Item _itme;

    public Inventory inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            
            
            //Debug.Log("아이템 이름" + inventory.slots[0].item.itemName);
            inventory.AcquireItem(_itme, 1);
            
        }
    }
}
