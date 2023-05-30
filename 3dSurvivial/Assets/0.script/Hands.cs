using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    Animator anim;

    bool Act = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
    }
    void ActiveOff()
    {
        anim.SetBool("Active", false);
    }
}
