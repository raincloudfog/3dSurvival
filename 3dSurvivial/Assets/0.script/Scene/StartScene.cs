using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] Button[] buttons; //���� ��ư��
    [SerializeField] Button[] buttonstart; // ���� ���� ��ư��
    [SerializeField]Transform movebutton;
    //[SerializeField] RectTransform 

    
    
    SaveData saveData = new SaveData();

    string path;
    string filename;

    private void Awake()
    {
        path = Application.dataPath + "/";
        filename = "newStart";
    }

    //���� ���� ��ư���� ���ְ� ���۳������ư�� ���ش�.
    public void NextStart()
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < buttonstart.Length; i++)
        {
            buttonstart[i].gameObject.SetActive(true);
        }                    
    }

    //�ڷΰ��� �����ϱ� �̾��ϱ� �κ��� ���ְ� �ٽ� ����ȭ������ ���ư���.
    public void Backinterface()
    {

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < buttonstart.Length; i++)
        {
            buttonstart[i].gameObject.SetActive(false);
        }
    }

    //�����ϱ�
    public void NextNewScene()
    {
        saveData.isnew = true;
        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data);
        SceneManager.LoadScene(1);

    }

    //�̾��ϱ�
    public void restartScene()
    {
        saveData.isnew = false;
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + filename, data);
        SceneManager.LoadScene(1);

    }
}
