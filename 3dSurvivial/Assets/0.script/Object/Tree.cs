using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ObjectClass
{

    private void OnEnable()
    {
        Hp = 5;
    }
    public override void PickUp()
    {
        Hp -= 1;
        if (Hp <= 0)
        {
            Debug.Log("³ª¹« ºÎ¼ÅÁü");
            InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
            ObjectPool.Instance.ObjectsReturn(this);
        }
        InputManager.Instance.AddFunction(KeyCode.E, NoPickup);
    }


    
}
