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
        Debug.Log("��⸦ ����");
        
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup); // �Ⱦ� �� �ٷ� �Լ��� ��ɷ� �ٲ�� ������ �ȴ���.
        
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == ItemName.Meat)
                    {
                        ItemManager.Instance.GetGrilledmeat();
                        inventory.slots[i].AddSlotcount(-1);
                        break; // �ѹ��� ����� ����.
                    }
                }
                
            }

            
        
        
        
    }
}
