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
        Debug.Log("��⸦ ����");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        foreach (var item in inven.slots) // �������ε� �ٲ� �� ����.
        {
            if (item.item.itemName == ItemName.Meat)
            {
                item.AddSlotcount(-1);
            }

        }
    }
}
