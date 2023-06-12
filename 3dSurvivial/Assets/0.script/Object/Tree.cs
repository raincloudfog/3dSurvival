using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ObjectClass
{
    bool ishit = false;
    private void OnEnable() // ������ ü�� �����ֱ�
    {
        Hp = 5;
        ishit = false;
    }
    public override void PickUp() // ���� �νñ�
    {

        if ((ishit == true || GameManager.Instance.isActive == false) ||
            WeaponManager.Instance.weaponenum != WeaponManager.WeaponType.Axe)
        {
            return;
        }
        StartCoroutine(Delay());
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
    IEnumerator Delay()
    {
        ishit = true;
        inventory.AcquireItem(_item, 1);
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
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }


}
