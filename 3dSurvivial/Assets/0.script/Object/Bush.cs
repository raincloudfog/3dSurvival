using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : ObjectClass
{
    [SerializeField]Item plusitem; // �̰Ŵ� ������ �߰��� ��� ����
    public override void PickUp()
    {
        Debug.Log("������ �ֿ�");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        if(ItemManager.Instance.items.ContainsKey(Materialtype.Bush))
        {
            if (ItemManager.Instance.items[Materialtype.Bush] >= 1)
            {
                ItemManager.Instance.items[Materialtype.Bush] += 1;
                Debug.Log("1������" + ItemManager.Instance.items[Materialtype.Bush]);
            }
        }
        
        else if(ItemManager.Instance.items.ContainsKey(Materialtype.Bush) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Bush, 1);
            Debug.Log("�ƹ��͵� ��� 1������" + ItemManager.Instance.items[Materialtype.Bush]);

        }
        
        inventory.AcquireItem(_item, 1);
        inventory.AcquireItem(plusitem, 1);
        ObjectPool.Instance.ObjectsReturn(this); // ������ƮǮ�� ����
    }
}
