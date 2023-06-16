using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRock : ObjectClass
{
    public bool ishit = false;

    //�� ������ Ÿ���� ����.
    public override void PickUp()
    {
        Debug.Log("���� �Ⱦ� �����.");
        if (Hp <= 0)
        {
            Debug.Log("���� �μ���");
            ObjectPool.Instance.ObjectsReturn(this);
        }
        if (ishit == false && GameManager.Instance.isActive == true &&
            WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.pickAxe)
        {
            Hp -= 1;
            Debug.Log("���� ����");
            StartCoroutine(Delay());



        }
        else
        {
            Debug.Log("�� ��ĳ���°���?");

        }

        

    }
    private void OnEnable()
    {
        Hp = 5; // ���������� ü��
        ishit = false;
    }
    IEnumerator Delay()
    {
        ishit = true;
        inventory.AcquireItem(_item, 1);
        if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock))
        {
            if (ItemManager.Instance.items[Materialtype.Rock] >= 1)
            {
                ItemManager.Instance.items[Materialtype.Rock] += 1;
                Debug.Log("1������" + ItemManager.Instance.items[Materialtype.Rock]);
            }
        }

        else if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Rock, 1);
            Debug.Log("�ƹ��͵� ��� 1������" + ItemManager.Instance.items[Materialtype.Rock]);

        }
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }

}
