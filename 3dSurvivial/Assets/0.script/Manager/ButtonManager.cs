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
    [SerializeField] GameObject GameStop; // �Ͻ����� â

    [SerializeField] Item[] _item;

    [SerializeField] GameObject GameEnd;
    [SerializeField] GameObject ifEnd;

    public void Onrestart()
    {
        
        GameManager.Instance.isRunning = false;
        GameStop.SetActive(false);
        Cursor.visible = false; // Ŀ�� �����
        Cursor.lockState = CursorLockMode.Locked; // Ŀ�� �ᱸ��
        GameManager.Instance.dontmovemouse = false;
        InputManager.Instance.AddFunction(KeyCode.Escape, GameManager.Instance.EscMenu);
        Time.timeScale = 1;
        
    }

    public void ExitGame()
    {
        GameManager.Instance.isRunning = false;
        GameManager.Instance.save();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        GameManager.Instance.isRunning = false;
        Application.Quit();
    }

    public void End()
    {
        GameManager.Instance.isRunning = false;
        GameEnd.SetActive(true);
        ifEnd.SetActive(false);
    }

    public void CanyouEnd()
    {
        GameManager.Instance.isRunning = false;
        ifEnd.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void NoEnd()
    {
        GameManager.Instance.isRunning = false;
        ifEnd.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ItemManager.Instance.GetBoat();
    }

}
