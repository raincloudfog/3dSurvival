using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : ObjectClass
{
    public override void PickUp()
    {
        Debug.Log("������ �ֿ�");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        if (ItemManager.Instance.items.ContainsKey(Materialtype.Wood))
        {
            if (ItemManager.Instance.items[Materialtype.Wood] >= 1)
            {
                ItemManager.Instance.items[Materialtype.Wood] += 1;
                Debug.Log("1������" + ItemManager.Instance.items[Materialtype.Wood]);
            }
        }

        else if (ItemManager.Instance.items.ContainsKey(Materialtype.Wood) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Wood, 1);
            Debug.Log("�ƹ��͵� ��� 1������" + ItemManager.Instance.items[Materialtype.Wood]);

        }
        inventory.AcquireItem(_item, 1);
        ObjectPool.Instance.ObjectsReturn(this); // ������ƮǮ�� ����
    }
}
