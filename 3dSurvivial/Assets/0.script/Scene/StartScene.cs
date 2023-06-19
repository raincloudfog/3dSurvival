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

    public void NextNewScene()
    {
        saveData.isnew = true;
        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data);
        SceneManager.LoadScene(1);

    }
    public void restartScene()
    {
        saveData.isnew = false;
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + filename, data);
        SceneManager.LoadScene(1);

    }
}
