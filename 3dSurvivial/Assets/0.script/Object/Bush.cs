using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : ObjectClass
{
    [SerializeField]Item plusitem; // 이거는 베리를 추가로 얻기 위함
    public override void PickUp()
    {
        Debug.Log("아이템 주움");
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // 픽업 후 바로 함수가 빈걸로 바꿔야 여러번 안눌림.
        if(ItemManager.Instance.items.ContainsKey(Materialtype.Bush))
        {
            if (ItemManager.Instance.items[Materialtype.Bush] >= 1)
            {
                ItemManager.Instance.items[Materialtype.Bush] += 1;
                Debug.Log("1더해줌" + ItemManager.Instance.items[Materialtype.Bush]);
            }
        }
        
        else if(ItemManager.Instance.items.ContainsKey(Materialtype.Bush) == false)
        {
            ItemManager.Instance.items.Add(Materialtype.Bush, 1);
            Debug.Log("아무것도 없어서 1더해줌" + ItemManager.Instance.items[Materialtype.Bush]);

        }
        
        inventory.AcquireItem(_item, 1);
        inventory.AcquireItem(plusitem, 1);
        ObjectPool.Instance.ObjectsReturn(this); // 오브젝트풀로 전달
    }
}
