using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ObjectClass
{

    private void OnEnable() // ������ ü�� �����ֱ�
    {
        Hp = 5;
    }
    public override void PickUp() // ���� �νñ�
    {
        Hp -= 1;
        Debug.Log("���� ����");
        if (Hp <= 0)
        {
            Debug.Log("���� �μ���");
            //InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
            ObjectPool.Instance.ObjectsReturn(this);
        }
        //InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
    }


    
}
