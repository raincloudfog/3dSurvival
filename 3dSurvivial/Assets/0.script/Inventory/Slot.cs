using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    private Vector3 Originpos;

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� ������ ����
    public Image itemimage; // ������ �̹���

    [SerializeField]
    private TMP_Text text_Count;
    [SerializeField]
    private GameObject CountImage;

    private WeaponManager weaponManager;

    void Start()
    {
        Originpos = transform.position;
        weaponManager = FindObjectOfType<WeaponManager>();
    }

    /// <summary>
    /// �̹��� ���� ����
    /// </summary>
    /// <param name="_alpha"></param>
    private void SetColor(float _alpha)
    {
        Color color = itemimage.color;
        color.a = _alpha;
        itemimage.color = color;
           
    }
    /// <summary>
    /// ������ ȹ��
    /// </summary>
    /// <param name="_item"></param>
    /// <param name="_count"></param>
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemimage.sprite = item.itemImage;

        if(item.itemType != Item.ItemType.Equipment)
        {
            CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            CountImage.SetActive(false);
            
        }        
        SetColor(1);
    }
    /// <summary>
    /// ������ ���� ����
    /// </summary>
    /// <param name="_count"></param>
    public void SetSlotcount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // ���� 0�̸� 
        {
            ClearSlot(); // ��ĭ�� �ʱ�ȭ�Ѵ�
        }
    }
    private void ClearSlot() // �ʱ�ȭ ����
    {
        item = null; // �������� null�� �ٲ���
        itemCount = 0; // ���ڵ� 0���� ������ֱ�
        itemimage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item != null)
            {
                if(item.itemType == Item.ItemType.Equipment)
                {
                    //���� ���� ����
                    if(item.itemName == "PickAxe")
                    {
                        WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.pickAxe;
                    }
                    else if(item.itemName == "Axe")
                    {
                        WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.Axe;
                    }
                }
                if(item.itemName == "Berry")
                {
                    GameManager.Instance.Hunger += 5f;
                    SetSlotcount(-1);
                }
                else
                {
                    Debug.Log(item.itemName);
                    SetSlotcount(-1);
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            DragSlot.Instance.dragSlot = this;
            DragSlot.Instance.DragSetImage(itemimage);

            DragSlot.Instance.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.Instance.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragSlot.Instance.SetColor(0);
        DragSlot.Instance.dragSlot = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(DragSlot.Instance.dragSlot != null)
        {
            ChangeSlot();
        }
        
    }

    private void ChangeSlot()
    {
        Item _tmpItem = item;
        int _tmpItemCount = itemCount;

        AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);

        if(_tmpItem != null)
        {
            DragSlot.Instance.dragSlot.AddItem(_tmpItem, _tmpItemCount);
        }
        else
        {
            DragSlot.Instance.dragSlot.ClearSlot();
        }
    }
}
