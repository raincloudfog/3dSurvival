using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class ButtonManager : SingletonMono<ButtonManager>
{
    public Inventory _inven;
    [SerializeField] Button[] buttons;

    [SerializeField] Item[] _item;
    public void onAxe()
    {
        _inven.AcquireItem(_item[0], 1);
    }

    public void onpickaxe()
    {
        _inven.AcquireItem(_item[1], 1);
    }

    public void onFire()
    {
        _inven.AcquireItem(_item[2], 1);
        buttons[2].image.raycastTarget = false;
        buttons[2].image.color = Color.black;
    }
}
