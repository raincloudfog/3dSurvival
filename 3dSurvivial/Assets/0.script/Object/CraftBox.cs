using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftBox : MonoBehaviour
{
    //�ڱ⸸�� ���Ե� �鱸����

    //���ս� �鱸����
    public enum Recipe
    {
        PickAxe,
        Axe,

        End
    }
    List<Recipe> recipeLIst = new List<Recipe>();
    Dictionary<Recipe, List<ItemName>> RecipeDic = new Dictionary<Recipe, List<ItemName>>();
    Dictionary<Recipe, bool[]> RecipeSlotDic = new Dictionary<Recipe, bool[]>(); //������ ���

    RecipeSlot[] recipeSlots; //9ĭ¥�� �����ǿ� ������ ����.
    //���ս� ���ý�

    //���Ե����� �ʳ� ���� ���� ���ս� üũ�� �ؾ��Ѵ�

    //

    public Slot[] slots; // ���ս� �Ұ�
    [SerializeField] Inventory Inventory;
    [SerializeField] Item[] items;
    [SerializeField] Button creftButton;

    private void Start()
    {
        //slots = GetComponentsInChildren<Slot>();


        int k = 0;
        for (int i = 0; i < recipeLIst.Count; i++) //������ ���ʴ�� �ϳ��� ����
        {
            for (int j = 0; j < RecipeSlotDic[recipeLIst[i]].Length; j++)
            {
                if (RecipeSlotDic[recipeLIst[i]][j]) //������
                {
                    //RecipeDic[recipeLIst[i]][k] //�����ǿ� �ʿ��� k��° �����۳���
                }                
            }                
        }
    }

    // Start is called before the first frame update
    

    

    public void Craft()
    {
        if (slots[0].item != null && slots[1].item != null && slots[2].item != null && slots[4].item != null && slots[7].item != null)
        {
            if (slots[0].item.itemName == ItemName.Rock &&
            slots[1].item.itemName == ItemName.Bush &&
            slots[2].item.itemName == ItemName.Rock &&
            slots[4].item.itemName == ItemName.Wood &&
            slots[7].item.itemName == ItemName.Wood)
            {
                Debug.Log("��� ���u ����");
                PickAxe();
            }
        }
        else if (slots[0].item != null && slots[1].item != null && slots[3].item != null && slots[4].item != null && slots[7].item != null)
        {
            if (slots[0].item.itemName == ItemName.Rock &&
            slots[1].item.itemName == ItemName.Bush &&
            slots[3].item.itemName == ItemName.Rock &&
            slots[4].item.itemName == ItemName.Wood &&
            slots[7].item.itemName == ItemName.Wood)
            {
                Debug.Log("��� ���u ����");
                Axe();
            }
        }
        else if (slots[1].item != null && slots[3].item != null && slots[4].item != null && slots[5].item != null)
        {
            if (slots[1].item.itemName == ItemName.Bush &&
            slots[3].item.itemName == ItemName.Wood &&
            slots[4].item.itemName == ItemName.Wood &&
            slots[5].item.itemName == ItemName.Wood)
            {
                Debug.Log("��ں� ���u ����");
                BoneFire();
            }
        }
        else 
        {
            Debug.Log("�־ȵ�?");
            if (
            slots[0].item.itemName == ItemName.Bush &&
            
            slots[2].item.itemName == ItemName.Bush &&

            slots[1].item.itemName == ItemName.Wood &&
            slots[4].item.itemName == ItemName.Wood &&            
            slots[6].item.itemName == ItemName.Wood &&
            slots[7].item.itemName == ItemName.Wood &&
            slots[8].item.itemName == ItemName.Wood)
            {
                Debug.Log("��Ʈ ���u ����");
                Boat();
            }
            

        }


    }

    public void PickAxe()
    {
        
            slots[0].AddSlotcount(-1);
            slots[1].AddSlotcount(-1);
            slots[2].AddSlotcount(-1);
            slots[4].AddSlotcount(-1);
            slots[7].AddSlotcount(-1);
            Inventory.AcquireItem(items[0], 1);


        
    }
    public void Axe()
    {
        slots[0].AddSlotcount(-1);
        slots[1].AddSlotcount(-1);
        slots[3].AddSlotcount(-1);
        slots[4].AddSlotcount(-1);
        slots[7].AddSlotcount(-1);
        Inventory.AcquireItem(items[1], 1);
    }

    public void BoneFire()
    {
        slots[1].AddSlotcount(-1);
        slots[3].AddSlotcount(-1);
        slots[4].AddSlotcount(-1);
        slots[5].AddSlotcount(-1);
        Inventory.AcquireItem(items[2], 1);
    }

    public void Boat()
    {
        slots[0].AddSlotcount(-1);
        slots[1].AddSlotcount(-1);
        slots[2].AddSlotcount(-1);
        slots[3].AddSlotcount(-1);
        slots[4].AddSlotcount(-1);
        slots[5].AddSlotcount(-1);
        slots[6].AddSlotcount(-1);
        slots[7].AddSlotcount(-1);
        slots[8].AddSlotcount(-1);
        Inventory.AcquireItem(items[3], 1);
    }
    void CheckItemName()
    {

    }
}
