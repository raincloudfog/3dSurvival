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

    public void Onrestart()
    {
        GameStop.SetActive(false);
        Cursor.visible = false; // Ŀ�� �����
        Cursor.lockState = CursorLockMode.Locked; // Ŀ�� �ᱸ��
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        GameManager.Instance.save();
        SceneManager.LoadScene(0);
    }

}
