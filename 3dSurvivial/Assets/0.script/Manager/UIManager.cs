using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class UIManager : SingletonMono<UIManager>
{
    public GameObject CreftBox; // ũ����Ʈ �ڽ� UI

    public void CreftBoxOn()
    {
        Debug.Log("�ڽ� �ѱ�");
        CreftBox.SetActive(true);
        InputManager.Instance.AddFunction(KeyCode.E, CreftBoxOff);
    }
    public void CreftBoxOff()
    {
        //Debug.Log("�ڽ� ����");
        CreftBox.SetActive(false);
    }
}
