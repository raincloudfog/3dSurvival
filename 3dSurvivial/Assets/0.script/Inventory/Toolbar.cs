using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public Slot[] slots; // 툴바 슬롯들
    [SerializeField] Transform PlayerTF; // 플레이어위치

    [SerializeField] Craft[] craft;//건설될 것들

    GameObject Preview; // 미리보기 프리팹 담을 변수
    
    [SerializeField] bool isCraft = false; // 건설 아이템을 들고 있다면

    //Raycast
    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;
    Ray ray;

    private Vector3 ScreenCenter; // 스크린에 센터

    /*Dictionary<int, KeyCode> numbers = new Dictionary<int, KeyCode>
    {
        { 0, KeyCode.Alpha1 },
        { 1, KeyCode.Alpha2},
        { 2, KeyCode.Alpha3},
        { 3, KeyCode.Alpha4},
        { 4, KeyCode.Alpha5},
        { 5, KeyCode.Alpha6},
        { 6, KeyCode.Alpha7},
        { 7, KeyCode.Alpha8},
        { 8, KeyCode.Alpha9},
        { 9, KeyCode.Alpha0}

    };*/

    

    // Start is called before the first frame update
    void Start()
    {
        //slots = GetComponentsInChildren<Slot>();
        ScreenCenter = new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        
    }

    // Update is called once per frame
    void Update()
    { 
        Inputtoolbar();

        if (isCraft == true)
        {
            
            PreviewPositionUpdate();
            if(Input.GetMouseButtonDown(0))
            {
                try
                {
                    if (Preview.GetComponent<BoneFirePreview>().isBuildeable())
                    {
                        GameObject obj = Instantiate(craft[0].Prefab, Preview.transform);
                        obj.transform.SetParent(null);
                        Destroy(Preview);
                        isCraft = false;
                    }
                    else if (Preview.GetComponent<BoatPreview>().isBuildable())
                    {
                        GameObject obj = Instantiate(craft[1].Prefab, Preview.transform);
                        obj.transform.SetParent(null);
                        Destroy(Preview);
                        isCraft = false;
                    }
                }
                catch
                {
                    if(Preview.GetComponent<BoatPreview>().isBuildable())
                    {
                        GameObject obj = Instantiate(craft[1].Prefab, Preview.transform);
                        obj.transform.SetParent(null);
                        Destroy(Preview);
                        isCraft = false;
                    }
                }
                
            }
        }
    }

    void PreviewPositionUpdate()
    {
        ray = Camera.main.ScreenPointToRay(ScreenCenter);
        if (Physics.Raycast(ray, out hitInfo, range, layerMask))
        {
            
            if(hitInfo.transform != null)
            {
                Debug.Log("감지됨.");
                Vector3 _location = hitInfo.point;
                Preview.transform.position = _location;
            }
        }
    }

    /// <summary>
    /// 툴바에 아이템 사용
    /// </summary>
    void Inputtoolbar()
    {

        if (Input.anyKeyDown)
        {
            // 입력된 키를 문자열로 저장
            string key = Input.inputString;

            // 키에 따라 실행할 함수 선택
            switch (key)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":                
                    Equip(key);
                    break;
                default:
                    // 입력된 키에 대한 처리가 없는 경우
                    break;
            }
        }
    }
    /// <summary>
    /// 장비 장착
    /// </summary>
    /// <param name="key"></param>
    /// 
    void Equip(string key)
    {
        int number;
        if(int.TryParse(key, out number))
        {
            number = int.Parse(key);
            
        }
        
        
       /* if (*//*
            slots[number+1].item.itemType == Item.ItemType.Equipment
                )*/
        
        if(slots[number - 1].item == null) // 만약 툴즈의 슬롯에 아이템이 없으면 그냥 넘어갑니다.
        {
            return;
        }
        if(slots[number-1].item.itemName == ItemName.PickAxe) // 만약 슬롯칸에 곡괭이가 있다면 무기를 활성화해서 곡괭이를 장착해줍니다.
        {
            if(WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.pickAxe )
            {
                WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.End;
                return;
            }
            WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.pickAxe;
            isCraft = false;

        }
        else if (slots[number-1].item.itemName == ItemName.Axe) // 만약 슬롯칸에 도끼가 있다면 무기를 활성화해서 도끼를 장착해줍니다.
        {
            if (WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.Axe)
            {
                WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.End;
                return;
            }
            WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.Axe;
            isCraft = false;
        }
        else if(slots[number -1].item.itemName == ItemName.BoneFire)
        {
            isCraft = true;
            Preview = Instantiate(craft[0].Prefabview,PlayerTF.position + PlayerTF.forward, Quaternion.identity);
            slots[number - 1].SetSlotcount(0);
        }
        else if(slots[number -1].item.itemName == ItemName.Boat)
        {

            ButtonManager.Instance.CanyouEnd();
            slots[number - 1].SetSlotcount(0);
            
        }
        
    }
}
