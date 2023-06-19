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
    public List<Slot> slots = new List<Slot>();
    public bool isnew = false; // 새로 시작 하기 혹은 이어하기 하기 위한 불값
    
}

public class GameManager : SingletonMono<GameManager>
{


    bool isnew = false;
    public bool isActive = false; // 상호작용 가능
    public float  Hp = 100; // 플레이어 체력 // int로 하려했으나 체력 감소가 너무 빠른관계로 float로 변경
    public float Hunger = 100; // 플레이어 허기
    public float thirst = 100; // 플레이어 갈증

    SaveData saveData = new SaveData();

    [SerializeField] Inventory inven;

    [SerializeField] Player player;

    [SerializeField] Image[] stats; // 피 음식 수분량 이미지

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
        }

        SaveData _saveData = new SaveData();
        string newStart = File.ReadAllText(path + "newStart");


        _saveData = JsonUtility.FromJson<SaveData>(newStart);
        if (_saveData.isnew == false)
        {
            Load(); // 로드
        }



    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F5))
        {
            save();
        }
        else if(Input.GetKeyDown(KeyCode.F8))
        {
            Load();
        }
    }

    private void FixedUpdate()
    {
        MinusStat();
        statsFillmount();
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
    

    public void save()
    {
        saveData.Hp = Hp; // 세이브에 현재 체력 넣어쥐
        saveData.Hunger = Hunger; // 세이브에 현재 배고픔 넣어주기
        saveData.thirst = thirst; // 세이브에 현재 목마름 넣어주기
        saveData.playerpos = player.transform.position; // 세이브에 현재 플레이어 위치 저장해주기
        saveData.weaponenum = WeaponManager.Instance.weaponenum;
        

        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data); // 파일주소, 저장할 제이슨 값
    }

    public void Load()
    {
        SaveData _saveData = new SaveData(); // 로드값을 받아줄 그릇
        string _data = File.ReadAllText(path + filename); // 파일을 읽어옴
        _saveData = JsonUtility.FromJson<SaveData>(_data); // 그릇에다가 그릇에 맞는 음식(스트링)을 넣어줌

        Hp = _saveData.Hp;
        Hunger = _saveData.Hunger;
        thirst = _saveData.thirst;
        WeaponManager.Instance.weaponenum = _saveData.weaponenum;


        player.transform.position = _saveData.playerpos;
    }

    public void Load2()
    {
        //string str = JsonConvert.SerializeObject(/*저장할 클래스*/);
    }

}
