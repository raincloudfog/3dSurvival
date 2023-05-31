using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : ObjectClass
{
    public override void PickUp()
    {
        Debug.Log("아이템 주움");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // 픽업 후 바로 함수가 빈걸로 바꿔야 여러번 안눌림.
        ObjectPool.Instance.ObjectsReturn(this); // 오브젝트풀로 전달
    }
}
