using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class SwapSlot : SingletonMono<SwapSlot>
{
    public Slot saveSlot;

    public void SetSaveSlot(Slot slot) //정보 채워넣기. 그려넣기도 포함됨
    {
        saveSlot.AddItem(slot.item, slot.itemCount);
    }
}
