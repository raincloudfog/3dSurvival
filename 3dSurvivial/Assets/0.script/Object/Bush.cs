using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : ObjectClass
{
    [SerializeField]Item plusitem;
    public override void PickUp()
    {
        Debug.Log("������ �ֿ�");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        inventory.AcquireItem(_item, 1);
        inventory.AcquireItem(plusitem, 1);
        ObjectPool.Instance.ObjectsReturn(this); // ������ƮǮ�� ����
    }
}
