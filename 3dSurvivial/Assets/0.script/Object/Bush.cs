using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : ObjectClass
{
    public override void PickUp()
    {
        Debug.Log("������ �ֿ�");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        inventory.AcquireItem(_item, 1);
        ObjectPool.Instance.ObjectsReturn(this); // ������ƮǮ�� ����
    }
}
