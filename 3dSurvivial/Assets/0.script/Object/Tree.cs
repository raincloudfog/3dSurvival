using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ObjectClass
{
    public bool ishit = false;
    private void OnEnable() // 재등장시 체력 돌려주기
    {
        Hp = 5;
        ishit = false;
    }
    public override void PickUp() // 나무 부시기
    {
        if ((ishit == true || GameManager.Instance.isActive == false) ||
            WeaponManager.Instance.weaponenum != WeaponManager.WeaponType.Axe)
        {
            return;
        }
        Hp -= 1;
        Debug.Log("나무 때림");
        StartCoroutine(Delay());
        
        
        if (Hp <= 0)
        {
            Debug.Log("나무 부셔짐");
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
                Debug.Log("1더해줌" + ItemManager.Instance.items[Materialtype.Wood]);
            }
        }

        else if (ItemManager.Instance.items.ContainsKey(Materialtype.Wood) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Wood, 1);
            Debug.Log("아무것도 없어서 1더해줌" + ItemManager.Instance.items[Materialtype.Wood]);

        }
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }


}
