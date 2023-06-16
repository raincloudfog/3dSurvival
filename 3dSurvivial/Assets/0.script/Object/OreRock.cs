using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRock : ObjectClass
{
    public bool ishit = false;

    //내 아이템 타입은 돌임.
    public override void PickUp()
    {
        Debug.Log("광석 픽업 실행됨.");
        if (Hp <= 0)
        {
            Debug.Log("광석 부셔짐");
            ObjectPool.Instance.ObjectsReturn(this);
        }
        if (ishit == false && GameManager.Instance.isActive == true &&
            WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.pickAxe)
        {
            Hp -= 1;
            Debug.Log("광석 때림");
            StartCoroutine(Delay());



        }
        else
        {
            Debug.Log("왜 안캐지는거죠?");

        }

        

    }
    private void OnEnable()
    {
        Hp = 5; // 시작했을때 체력
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
                Debug.Log("1더해줌" + ItemManager.Instance.items[Materialtype.Rock]);
            }
        }

        else if (ItemManager.Instance.items.ContainsKey(Materialtype.Rock) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Rock, 1);
            Debug.Log("아무것도 없어서 1더해줌" + ItemManager.Instance.items[Materialtype.Rock]);

        }
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }

}
