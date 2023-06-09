using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;

public class DragSlot : SingletonMono<DragSlot>
{
    public Slot dragSlot;

    [SerializeField]
    private Image imageItem;

    

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;
        SetColor(1);
    }

    public void SetColor(float _alpha)
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
