using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : ObjectClass
{
    public override void PickUp()
    {
        Debug.Log("아이템 주움");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // 픽업 후 바로 함수가 빈걸로 바꿔야 여러번 안눌림.
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
        inventory.AcquireItem(_item, 1);
        ObjectPool.Instance.ObjectsReturn(this); // 오브젝트풀로 전달
    }
}
