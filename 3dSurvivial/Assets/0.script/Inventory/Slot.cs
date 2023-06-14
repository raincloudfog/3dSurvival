using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler,/* IEndDragHandler,*/ IDropHandler
{
    public int Index = 0; // 고유 번호

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 개수
    public Image itemimage; // 아이템 이미지

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
    /// 이미지 투명도 조절
    /// </summary>
    /// <param name="_alpha"></param>
    private void SetColor(float _alpha)
    {
        Color color = itemimage.color;
        color.a = _alpha;
        itemimage.color = color;
           
    }
    /// <summary>
    /// 아이템 획득
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
    /// 아이템 개수 조정
    /// </summary>
    /// <param name="_count"></param>
    public void SetSlotcount(int _count)
    {
        itemCount = _count; 
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // 만약 0이면 
        {
            ClearSlot(); // 그칸을 초기화한다
        }
    }
    public void AddSlotcount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // 만약 0이면 
        {
            ClearSlot(); // 그칸을 초기화한다
        }
    }
    public void ClearSlot() // 초기화 슬롯
    {
        Debug.Log("클리어 슬롯의 인덱스 : "+Index);
        item = null; // 아이템을 null로 바꿔줌
        itemCount = 0; // 숫자도 0으로 만들어주기
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
                    //만약 장비면 장착
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
        Debug.Log("OnBeginDrag 가 불린 슬롯의 인덱스 : " + Index);

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
        Debug.Log("OnDrop 불린 슬롯의 인덱스 : " + Index);
        if(DragSlot.Instance.dragSlot != null)//0번 내가 처음에 들기 시작한 친구. 
        {            
            AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);                 
            DragSlot.Instance.ClearSlot();
        }
    }

}
