using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public enum Materialtype
{
    Bush,
    Rock,
    Wood,

    End
}
public class ItemManager : SingletonMono<ItemManager>
{
    

    public bool inventoryActivated = true;
    public bool CreateinvenActivated = true;
    
    public Dictionary<Materialtype, int> items = new Dictionary<Materialtype, int>();

    public bool PickAxe()
    {

        if(items[Materialtype.Bush] >= 1 &&
            items[Materialtype.Rock] >=1 &&
            items[Materialtype.Wood] >=1)
        {
            items[Materialtype.Bush] -= 1;
            items[Materialtype.Rock] -= 1;
            items[Materialtype.Wood] -= 1;
            return true;
        }
        else
        {
            Debug.LogError("재료가 부족합니다");
            return false;
        }
        
    }

    public bool Axe()
    {
        if(items[Materialtype.Bush] >=1 &&
            items[Materialtype.Rock] >= 1 &&
            items[Materialtype.Wood] >= 1)
        {
            items[Materialtype.Bush] -= 1;
            items[Materialtype.Rock] -= 1;
            items[Materialtype.Wood] -= 1;
            return true;
        }
        else
        {
            Debug.LogError("재료가 부족합니다.");
            return false;

        }
    }


}
