using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
public class UIManager : SingletonMono<UIManager>
{
    public GameObject CreftBox; // 크래프트 박스 UI

    public void CreftBoxOn()
    {
        Debug.Log("박스 켜기");
        CreftBox.SetActive(true);
        InputManager.Instance.AddFunction(KeyCode.E, CreftBoxOff);
    }
    public void CreftBoxOff()
    {
        //Debug.Log("박스 끄기");
        CreftBox.SetActive(false);
    }
}
