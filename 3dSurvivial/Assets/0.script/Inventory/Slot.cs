using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler,IEndDragHandler, IDropHandler
{
    public int Index = 0; // 고유 번호

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 개수
    public Image itemimage; // 아이템 이미지

    [SerializeField]
    private TMP_Text text_Count; // 텍스트의 글씨

    [SerializeField]
    private GameObject CountImage; // 

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
        Color color = itemimage.color; // 아이템이 비어도 투명하게 보이도록
        color.a = _alpha; // 아이템 알파 값 변경
        itemimage.color = color; // 아이템 컬러는 컬러로 바꿔줍니다.
           
    }
    /// <summary>
    /// 아이템 획득
    /// </summary>
    /// <param name="_item"></param>
    /// <param name="_count"></param>
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item; // 빈슬롯에 아이템이 들어가는 함수입니다.
        itemCount = _count; // 아이템 개 수 입니다.
        itemimage.sprite = item.itemImage; // 아이템의 스프라이트 입니다.

        if(item.itemType != ItemType.Equipment) // 만약 아이템의 타입이 장비타입이 아니면
        {
            CountImage.SetActive(true); // 숫자이미지를 켜주고
            text_Count.text = itemCount.ToString();  // 개수를 써줍니다.
        }
        else
        {
            text_Count.text = "0"; // 만약 아니라면 개수는 보여주지않을겁니다.
            CountImage.SetActive(false);
            
        }        
        SetColor(1); //그리고 투명도를 높여서 이미지가 켜집니다.
    }
    /// <summary>
    /// 아이템 개수 조정
    /// </summary>
    /// <param name="_count"></param>
    public void SetSlotcount(int _count)
    {
        itemCount = _count; //아이템의 숫자를 바꿔줍니다. 아이템을 옮길 때 사용됩니다.
        text_Count.text = itemCount.ToString(); 

        if (itemCount <= 0) // 만약 0이면 
        {
            ClearSlot(); // 그칸을 초기화한다
        }
    }
    /// <summary>
    /// 아이템 개수 추가
    /// </summary>
    /// <param name="_count"></param>
    public void AddSlotcount(int _count)
    {
        itemCount += _count; // 동일한 아이템의 개수를 늘려주는 역할 입니다.
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
        itemimage.sprite = null; // 아이템이미지도 없애줍니다
        SetColor(0);// 이미지 투명도를 0으로 바꿔서 투명하게 만듭니다.

        text_Count.text = "0";
        CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right) // 오른쪽 클릭했을 경우
        {
            if(item != null) // 아이템이 있는경우
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
                }//만약 음식이면 먹고 허기 증가.
                else if(item.itemName == "Berry")
                {
                    GameManager.Instance.Hunger += 5f;
                    SetSlotcount(-1); // 먹고난뒤 개수 하나 제거
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
        
         DragSlot.Instance.transform.position = eventData.position;
        
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("일단 엔드 드래그");
        if (eventData.pointerEnter == null)
        {
            Debug.Log("빈공간 이에요");

            if(item == null)
            {
                AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                
            }
            else
            {
                AddSlotcount(DragSlot.Instance.dragSlot.itemCount);
            }
            DragSlot.Instance.ClearSlot();
        }
        else
        {
            if (eventData.pointerEnter.GetComponent<Slot>().item == null)
            {
                eventData.pointerEnter.GetComponent<Slot>().AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                DragSlot.Instance.ClearSlot();
            }
            else if (eventData.pointerEnter.GetComponent<Slot>().item != null)
            {
                if (eventData.pointerEnter.GetComponent<Slot>().item.itemName ==
                DragSlot.Instance.dragSlot.item.itemName)
                {
                    Debug.Log("이름도 일치함.");
                    Debug.Log(eventData.pointerEnter.GetComponent<Slot>().itemCount);
                    eventData.pointerEnter.GetComponent<Slot>().AddSlotcount(DragSlot.Instance.dragSlot.itemCount);
                    DragSlot.Instance.ClearSlot();
                }
            }
        }
       
    }



    public void OnDrop(PointerEventData eventData) // end보다 먼저 발동됨.
    {
        Debug.Log("일단 드롭");
        
        if (eventData.pointerEnter != null)
        {
            if (eventData.pointerEnter.GetComponent<Slot>().item == null)
            {
                eventData.pointerEnter.GetComponent<Slot>().AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                DragSlot.Instance.ClearSlot();
            }
            else if (eventData.pointerEnter.GetComponent<Slot>().item != null)
            {
                if (eventData.pointerEnter.GetComponent<Slot>().item.itemName ==
                DragSlot.Instance.dragSlot.item.itemName)
                {
                    Debug.Log("이름도 일치함.");
                    Debug.Log(eventData.pointerEnter.GetComponent<Slot>().itemCount);
                    eventData.pointerEnter.GetComponent<Slot>().AddSlotcount(DragSlot.Instance.dragSlot.itemCount);
                    DragSlot.Instance.ClearSlot();
                }
            }
            
        }

        //Debug.Log("OnDrop 불린 슬롯의 인덱스 : " + Index);

        else
        {
            AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
            DragSlot.Instance.ClearSlot();
        }
        
            
    }

   
}
