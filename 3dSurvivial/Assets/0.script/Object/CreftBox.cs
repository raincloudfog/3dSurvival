using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreftBox : MonoBehaviour
{
    //자기만의 슬롯들 들구있음

    //조합식 들구있음
    public enum Recipe
    {
        PickAxe,
        Axe,

        End
    }
    List<Recipe> recipeLIst = new List<Recipe>();
    Dictionary<Recipe, List<ItemName>> RecipeDic = new Dictionary<Recipe, List<ItemName>>();
    Dictionary<Recipe, bool[]> RecipeSlotDic = new Dictionary<Recipe, bool[]>(); //무조건 모드

    RecipeSlot[] recipeSlots; //9칸짜리 레시피용 정해진 슬롯.
    //조합식 선택시

    //슬롯들한테 너네 지금 무슨 조합식 체크를 해야한다

    //

    [SerializeField] Slot[] slots; // 조합식 할곳
    [SerializeField] Inventory Inventory;
    [SerializeField] Item[] items;
    [SerializeField] Button creftButton;

    private void Awake()
    {
        slots = GetComponentsInChildren<Slot>();


        int k = 0;
        for (int i = 0; i < recipeLIst.Count; i++) //레시피 차례대로 하나씩 접근
        {
            for (int j = 0; j < RecipeSlotDic[recipeLIst[i]].Length; j++)
            {
                if (RecipeSlotDic[recipeLIst[i]][j]) //들어가야함
                {
                    //RecipeDic[recipeLIst[i]][k] //레시피에 필요한 k번째 아이템네임
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
                Debug.Log("곡괭이 조햡 가능");
                creftButton.onClick.AddListener(PickAxe);
            }
        }

        
        //else if (slots[0].item.itemName == "Rock" &&
        //    slots[1].item.itemName == "bush" &&
        //    slots[3].item.itemName == "Rock" &&
        //    slots[4].item.itemName == "Wood" &&
        //    slots[7].item.itemName == "Wood")
        //{
        //    Debug.Log("도끼 조햡 가능");
        //    creftButton.onClick.AddListener(Axe);
        //}
        //else
        //{
        //    Debug.Log("조합안되야됨");
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
