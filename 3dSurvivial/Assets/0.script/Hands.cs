using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    Animator anim; // 애니메이션
    Itemscript Weapon; // 손에 있는 무기
    
    private void Awake()
    {

    }
    private void Start()
    {
        anim = GetComponent<Animator>(); // 나중에 수정해서 인스펙터로 직접 넣을 것.
        
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
