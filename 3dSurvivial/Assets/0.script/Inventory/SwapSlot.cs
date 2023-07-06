using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class SwapSlot : SingletonMono<SwapSlot>
{
    public Slot saveSlot;

    public void SetSaveSlot(Slot slot) //���� ä���ֱ�. �׷��ֱ⵵ ���Ե�
    {
        saveSlot.AddItem(slot.item, slot.itemCount);
    }
}
