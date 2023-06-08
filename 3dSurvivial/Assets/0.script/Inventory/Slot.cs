using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerClickHandler
{

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 개수
    public Image itemimage; // 아이템 이미지

    [SerializeField]
    private TMP_Text text_Count;
    [SerializeField]
    private GameObject CountImage;

    private WeaponManager weaponManager;

    void Start()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
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
    /// 아이템 개수 조정
    /// </summary>
    /// <param name="_count"></param>
    public void SetSlotcount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // 만약 0이면 
        {
            ClearSlot(); // 그칸을 초기화한다
        }
    }
    private void ClearSlot() // 초기화 슬롯
    {
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
                if(item.itemType == Item.ItemType.Equipment)
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
                else
                {
                    Debug.Log(item.itemName);
                    SetSlotcount(-1);
                }
            }
        }
    }
}
