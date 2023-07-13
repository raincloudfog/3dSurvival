using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] Button[] buttons; //시작 버튼들
    [SerializeField] Button[] buttonstart; // 시작 다음 버튼들
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

    //시작 다음 버튼들을 켜주고 시작나가기버튼을 꺼준다.
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

    //뒤로가기 새로하기 이어하기 부분을 꺼주고 다시 메인화면으로 돌아간다.
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

    //새로하기
    public void NextNewScene()
    {
        saveData.isnew = true;
        string data = JsonUtility.ToJson(saveData);

        File.WriteAllText(path + filename, data);
        SceneManager.LoadScene(1);

    }

    //이어하기
    public void restartScene()
    {
        saveData.isnew = false;
        string data = JsonUtility.ToJson(saveData);
        File.WriteAllText(path + filename, data);
        SceneManager.LoadScene(1);

    }
}
