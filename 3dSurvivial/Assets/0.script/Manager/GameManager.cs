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
    public bool isnew = false; // 새로 시작 하기 혹은 이어하기 하기 위한 불값
    public Vector3 Lightrotate; // 광원의 로테이트;
    
}
//0620에 만듬
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
    public bool isActive = false; // 상호작용 가능
    public float  Hp = 100; // 플레이어 체력 // int로 하려했으나 체력 감소가 너무 빠른관계로 float로 변경
    public float Hunger = 100; // 플레이어 허기
    public float thirst = 100; // 플레이어 갈증
    public bool dontmovemouse = false; // 마우스 못움직이게 하기

    [SerializeField] GameObject GameStop; // 일시 정지 창
    SaveData saveData = new SaveData();
    [SerializeField] CraftBox craftBox;
    [SerializeField]
    Toolbar toolbar;
    [SerializeField] Inventory inven;

    public Player player;

    [SerializeField] Image[] stats; // 피 음식 수분량 이미지

    [SerializeField] GameObject Sun; //태양

    string path;
    string filename;

    private void Awake()
    {
        path = Application.dataPath + "/";
        filename = "save.json";
        
    }
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene(); // 현재 씬이름
        string sceneName = currentScene.name; // 현재씬이름을 확인하는 스트링값
        Debug.Log("현재 씬 이름: " + sceneName);

        if (sceneName == "Stage") // 만약현재 씬이 stage면
        {

            Cursor.visible = false; // 커서 숨기기
            Cursor.lockState = CursorLockMode.Locked; // 커서 잠구기

            SaveData _saveData = new SaveData();
            string newStart = File.ReadAllText(path + "newStart");
            Time.timeScale = 1f;

            _saveData = JsonUtility.FromJson<SaveData>(newStart);

            if (_saveData.isnew == false)
            {
                Load(); // 로드
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
            Cursor.visible = true; // 커서 보이기
            Cursor.lockState = CursorLockMode.None;
            GameStop.SetActive(true);
            dontmovemouse = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// 스탯이 달면 체력 아이콘 줄어듬
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
    /// 배고픔 갈증 체력감소
    /// </summary>
    void MinusStat()
    {
        Hunger -= Time.deltaTime; // 시간마다 감소
        thirst -= Time.deltaTime; // 시간마다 감소
        if (Hunger <= 0 || thirst <= 0)
        {

            Hunger = Hunger <= 0 ? 0 : Hunger; // 만약 배고픔이 0이하이면 0으로 고정 아닐시 현재 배고픔 수치
            thirst = thirst <= 0 ? 0 : thirst; // 만약 갈증이 0이하이면 0으로 고정 아닐시 현재 갈증 수치
            Hp -= Time.deltaTime;
        }
    }
    
    /// <summary>
    /// 세이브 하는 기능
    /// </summary>
    public void save()
    {
        //0620날 만든 코드 // 0621 수정
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
        // 0621 만듬.
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


        saveData.Hp = Hp; // 세이브에 현재 체력 넣어쥐
        saveData.Hunger = Hunger; // 세이브에 현재 배고픔 넣어주기
        saveData.thirst = thirst; // 세이브에 현재 목마름 넣어주기
        saveData.playerpos = player.transform.position; // 세이브에 현재 플레이어 위치 저장해주기
        saveData.weaponenum = WeaponManager.Instance.weaponenum;
        saveData.Lightrotate = Sun.transform.eulerAngles;

        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data); // 파일주소, 저장할 제이슨 값

        //6월 26일
        Debug.Log(player.OriGinSpeed);
        Debug.Log(player.Speed);
        //
    }

    public void Load()
    {
        SaveData _saveData = new SaveData(); // 로드값을 받아줄 그릇
        string _data = File.ReadAllText(path + filename); // 파일을 읽어옴
        _saveData = JsonUtility.FromJson<SaveData>(_data); // 그릇에다가 그릇에 맞는 음식(스트링)을 넣어줌

        Hp = _saveData.Hp; // 체력 가져오기
        Hunger = _saveData.Hunger; // 허기 가져오기
        thirst = _saveData.thirst; // 목마름 가져오기
        WeaponManager.Instance.weaponenum = _saveData.weaponenum; // 무기 데이터 가져오기

        //0620에 만든 코드
        //Debug.Log(_saveData.slots[0].item.name); 
        for (int i = 0; i < inven.slots.Length; i++)
        {
            
            inven.slots[i].item = _saveData.slotDatas.item[i];
            inven.slots[i].itemCount = _saveData.slotDatas.itemCount[i];
            inven.slots[i].itemimage.sprite = _saveData.slotDatas.sprites[i];
            //0621에 만든코드 인벤토리 저장 성공.
            if(inven.slots[i].item != null)
            {
                inven.slots[i].SetColor(1); // 이이미지 색깔을켜줘야됨.
                if (inven.slots[i].item.itemType != ItemType.Equipment) // 만약 아이템의 타입이 장비타입이 아니면
                {
                    inven.slots[i].CountImage.SetActive(true); // 숫자이미지를 켜주고
                    inven.slots[i].text_Count.text = inven.slots[i].itemCount.ToString();  // 개수를 써줍니다.
                }
                else
                {
                    inven.slots[i].text_Count.text = "0"; // 만약 아니라면 개수는 보여주지않을겁니다.
                    inven.slots[i].CountImage.SetActive(false);

                }
            }
        }

        //
        //0621에 만든 코드 // 툴바 아이템 가져오기
        for (int i = 0; i < toolbar.slots.Length; i++)
        {
            toolbar.slots[i].item = _saveData.Toolbarslots.item[i];
            toolbar.slots[i].itemCount = _saveData.Toolbarslots.itemCount[i];
            toolbar.slots[i].itemimage.sprite = _saveData.Toolbarslots.sprites[i];
            if (toolbar.slots[i].item != null)
            {
                toolbar.slots[i].SetColor(1);
                if (toolbar.slots[i].item.itemType != ItemType.Equipment) // 만약 아이템의 타입이 장비타입이 아니면
                {
                    toolbar.slots[i].CountImage.SetActive(true); // 숫자이미지를 켜주고
                    toolbar.slots[i].text_Count.text = toolbar.slots[i].itemCount.ToString();  // 개수를 써줍니다.
                }
                else
                {
                    toolbar.slots[i].text_Count.text = "0"; // 만약 아니라면 개수는 보여주지않을겁니다.
                    toolbar.slots[i].CountImage.SetActive(false);

                }
            }
        }
        // 조학식에 아이템 넣어놨으면 가져오기
        for (int i = 0; i < craftBox.slots.Length; i++)
        {
            craftBox.slots[i].item = _saveData.craftSlots.item[i];
            craftBox.slots[i].itemCount = _saveData.craftSlots.itemCount[i];
            craftBox.slots[i].itemimage.sprite = _saveData.craftSlots.sprites[i];
            if (craftBox.slots[i].item != null)
            {
                craftBox.slots[i].SetColor(1);
                if (craftBox.slots[i].item.itemType != ItemType.Equipment) // 만약 아이템의 타입이 장비타입이 아니면
                {
                    craftBox.slots[i].CountImage.SetActive(true); // 숫자이미지를 켜주고
                    craftBox.slots[i].text_Count.text = craftBox.slots[i].itemCount.ToString();  // 개수를 써줍니다.
                }
                else
                {
                    craftBox.slots[i].text_Count.text = "0"; // 만약 아니라면 개수는 보여주지않을겁니다.
                    craftBox.slots[i].CountImage.SetActive(false);

                }
            }
        }
        //

        //6월 26일
        Debug.Log(player.OriGinSpeed);
        Debug.Log(player.Speed);
        player.Speed = 5;
        statsFillmount(); //  로드했을때 스탯들 이미지 변하는거 표시하기
        Sun.transform.eulerAngles = _saveData.Lightrotate;
        Time.timeScale = 1;
        //


        player.transform.position = _saveData.playerpos;
        
       
    }

    public void Load2()
    {
        //string str = JsonConvert.SerializeObject(/*저장할 클래스*/);
    }

}
