using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler,/* IEndDragHandler,*/ IDropHandler
{
    public int Index = 0; // ���� ��ȣ

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� ������ ����
    public Image itemimage; // ������ �̹���

    [SerializeField]
    private TMP_Text text_Count;
    [SerializeField]
    private GameObject CountImage;

    private WeaponManager weaponManager;


    [SerializeField] bool isstackmove = false;    

    void Start()
    {       
        weaponManager = FindObjectOfType<WeaponManager>();
    }

    public void SetItemCountTxt()
    {
        text_Count.text = itemCount.ToString();
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

        if(item.itemType != ItemType.Equipment)
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
        itemCount = _count; 
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // ���� 0�̸� 
        {
            ClearSlot(); // ��ĭ�� �ʱ�ȭ�Ѵ�
        }
    }
    public void AddSlotcount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // ���� 0�̸� 
        {
            ClearSlot(); // ��ĭ�� �ʱ�ȭ�Ѵ�
        }
    }
    public void ClearSlot() // �ʱ�ȭ ����
    {
        Debug.Log("Ŭ���� ������ �ε��� : "+Index);
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
                if(item.itemType == ItemType.Equipment)
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
                else if(item.itemName == "Berry")
                {
                    GameManager.Instance.Hunger += 5f;
                    SetSlotcount(-1);
                }                
            }
        }
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag �� �Ҹ� ������ �ε��� : " + Index);

        if (item != null)
        {
            DragSlot.Instance.SetDragSlot(this);
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                ClearSlot();
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                SetSlotcount(itemCount - 1);
                //isstackmove = true;
                DragSlot.Instance.SetEditItemCount(1);
            }            

            DragSlot.Instance.transform.position = eventData.position;
        }
        
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        //if (item != null)
        {
            DragSlot.Instance.transform.position = eventData.position;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop �Ҹ� ������ �ε��� : " + Index);
        if(DragSlot.Instance.dragSlot != null)//0�� ���� ó���� ��� ������ ģ��. 
        {            
            AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);                 
            DragSlot.Instance.ClearSlot();
        }
    }

}
