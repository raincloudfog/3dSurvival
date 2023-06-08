using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    Animator anim;
    Itemscript Weapon; // 손에 있는 무기
    IWeaponType weaponType;
    private void Awake()
    {
        Weapon = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Itemscript>();
        
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            ActiveOn();
        }*/
        if(Input.GetMouseButton(0))
        {
            ActiveOn();
        }
        if(Input.GetMouseButtonUp(0))
        {
            ActiveOff();
        }
    }
    void ActiveOn()
    {             
        anim.SetBool("Active", true);
        
        GameManager.Instance.isActive = true;
        
        
        

    }
    void ActiveOff()
    {
        anim.SetBool("Active", false);
        GameManager.Instance.isActive = false;
    }
   
}
