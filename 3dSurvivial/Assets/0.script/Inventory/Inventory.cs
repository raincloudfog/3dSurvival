using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Inventory : MonoBehaviour
{
    //필요한 컴포넌트
    [SerializeField]
    private GameObject InventoryBase;
    [SerializeField]
    private GameObject SlotsParent;
    [SerializeField]
    private GameObject Createinven;

    public Slot[] slots;
    public bool invenOpen = true;
    // Start is called before the first frame update

    private void Awake()
    {
        InputManager.Instance.AddFunction(KeyCode.I, OpenInventory);
    }
    void Start()
    {
        
        slots = SlotsParent.GetComponentsInChildren<Slot>();
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].Index = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        tryOpenInventory();
    }
    void tryOpenInventory()
    {
        /*if(GameManager.Instance.isRunning == true)
        {
            return;
        }*/
                
    }

    
    public void OpenInventory()
    {
        InventoryBase.SetActive(true);
        ItemManager.Instance.inventoryActivated = false;
        Time.timeScale = 0;
        Cursor.visible = true; // 커서 보이기
        Cursor.lockState = CursorLockMode.None; // 커서 움직이기
        InputManager.Instance.AddFunction(KeyCode.Escape, CloseInventory);
        InputManager.Instance.AddFunction(KeyCode.I, CloseInventory);
    }
    public void CloseInventory()
    {
        InventoryBase.SetActive(false);
        ItemManager.Instance.inventoryActivated = true;
        Time.timeScale = 1;
        Cursor.visible = false; // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 잠구기
        InputManager.Instance.AddFunction(KeyCode.I, OpenInventory);
        InputManager.Instance.AddFunction(KeyCode.Escape, GameManager.Instance.EscMenu);
    }

    public void AcquireItem(Item _item, int _count)
    {
        if(ItemType.Equipment != _item.itemType)
        {
            //아이템이 있을경우
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item != null)
                {
                    if (slots[i].item.itemName == _item.itemName)
                    {
                        slots[i].AddSlotcount(_count);
                        return;
                    }
                }
                
            }
        }
                 
        //아이템이 없을경우 혹은 장비아이템
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("아이템 없을경우 아이템");
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
