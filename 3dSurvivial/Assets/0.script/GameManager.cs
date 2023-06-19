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
    public bool isnew = false; // ���� ���� �ϱ� Ȥ�� �̾��ϱ� �ϱ� ���� �Ұ�
    
}

public class GameManager : SingletonMono<GameManager>
{


    bool isnew = false;
    public bool isActive = false; // ��ȣ�ۿ� ����
    public float  Hp = 100; // �÷��̾� ü�� // int�� �Ϸ������� ü�� ���Ұ� �ʹ� ��������� float�� ����
    public float Hunger = 100; // �÷��̾� ���
    public float thirst = 100; // �÷��̾� ����

    SaveData saveData = new SaveData();

    [SerializeField] Inventory inven;

    [SerializeField] Player player;

    [SerializeField] Image[] stats; // �� ���� ���з� �̹���

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
        }

        SaveData _saveData = new SaveData();
        string newStart = File.ReadAllText(path + "newStart");


        _saveData = JsonUtility.FromJson<SaveData>(newStart);
        if (_saveData.isnew == false)
        {
            Load(); // �ε�
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
    

    public void save()
    {
        saveData.Hp = Hp; // ���̺꿡 ���� ü�� �־���
        saveData.Hunger = Hunger; // ���̺꿡 ���� ����� �־��ֱ�
        saveData.thirst = thirst; // ���̺꿡 ���� �񸶸� �־��ֱ�
        saveData.playerpos = player.transform.position; // ���̺꿡 ���� �÷��̾� ��ġ �������ֱ�
        saveData.weaponenum = WeaponManager.Instance.weaponenum;
        

        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data); // �����ּ�, ������ ���̽� ��
    }

    public void Load()
    {
        SaveData _saveData = new SaveData(); // �ε尪�� �޾��� �׸�
        string _data = File.ReadAllText(path + filename); // ������ �о��
        _saveData = JsonUtility.FromJson<SaveData>(_data); // �׸����ٰ� �׸��� �´� ����(��Ʈ��)�� �־���

        Hp = _saveData.Hp;
        Hunger = _saveData.Hunger;
        thirst = _saveData.thirst;
        WeaponManager.Instance.weaponenum = _saveData.weaponenum;


        player.transform.position = _saveData.playerpos;
    }

    public void Load2()
    {
        //string str = JsonConvert.SerializeObject(/*������ Ŭ����*/);
    }

}
