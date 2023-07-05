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
    [SerializeField] Inventory inventory;

    [SerializeField] Item[] item;

    public Dictionary<Materialtype, int> items = new Dictionary<Materialtype, int>();

    public void GetBoat()
    {
        inventory.AcquireItem(item[0], 1);
    }
    public void GetMeat()
    {
        inventory.AcquireItem(item[1], 1);
    }

    public void GetGrilledmeat()
    {
        inventory.AcquireItem(item[2], 1);
    }

}
