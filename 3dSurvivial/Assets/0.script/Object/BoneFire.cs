using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneFire : ObjectClass
{
    
    

    protected override void Init()
    {
        
    }
    public override void PickUp()
    {
        Debug.Log("고기를 구움");
        
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // 픽업 후 바로 함수가 빈걸로 바꿔야 여러번 안눌림.
        
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == ItemName.Meat)
                    {
                        ItemManager.Instance.GetGrilledmeat();
                        inventory.slots[i].AddSlotcount(-1);
                        break; // 한번만 구울수 있음.
                    }
                }
                
            }

            
        
        
        
    }
}
