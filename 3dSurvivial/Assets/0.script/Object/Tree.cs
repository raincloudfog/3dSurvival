using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ObjectClass
{

    private void OnEnable() // 재등장시 체력 돌려주기
    {
        Hp = 5;
    }
    public override void PickUp() // 나무 부시기
    {
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


    
}
