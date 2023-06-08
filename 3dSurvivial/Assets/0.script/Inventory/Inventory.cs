using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Inventory : MonoBehaviour
{
    //�ʿ��� ������Ʈ
    [SerializeField]
    private GameObject InventoryBase;
    [SerializeField]
    private GameObject SlotsParent;
    [SerializeField]
    private GameObject Createinven;

    public Slot[] slots;
    public bool invenOpen = true;
    // Start is called before the first frame update
    void Start()
    {
        slots = SlotsParent.GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        tryOpenInventory();
    }
    void tryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(ItemManager.Instance.inventoryActivated == true)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            if (ItemManager.Instance.CreateinvenActivated == true)
            {
                OpenCreateinven();
            }
            else
            {
                closeCreateinven();
            }
        }
    }

    void OpenCreateinven()
    {
        Createinven.SetActive(true);
        ItemManager.Instance.CreateinvenActivated = false;
        Time.timeScale = 0;
    }

    void closeCreateinven()
    {
        Createinven.SetActive(false);
        ItemManager.Instance.CreateinvenActivated = true;
        Time.timeScale = 1;
    }
    void OpenInventory()
    {
        InventoryBase.SetActive(true);
        ItemManager.Instance.inventoryActivated = false;
        Time.timeScale = 0;

        
    }
    void CloseInventory()
    {
        InventoryBase.SetActive(false);
        ItemManager.Instance.inventoryActivated = true;
        Time.timeScale = 1;
    }

    public void AcquireItem(Item _item, int _count)
    {
        if(Item.ItemType.Equipment != _item.itemType)
        {
            //�������� �������
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].SetSlotcount(_count);
                        return;
                    }
                }
                
            }
        }

        
         
        //�������� ������� Ȥ�� ��������
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("������ ������� ������");
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item,_count);
                return;
            }
        }
    }

    public int GetIsAbleCount(int item_Key)
    {
        return 1 ;
    }
}
