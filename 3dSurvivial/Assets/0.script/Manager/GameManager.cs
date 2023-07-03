using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

[System.Serializable]
public class SaveData
{
    public  WeaponManager.WeaponType weaponenum = WeaponManager.WeaponType.End;
    public Vector3 playerpos;
    public float Hp;
    public float Hunger;
    public float thirst;
    public SlotData slotDatas = new SlotData();
    public SlotData Toolbarslots = new SlotData();
    public SlotData craftSlots = new SlotData();
    public bool isnew = false; // ���� ���� �ϱ� Ȥ�� �̾��ϱ� �ϱ� ���� �Ұ�
    public Vector3 Lightrotate; // ������ ������Ʈ;
    
}
//0620�� ����
[System.Serializable]
public class SlotData
{
    public List<Item> item = new List<Item>();
    public List<Sprite> sprites = new List<Sprite>();
    public List<int> itemCount = new List<int>();
    
}
//
public class GameManager : SingletonMono<GameManager>
{


    bool isnew = false;
    public bool isActive = false; // ��ȣ�ۿ� ����
    public float  Hp = 100; // �÷��̾� ü�� // int�� �Ϸ������� ü�� ���Ұ� �ʹ� ��������� float�� ����
    public float Hunger = 100; // �÷��̾� ���
    public float thirst = 100; // �÷��̾� ����
    public bool dontmovemouse = false; // ���콺 �������̰� �ϱ�

    [SerializeField] GameObject GameStop; // �Ͻ� ���� â
    SaveData saveData = new SaveData();
    [SerializeField] CraftBox craftBox;
    [SerializeField]
    Toolbar toolbar;
    [SerializeField] Inventory inven;

    public Player player;

    [SerializeField] Image[] stats; // �� ���� ���з� �̹���

    [SerializeField] GameObject Sun; //�¾�

    string path;
    string filename;

    private void Awake()
    {
        path = Application.dataPath + "/";
        filename = "save.json";
        
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // ���� ���̸�
        string sceneName = currentScene.name; // ������̸��� Ȯ���ϴ� ��Ʈ����
        Debug.Log("���� �� �̸�: " + sceneName);

        if (sceneName == "Stage") // �������� ���� stage��
        {

            Cursor.visible = false; // Ŀ�� �����
            Cursor.lockState = CursorLockMode.Locked; // Ŀ�� �ᱸ��

            SaveData _saveData = new SaveData();
            string newStart = File.ReadAllText(path + "newStart");
            Time.timeScale = 1f;

            _saveData = JsonUtility.FromJson<SaveData>(newStart);

            if (_saveData.isnew == false)
            {
                Load(); // �ε�
            }
        }               
    }

    private void Update()
    {
        input();
    }

    private void FixedUpdate()
    {
        MinusStat();
        statsFillmount();
    }

