using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFire : ObjectClass
{
    Inventory inven;
    public void Start()
    {
        Init();
    }

    public void Init()
    {
        if(inven == null)
        {
            inven = ButtonManager.Instance._inven;
        }
    }
    public override void PickUp()
    {
        Debug.Log("고기를 구움");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // 픽업 후 바로 함수가 빈걸로 바꿔야 여러번 안눌림.
        foreach (var item in inven.slots) // 포문으로도 바꿀 수 있음.
        {
            if (item.item.itemName == ItemName.Meat)
            {
                item.AddSlotcount(-1);
            }

        }
    }
}
