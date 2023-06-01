using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreRock : ObjectClass
{

    public override void PickUp()
    {
        Hp -= 1;
        Debug.Log("±¤¼® ¶§¸²");
        if (Hp <= 0)
        {
            Debug.Log("±¤¼® ºÎ¼ÅÁü");
            ObjectPool.Instance.ObjectsReturn(this);
        }
    }
    private void OnEnable()
    {
        Hp = 5; // ½ÃÀÛÇßÀ»¶§ Ã¼·Â
    }

}