    void input()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            save();
        }
        else if (Input.GetKeyDown(KeyCode.F8))
        {
            Load();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true; // Ŀ�� ���̱�
            Cursor.lockState = CursorLockMode.None;
            GameStop.SetActive(true);
            dontmovemouse = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// ������ �޸� ü�� ������ �پ��
    /// </summary>
    void statsFillmount()
    {
        if(stats.Length <= 0)
        {
            return;
        }
        
            stats[0].fillAmount = Hp * 0.01f;
            stats[1].fillAmount = Hunger * 0.01f;
            stats[2].fillAmount = thirst * 0.01f;
        
        
    }
    /// <summary>
    /// ����� ���� ü�°���
    /// </summary>
    void MinusStat()
    {
        Hunger -= Time.deltaTime; // �ð����� ����
        thirst -= Time.deltaTime; // �ð����� ����
        if (Hunger <= 0 || thirst <= 0)
        {

            Hunger = Hunger <= 0 ? 0 : Hunger; // ���� ������� 0�����̸� 0���� ���� �ƴҽ� ���� ����� ��ġ
            thirst = thirst <= 0 ? 0 : thirst; // ���� ������ 0�����̸� 0���� ���� �ƴҽ� ���� ���� ��ġ
            Hp -= Time.deltaTime;
        }
    }
    
    /// <summary>
    /// ���̺� �ϴ� ���
    /// </summary>
    public void save()
    {
        //0620�� ���� �ڵ� // 0621 ����
        SlotData slotsave = new SlotData();
        SlotData toolsave = new SlotData();
        SlotData craftsave = new SlotData();
        for (int i = 0; i < inven.slots.Length; i++)
        {
            
            slotsave.item.Add(inven.slots[i].item);
            slotsave.itemCount.Add(inven.slots[i].itemCount);
            slotsave.sprites.Add(inven.slots[i].itemimage.sprite);                        
            
        }
        saveData.slotDatas.item = slotsave.item;
        saveData.slotDatas.itemCount = slotsave.itemCount;
        saveData.slotDatas.sprites = slotsave.sprites;
        // 0621 ����.
        for (int i = 0; i < toolbar.slots.Length; i++)
        {
            toolsave.item.Add(toolbar.slots[i].item);
            toolsave.itemCount.Add(toolbar.slots[i].itemCount);
            toolsave.sprites.Add(toolbar.slots[i].itemimage.sprite);

        }
        saveData.Toolbarslots.item = toolsave.item;
        saveData.Toolbarslots.itemCount = toolsave.itemCount;
        saveData.Toolbarslots.sprites = toolsave.sprites;

        for (int i = 0; i < craftBox.slots.Length; i++)
        {
            craftsave.item.Add(craftBox.slots[i].item);
            craftsave.itemCount.Add(craftBox.slots[i].itemCount);
            craftsave.sprites.Add(craftBox.slots[i].itemimage.sprite);
        }
        saveData.craftSlots.item = craftsave.item;
        saveData.craftSlots.itemCount = craftsave.itemCount;
        saveData.craftSlots.sprites = craftsave.sprites;

        //


        saveData.Hp = Hp; // ���̺꿡 ���� ü�� �־���
        saveData.Hunger = Hunger; // ���̺꿡 ���� ����� �־��ֱ�
        saveData.thirst = thirst; // ���̺꿡 ���� �񸶸� �־��ֱ�
        saveData.playerpos = player.transform.position; // ���̺꿡 ���� �÷��̾� ��ġ �������ֱ�
        saveData.weaponenum = WeaponManager.Instance.weaponenum;
        saveData.Lightrotate = Sun.transform.eulerAngles;

        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data); // �����ּ�, ������ ���̽� ��

        //6�� 26��
        Debug.Log(player.OriGinSpeed);
        Debug.Log(player.Speed);
        //
    }

    public void Load()
    {
        SaveData _saveData = new SaveData(); // �ε尪�� �޾��� �׸�
        string _data = File.ReadAllText(path + filename); // ������ �о��
        _saveData = JsonUtility.FromJson<SaveData>(_data); // �׸����ٰ� �׸��� �´� ����(��Ʈ��)�� �־���

        Hp = _saveData.Hp; // ü�� ��������
        Hunger = _saveData.Hunger; // ��� ��������
        thirst = _saveData.thirst; // �񸶸� ��������
        WeaponManager.Instance.weaponenum = _saveData.weaponenum; // ���� ������ ��������

        //0620�� ���� �ڵ�
        //Debug.Log(_saveData.slots[0].item.name); 
        for (int i = 0; i < inven.slots.Length; i++)
        {
            
            inven.slots[i].item = _saveData.slotDatas.item[i];
            inven.slots[i].itemCount = _saveData.slotDatas.itemCount[i];
            inven.slots[i].itemimage.sprite = _saveData.slotDatas.sprites[i];
            //0621�� �����ڵ� �κ��丮 ���� ����.
            if(inven.slots[i].item != null)
            {
                inven.slots[i].SetColor(1); // ���̹��� ����������ߵ�.
                if (inven.slots[i].item.itemType != ItemType.Equipment) // ���� �������� Ÿ���� ���Ÿ���� �ƴϸ�
                {
                    inven.slots[i].CountImage.SetActive(true); // �����̹����� ���ְ�
                    inven.slots[i].text_Count.text = inven.slots[i].itemCount.ToString();  // ������ ���ݴϴ�.
                }
                else
                {
                    inven.slots[i].text_Count.text = "0"; // ���� �ƴ϶�� ������ �������������̴ϴ�.
                    inven.slots[i].CountImage.SetActive(false);

                }
            }
        }

        //
        //0621�� ���� �ڵ� // ���� ������ ��������
        for (int i = 0; i < toolbar.slots.Length; i++)
        {
            toolbar.slots[i].item = _saveData.Toolbarslots.item[i];
            toolbar.slots[i].itemCount = _saveData.Toolbarslots.itemCount[i];
            toolbar.slots[i].itemimage.sprite = _saveData.Toolbarslots.sprites[i];
            if (toolbar.slots[i].item != null)
            {
                toolbar.slots[i].SetColor(1);
                if (toolbar.slots[i].item.itemType != ItemType.Equipment) // ���� �������� Ÿ���� ���Ÿ���� �ƴϸ�
                {
                    toolbar.slots[i].CountImage.SetActive(true); // �����̹����� ���ְ�
                    toolbar.slots[i].text_Count.text = toolbar.slots[i].itemCount.ToString();  // ������ ���ݴϴ�.
                }
                else
                {
                    toolbar.slots[i].text_Count.text = "0"; // ���� �ƴ϶�� ������ �������������̴ϴ�.
                    toolbar.slots[i].CountImage.SetActive(false);

                }
            }
        }
        // ���нĿ� ������ �־������ ��������
        for (int i = 0; i < craftBox.slots.Length; i++)
        {
            craftBox.slots[i].item = _saveData.craftSlots.item[i];
            craftBox.slots[i].itemCount = _saveData.craftSlots.itemCount[i];
            craftBox.slots[i].itemimage.sprite = _saveData.craftSlots.sprites[i];
            if (craftBox.slots[i].item != null)
            {
                craftBox.slots[i].SetColor(1);
                if (craftBox.slots[i].item.itemType != ItemType.Equipment) // ���� �������� Ÿ���� ���Ÿ���� �ƴϸ�
                {
                    craftBox.slots[i].CountImage.SetActive(true); // �����̹����� ���ְ�
                    craftBox.slots[i].text_Count.text = craftBox.slots[i].itemCount.ToString();  // ������ ���ݴϴ�.
                }
                else
                {
                    craftBox.slots[i].text_Count.text = "0"; // ���� �ƴ϶�� ������ �������������̴ϴ�.
                    craftBox.slots[i].CountImage.SetActive(false);

                }
            }
        }
        //

        //6�� 26��
        Debug.Log(player.OriGinSpeed);
        Debug.Log(player.Speed);
        player.Speed = 5;
        statsFillmount(); //  �ε������� ���ȵ� �̹��� ���ϴ°� ǥ���ϱ�
        Sun.transform.eulerAngles = _saveData.Lightrotate;
        Time.timeScale = 1;
        //


        player.transform.position = _saveData.playerpos;
        
       
    }

    public void Load2()
    {
        //string str = JsonConvert.SerializeObject(/*������ Ŭ����*/);
    }

}
