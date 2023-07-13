using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : SingletonMono<ButtonManager>
{
    [SerializeField]AudioSource clicksound;
    public Inventory _inven;
    [SerializeField] Button[] buttons;
    [SerializeField] GameObject GameStop; // 일시정지 창

    [SerializeField] Item[] _item;

    [SerializeField] GameObject GameEnd;
    [SerializeField] GameObject ifEnd;

    //일시정지 풀어주는 버튼
    public void Onrestart()
    {
        clicksound.Play();
        GameManager.Instance.isRunning = false;
        GameStop.SetActive(false);
        Cursor.visible = false; // 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked; // 커서 잠구기
        GameManager.Instance.dontmovemouse = false;
        InputManager.Instance.AddFunction(KeyCode.Escape, GameManager.Instance.EscMenu);
        Time.timeScale = 1;
        
    }
    // 저장하고 메인메뉴 버튼
    public void ExitGame()
    {
        clicksound.Play();
        GameManager.Instance.isRunning = false;
        GameManager.Instance.save();
        SceneManager.LoadScene(0);
    }
    //게임 끄기 버튼
    public void Exit()
    {
        clicksound.Play();
        GameManager.Instance.isRunning = false;
        Application.Quit();
    }

    // 게임엔딩
    public void End()
    {
        clicksound.Play();
        GameManager.Instance.isRunning = true;
        GameEnd.SetActive(true);
        ifEnd.SetActive(false);
    }

    // 정말로 엔딩을 할거냐고 물어보는 버튼
    public void CanyouEnd()
    {
        clicksound.Play();
        GameManager.Instance.isRunning = true;
        ifEnd.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // 엔딩을 (끝내기)를 안하는 버튼
    public void NoEnd()
    {
        clicksound.Play();
        GameManager.Instance.isRunning = false;
        ifEnd.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ItemManager.Instance.GetBoat();
    }

}
