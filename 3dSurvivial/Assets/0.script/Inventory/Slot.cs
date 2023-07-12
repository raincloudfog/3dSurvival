using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler/*, IDropHandler*/
{
    public int Index = 0; // ���� ��ȣ

    public Item item; // ȹ���� ������
    public int itemCount; // ȹ���� ������ ����
    public Image itemimage; // ������ �̹���

    public TMP_Text text_Count; // �ؽ�Ʈ�� �۾� //���̺꿡�� ���ϰŶ� �ۺ����� ����
    //Slot saveSlot; //  ���ҿ� ����

    public GameObject CountImage; // 

    public void SetItemCountTxt()
    {
        text_Count.text = itemCount.ToString();
    }
    /// <summary>
    /// �̹��� ���� ����
    /// </summary>
    /// <param name="_alpha"></param>
    public void SetColor(float _alpha)
    {
        Color color = itemimage.color; // �������� �� �����ϰ� ���̵���
        color.a = _alpha; // ������ ���� �� ����
        itemimage.color = color; // ������ �÷��� �÷��� �ٲ��ݴϴ�.

    }

   

    /// <summary>
    /// ������ ȹ��
    /// </summary>
    /// <param name="_item"></param>
    /// <param name="_count"></param>
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item; // �󽽷Կ� �������� ���� �Լ��Դϴ�.
        itemCount = _count; // ������ �� �� �Դϴ�.
        itemimage.sprite = item.itemImage; // �������� ��������Ʈ �Դϴ�.

        if (item.itemType != ItemType.Equipment) // ���� �������� Ÿ���� ���Ÿ���� �ƴϸ�
        {
            CountImage.SetActive(true); // �����̹����� ���ְ�
            text_Count.text = itemCount.ToString();  // ������ ���ݴϴ�.
        }
        else
        {
            text_Count.text = "0"; // ���� �ƴ϶�� ������ �������������̴ϴ�.
            CountImage.SetActive(false);

        }
        SetColor(1); //�׸��� ������ ������ �̹����� �����ϴ�.
    }
    /// <summary>
    /// ������ ���� ����
    /// </summary>
    /// <param name="_count"></param>
    public void SetSlotcount(int _count)
    {
        itemCount = _count; //�������� ���ڸ� �ٲ��ݴϴ�. �������� �ű� �� ���˴ϴ�.
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // ���� 0�̸� 
        {
            ClearSlot(); // ��ĭ�� �ʱ�ȭ�Ѵ�
        }
    }
    /// <summary>
    /// ������ ���� �߰�
    /// </summary>
    /// <param name="_count"></param>
    public void AddSlotcount(int _count)
    {
        itemCount += _count; // ������ �������� ������ �÷��ִ� ���� �Դϴ�.
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0) // ���� 0�̸� 
        {
            ClearSlot(); // ��ĭ�� �ʱ�ȭ�Ѵ�
        }
    }
    public void ClearSlot() // �ʱ�ȭ ����
    {
        //Debug.Log("Ŭ���� ������ �ε��� : "+Index);
        item = null; // �������� null�� �ٲ���
        itemCount = 0; // ���ڵ� 0���� ������ֱ�
        itemimage.sprite = null; // �������̹����� �����ݴϴ�
        SetColor(0);// �̹��� ������ 0���� �ٲ㼭 �����ϰ� ����ϴ�.

        text_Count.text = "0";
        CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) // ������ Ŭ������ ���
        {
            if (item != null) // �������� �ִ°��
            {
                if (item.itemType == ItemType.Equipment)
                {
                    //���� ���� ����
                    if (item.itemName == ItemName.PickAxe)
                    {
                        WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.pickAxe;
                    }
                    else if (item.itemName == ItemName.Axe)
                    {
                        WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.Axe;
                    }
                }//���� �����̸� �԰� ��� ����.
                else if (item.itemName == ItemName.Berry)
                {
                    GameManager.Instance.Hunger += 5f;
                    SetSlotcount(-1); // �԰��� ���� �ϳ� ����
                }
            }
        }
    }





    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag �� �Ҹ� ������ �ε��� : " + Index);


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
    public void OnEndDrag(PointerEventData eventData) // �巡�װ� �µ�� ���Ŀ� ����
    {

        //Debug.Log("�ϴ� ���� �巡��"); // ����巹�� Ȯ���ϴ� �ڵ�
        if (eventData.pointerEnter == null) // ����Ʈ�� ���̸� // ������̸�
        {

            Debug.Log("����� �̿���"); // ����� Ȯ���ϴ� �ڵ�

            if (item == null&&
                DragSlot.Instance.dragSlot.item != null) // ���� �������� ����ְ� �巡�׾����۵� �������
            {
                AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount); // ���� �߰����ְ�
            }
            else // ���� �������� �ִٸ�
            {
                AddSlotcount(DragSlot.Instance.dragSlot.itemCount); // ������ ������ �߰����ݴϴ�.
            }
            DragSlot.Instance.ClearSlot(); // �׸��� �巡�� ������ �ʱ�ȭ �����ݴϴ�.
        }
        else // ����Ʈ�� ���� �ƴϸ�
        {
            if (eventData.pointerEnter.GetComponent<Button>() == true) // ����Ʈ�� ��ư�̶��
            {
                Debug.Log("��ư�̿���"); // ��ư Ȯ���ϴ� �ڵ�
                if (item == null) // ���� �������� ����ִٸ�
                {
                    AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount); // ���� �߰����ְ�

                }
                else// ���� �������� �ִٸ�
                {

                    AddSlotcount(DragSlot.Instance.dragSlot.itemCount); // ������ ������ �߰����ݴϴ�.
                }
                DragSlot.Instance.ClearSlot(); // �׸��� �巡�� ������ �ʱ�ȭ �����ݴϴ�.
            }
            else if(eventData.pointerEnter.GetComponent<Slot>() == true&&
                eventData.pointerEnter.GetComponent<Slot>().item == null)
            {
                Slot slot = eventData.pointerEnter.GetComponent<Slot>();
                Debug.Log("����巡�׿���  ����Ʈ�� ���̾ƴϰ� ");
                Debug.Log("���Ծ������� ���϶�.");
                

                slot.AddItem(DragSlot.Instance.dragSlot.item,
                    DragSlot.Instance.dragSlot.itemCount);
                DragSlot.Instance.ClearSlot();
            }
            else if(eventData.pointerEnter.GetComponent<Slot>() == true &&
                eventData.pointerEnter.GetComponent<Slot>().item != null)
            {
                Slot slot = eventData.pointerEnter.GetComponent<Slot>();
                Debug.Log("����巡�׿���  ����Ʈ�� ���̾ƴϰ� ");
                Debug.Log("���Ծ������� ���� �ƴҶ�.");
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
                        /*Debug.Log(slot + "���Կ� �������� ������");
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
        Debug.Log("����Ȯ��");
        Slot tmp = new Slot(); // tmp�� save�� �־��ְ�
        Debug.Log("tmp���� ���װɸ�");
        Debug.Log(tmp.item);
        Debug.Log(SwapSlot.Instance.saveSlot.item + " / " + SwapSlot.Instance.saveSlot.itemCount);        
        tmp.AddItem(SwapSlot.Instance.saveSlot.item, SwapSlot.Instance.saveSlot.itemCount);
        Debug.Log("tmp���� ���װɸ�2");
        SwapSlot.Instance.saveSlot.AddItem(slot.item, slot.itemCount);
        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
        Debug.Log("���ҿ��� ���װɸ�");
        
        slot.AddSlotcount(tmp.itemCount);
        Debug.Log("���ϴ°������� ���װɸ�");
        
    }

 
    /*public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null) // ���� ����Ʈ�� ���� �ִٸ�
        {
            if (eventData.pointerEnter.GetComponent<Slot>() != null &&
                eventData.pointerEnter.GetComponent<Slot>().item != null) // ����Ʈ�� ������ �ְ� �����۵� �ִٸ�{
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
                        Debug.Log("���Ծ����۰� �巡�� �����۰� �ٸ� �׸��� ���� ���� ����� ����.");
                        SwapSlot.Instance.saveSlot.AddItem(slot.item, slot.itemCount);
                        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                        DragSlot.Instance.ClearSlot();
                    }
                    if(item != null)
                    {
                        Debug.Log("���Ծ����۰� �巡�� �����۰� �ٸ� �׸��� ���� ���� ä���� ����.");
                        Debug.Log(item);
                        GameManager.Instance.inven.AcquireItem(SwapSlot.Instance.saveSlot.item, SwapSlot.Instance.saveSlot.itemCount);
                        slot.AddItem(DragSlot.Instance.dragSlot.item, DragSlot.Instance.dragSlot.itemCount);
                        
                    }

                }

            }
        }
    }*/
}

