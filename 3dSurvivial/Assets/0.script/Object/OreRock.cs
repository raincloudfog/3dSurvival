using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRock : ObjectClass
{

    public override void PickUp()
    {
        Hp -= 1;
        Debug.Log("���� ����");
        if (Hp <= 0)
        {
            Debug.Log("���� �μ���");
            ObjectPool.Instance.ObjectsReturn(this);
        }
    }
    private void OnEnable()
    {
        Hp = 5; // ���������� ü��
    }

}
