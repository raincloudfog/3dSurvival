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
        if (ItemManager.Instance.items.ContainsKey(Materialtype.Bush) &&
            ItemManager.Instance.items.ContainsKey(Materialtype.Rock) &&
            ItemManager.Instance.items.ContainsKey(Materialtype.Wood))
        {
            if (ItemManager.Instance.PickAxe() == true) // ���� ������ �Ŵ����� ���ս��� �����Ǹ� ��� ȹ��
            {
                _inven.AcquireItem(_item[0], 1);
            }


        }

        
    }

    public void onpickaxe()
    {
        if(ItemManager.Instance.items.ContainsKey(Materialtype.Bush) &&
            ItemManager.Instance.items.ContainsKey(Materialtype.Rock) &&
            ItemManager.Instance.items.ContainsKey(Materialtype.Wood))
        {
            if(ItemManager.Instance.Axe() == true) // ���� ������ �Ŵ����� ���ս��� �����Ǹ� ��� ȹ��
            {
                _inven.AcquireItem(_item[1], 1);
            }
            
            
        }
        
    }

    public void onFire()
    {
        _inven.AcquireItem(_item[2], 1);
        buttons[2].image.raycastTarget = false;
        buttons[2].image.color = Color.black;
    }

}
