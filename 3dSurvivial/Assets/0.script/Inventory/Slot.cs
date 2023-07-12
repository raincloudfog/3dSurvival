using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler/*, IDropHandler*/
{
    public int Index = 0; // 고유 번호

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 개수
    public Image itemimage; // 아이템 이미지

    public TMP_Text text_Count; // 텍스트의 글씨 //세이브에서 쓰일거라 퍼블릭으로 수정
    //Slot saveSlot; //  스왑용 슬롯

    public GameObject CountImage; // 

    public void SetItemCountTxt()
    {
        text_Count.text = itemCount.ToString();
    }
    /// <summary>
    /// 이미지 투명도 조절
    /// </summary>
    /// <param name="_alpha"></param>
    public void SetColor(float _alpha)
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

        if (item.itemType != ItemType.Equipment) // 만약 아이템의 타입이 장비타입이 아니면
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
        //Debug.Log("클리어 슬롯의 인덱스 : "+Index);
        item = null; // 아이템을 null로 바꿔줌
        itemCount = 0; // 숫자도 0으로 만들어주기
        itemimage.sprite = null; // 아이템이미지도 없애줍니다
        SetColor(0);// 이미지 투명도를 0으로 바꿔서 투명하게 만듭니다.

        text_Count.text = "0";
        CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) // 오른쪽 클릭했을 경우
        {
            if (item != null) // 아이템이 있는경우
            {
                if (item.itemType == ItemType.Equipment)
                {
                    //만약 장비면 장착
                    if (item.itemName == ItemName.PickAxe)
                    {
                        WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.pickAxe;
                    }
                    else if (item.itemName == ItemName.Axe)
                    {
                        WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.Axe;
                    }
                }//만약 음식이면 먹고 허기 증가.
                else if (item.itemName == ItemName.Berry)
                {
                    GameManager.Instance.Hunger += 5f;
                    SetSlotcount(-1); // 먹고난뒤 개수 하나 제거
                }
            }
        }
    }





    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag 가 불린 슬롯의 인덱스 : " + Index);


        if (item != null)
        {
            DragSlot.Instance.SetDragSlot(this);
            if (eventData.button == PointerEventData.InputButton.Left)
            {                
                if (eventData.pointerEnter != null)
                {
                    SwapSlot.Instance.saveSlot = eventData.pointerEnter.GetComponent<Slot>();
                    ClearSlot();
                }

            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                SetSlotcount(itemCount - 1);
                //isstackmove = true;
                SwapSlot.Instance.saveSlot = eventData.pointerEnter.GetComponent<Slot>();
                DragSlot.Instance.SetEditItemCount(1);
            }

            DragSlot.Instance.transform.position = eventData.position;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log(DragSlot.Instance.dragSlot.item);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            ClearSlot();
        }
        DragSlot.Instance.transform.position = eventData.position;

    }
    public void OnEndDrag(PointerEventData eventData) // 드래그가 온드랍 이후에 나옴
    {

        //Debug.Log("일단 엔드 드래그"); // 엔드드레그 확인하는 코드
        if (eventData.pointerEnter == null) // 포인트에 널이면 // 빈공간이면
        {

            Debug.Log("빈공간 이에요"); // 빈공간 확인하는 코드

            if (item == null&&
                DragSlot.Instance.dragSlot.item != null) // 만약 아이템이 비어있고 드래그아이템도 있을경우
            {
                AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount); // 새로 추가해주고
            }
            else // 만약 아이템이 있다면
            {
                AddSlotcount(DragSlot.Instance.dragSlot.itemCount); // 아이템 갯수를 추가해줍니다.
            }
            DragSlot.Instance.ClearSlot(); // 그리고 드래그 슬롯을 초기화 시켜줍니다.
        }
        else // 포인트가 널이 아니면
        {
            if (eventData.pointerEnter.GetComponent<Button>() == true) // 포인트가 버튼이라면
            {
                Debug.Log("버튼이에요"); // 버튼 확인하는 코드
                if (item == null) // 만약 아이템이 비어있다면
                {
                    AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount); // 새로 추가해주고

                }
                else// 만약 아이템이 있다면
                {

                    AddSlotcount(DragSlot.Instance.dragSlot.itemCount); // 아이템 갯수를 추가해줍니다.
                }
                DragSlot.Instance.ClearSlot(); // 그리고 드래그 슬롯을 초기화 시켜줍니다.
            }
            else if(eventData.pointerEnter.GetComponent<Slot>() == true&&
                eventData.pointerEnter.GetComponent<Slot>().item == null)
            {
                Slot slot = eventData.pointerEnter.GetComponent<Slot>();
                Debug.Log("엔드드래그에서  포인트가 널이아니고 ");
                Debug.Log("슬롯아이템이 널일때.");
                

                slot.AddItem(DragSlot.Instance.dragSlot.item,
                    DragSlot.Instance.dragSlot.itemCount);
                DragSlot.Instance.ClearSlot();
            }
            else if(eventData.pointerEnter.GetComponent<Slot>() == true &&
                eventData.pointerEnter.GetComponent<Slot>().item != null)
            {
                Slot slot = eventData.pointerEnter.GetComponent<Slot>();
                Debug.Log("엔드드래그에서  포인트가 널이아니고 ");
                Debug.Log("슬롯아이템이 널이 아닐때.");
                if(slot.item == DragSlot.Instance.dragSlot.item)
                {
                    slot.AddSlotcount(DragSlot.Instance.dragSlot.itemCount);
                    DragSlot.Instance.ClearSlot();
                    return;
                }
                else if(slot.item != DragSlot.Instance.dragSlot.item)
                {
                    if (item != null)
                    {
                        Chageslot(slot);
                        /*Debug.Log(slot + "슬롯에 아이템이 있을때");
                        SwapSlot.Instance.saveSlot.AddItem(slot.item, slot.itemCount);
                        slot.AddItem(item, itemCount);
                        
                        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);*/
                    }
                    SwapSlot.Instance.saveSlot.AddItem(slot.item, slot.itemCount);
                    slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                    
                    
                }
                
            }
        }

    }
    void Chageslot(Slot slot)// slot1 = save , slot2 = evnetData
    {
        Debug.Log("버그확인");
        Slot tmp = new Slot(); // tmp에 save를 넣어주고
        Debug.Log("tmp에서 버그걸림");
        Debug.Log(tmp.item);
        Debug.Log(SwapSlot.Instance.saveSlot.item + " / " + SwapSlot.Instance.saveSlot.itemCount);        
        tmp.AddItem(SwapSlot.Instance.saveSlot.item, SwapSlot.Instance.saveSlot.itemCount);
        Debug.Log("tmp에서 버그걸림2");
        SwapSlot.Instance.saveSlot.AddItem(slot.item, slot.itemCount);
        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
        Debug.Log("스왑에서 버그걸림");
        
        slot.AddSlotcount(tmp.itemCount);
        Debug.Log("더하는과정에서 버그걸림");
        
    }

 
    /*public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null) // 만약 포인트에 무언가 있다면
        {
            if (eventData.pointerEnter.GetComponent<Slot>() != null &&
                eventData.pointerEnter.GetComponent<Slot>().item != null) // 포인트에 슬롯이 있고 아이템도 있다면{
            {
                Slot slot = eventData.pointerEnter.GetComponent<Slot>();
                if (slot.item == DragSlot.Instance.dragSlot.item)
                {
                    if (slot.item.itemType == ItemType.Equipment)
                    {
                        DragSlot.Instance.ClearSlot();
                        return;
                    }
                    slot.AddSlotcount(DragSlot.Instance.dragSlot.itemCount);
                    DragSlot.Instance.ClearSlot();
                    return;
                }
                else if (slot.item != DragSlot.Instance.dragSlot.item)
                {
                    
                    if (item == null)
                    {
                        Debug.Log("슬롯아이템과 드래그 아이템과 다름 그리고 현재 슬롯 비워져 있음.");
                        SwapSlot.Instance.saveSlot.AddItem(slot.item, slot.itemCount);
                        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                        DragSlot.Instance.ClearSlot();
                    }
                    if(item != null)
                    {
                        Debug.Log("슬롯아이템과 드래그 아이템과 다름 그리고 현재 슬롯 채워져 있음.");
                        Debug.Log(item);
                        GameManager.Instance.inven.AcquireItem(SwapSlot.Instance.saveSlot.item, SwapSlot.Instance.saveSlot.itemCount);
                        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                        
                    }

                }

            }
        }
    }*/
}

