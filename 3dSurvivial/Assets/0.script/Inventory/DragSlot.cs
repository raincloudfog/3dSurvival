using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class DragSlot : SingletonMono<DragSlot>
{
    public Slot dragSlot;

    public void SetDragSlot(Slot slot) //���� ä���ֱ�. �׷��ֱ⵵ ���Ե�
    {
        dragSlot.AddItem(slot.item, slot.itemCount);
    }

    public void SetEditItemCount(int count) //���� �����ؼ� ui�ݿ�
    {
        dragSlot.itemCount = count;
        dragSlot.SetItemCountTxt();
    }

    public void ClearSlot() //�����
    {        
        dragSlot.ClearSlot();
    }
}
