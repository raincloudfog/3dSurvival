using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class DragSlot : SingletonMono<DragSlot>
{
    public Slot dragSlot;

    public void SetDragSlot(Slot slot) //정보 채워넣기. 그려넣기도 포함됨
    {
        dragSlot.AddItem(slot.item, slot.itemCount);
    }

    public void SetEditItemCount(int count) //개수 수정해서 ui반영
    {
        dragSlot.itemCount = count;
        dragSlot.SetItemCountTxt();
    }

    public void ClearSlot() //비워냄
    {        
        dragSlot.ClearSlot();
    }
}
