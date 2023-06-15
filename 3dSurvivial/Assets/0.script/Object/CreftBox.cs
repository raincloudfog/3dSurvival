using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreftBox : MonoBehaviour
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

    [SerializeField] Slot[] slots; // ���ս� �Ұ�
    [SerializeField] Inventory Inventory;
    [SerializeField] Item[] items;
    [SerializeField] Button creftButton;

    private void Awake()
    {
        slots = GetComponentsInChildren<Slot>();


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
    void Start()
    {
        //slots = GetComponentsInChildren<Slot>();
    }

    // Update is called once per frame
    void Update()
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
                creftButton.onClick.AddListener(PickAxe);
            }
        }

        
        //else if (slots[0].item.itemName == "Rock" &&
        //    slots[1].item.itemName == "bush" &&
        //    slots[3].item.itemName == "Rock" &&
        //    slots[4].item.itemName == "Wood" &&
        //    slots[7].item.itemName == "Wood")
        //{
        //    Debug.Log("���� ���u ����");
        //    creftButton.onClick.AddListener(Axe);
        //}
        //else
        //{
        //    Debug.Log("���վȵǾߵ�");
        //}
        
        
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

    void CheckItemName()
    {

    }
}
