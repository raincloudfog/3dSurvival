using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : ObjectClass
{
    public override void PickUp()
    {
        Debug.Log("������ �ֿ�");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock))
        {
            if (ItemManager.Instance.items[Materialtype.Rock] >= 1)
            {
                ItemManager.Instance.items[Materialtype.Rock] += 1;
                Debug.Log("1������" + ItemManager.Instance.items[Materialtype.Bush]);
            }
        }

        else if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Rock, 1);
            Debug.Log("�ƹ��͵� ��� 1������" + ItemManager.Instance.items[Materialtype.Rock]);

        }
        inventory.AcquireItem(_item, 1);
        ObjectPool.Instance.ObjectsReturn(this); // ������ƮǮ�� ����

    }
}
