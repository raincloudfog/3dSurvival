using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ObjectClass
{
    bool ishit = false;
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
        StartCoroutine(Delay());
        Hp -= 1;
        Debug.Log("나무 때림");
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
        yield return new WaitForSeconds(0.5f);
        ishit = false;
        yield break;
    }


}
