using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    public Slot[] slots; // ���� ���Ե�
    [SerializeField] Transform PlayerTF; // �÷��̾���ġ

    [SerializeField] Craft[] craft;//�Ǽ��� �͵�

    GameObject Preview; // �̸����� ������ ���� ����
    
    [SerializeField] bool isCraft = false; // �Ǽ� �������� ��� �ִٸ�

    //Raycast
    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;
    Ray ray;

    private Vector3 ScreenCenter; // ��ũ���� ����

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
                Debug.Log("������.");
                Vector3 _location = hitInfo.point;
                Preview.transform.position = _location;
            }
        }
    }

    /// <summary>
    /// ���ٿ� ������ ���
    /// </summary>
    void Inputtoolbar()
    {

        if (Input.anyKeyDown)
        {
            // �Էµ� Ű�� ���ڿ��� ����
            string key = Input.inputString;

            // Ű�� ���� ������ �Լ� ����
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
                    // �Էµ� Ű�� ���� ó���� ���� ���
                    break;
            }
        }
    }
    /// <summary>
    /// ��� ����
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
        
        if(slots[number - 1].item == null) // ���� ������ ���Կ� �������� ������ �׳� �Ѿ�ϴ�.
        {
            return;
        }
        if(slots[number-1].item.itemName == ItemName.PickAxe) // ���� ����ĭ�� ��̰� �ִٸ� ���⸦ Ȱ��ȭ�ؼ� ��̸� �������ݴϴ�.
        {
            if(WeaponManager.Instance.weaponenum == WeaponManager.WeaponType.pickAxe )
            {
                WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.End;
                return;
            }
            WeaponManager.Instance.weaponenum = WeaponManager.WeaponType.pickAxe;
            isCraft = false;

        }
        else if (slots[number-1].item.itemName == ItemName.Axe) // ���� ����ĭ�� ������ �ִٸ� ���⸦ Ȱ��ȭ�ؼ� ������ �������ݴϴ�.
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
