using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreftBox : MonoBehaviour
{
    [SerializeField] Slot[] slots; // 조합식 할곳
    [SerializeField] Inventory Inventory;
    [SerializeField] Item[] items;
    [SerializeField] Button creftButton;

    private void Awake()
    {
        slots = GetComponentsInChildren<Slot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //slots = GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (slots[0].item.itemName == "Rock" &&
        slots[1].item.itemName == "bush" &&
        slots[2].item.itemName == "Rock" &&
        slots[4].item.itemName == "Wood" &&
        slots[7].item.itemName == "Wood")
        {
            Debug.Log("곡괭이 조햡 가능");
            creftButton.onClick.AddListener(PickAxe);
        }

        else if (slots[0].item.itemName == "Rock" &&
            slots[1].item.itemName == "bush" &&
            slots[3].item.itemName == "Rock" &&
            slots[4].item.itemName == "Wood" &&
            slots[7].item.itemName == "Wood")
        {
            Debug.Log("도끼 조햡 가능");
            creftButton.onClick.AddListener(Axe);
        }
        else
        {
            Debug.Log("조합안되야됨");
        }
        
        
    }

    public void PickAxe()
    {
        
            slots[0].SetSlotcount(-1);
            slots[1].SetSlotcount(-1);
            slots[3].SetSlotcount(-1);
            slots[4].SetSlotcount(-1);
            slots[7].SetSlotcount(-1);
            Inventory.AcquireItem(items[0], 1);


        
    }
    public void Axe()
    {
        slots[0].SetSlotcount(-1);
        slots[1].SetSlotcount(-1);
        slots[3].SetSlotcount(-1);
        slots[4].SetSlotcount(-1);
        slots[7].SetSlotcount(-1);
        Inventory.AcquireItem(items[1], 1);
    }
}
