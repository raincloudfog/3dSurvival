using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : SingletonMono<ButtonManager>
{
    public Inventory _inven;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject GameStop; // 일시정지 창

    [SerializeField] Item[] _item;    

    public void Onrestart()
    {
        GameStop.SetActive(false);
        Cursor.visible = false; // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 잠구기
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        GameManager.Instance.save();
        SceneManager.LoadScene(0);
    }

}
