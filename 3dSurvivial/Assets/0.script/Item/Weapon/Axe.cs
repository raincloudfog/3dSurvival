using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Itemscript , IWeaponType
{
    RaycastHit hit;
    GameObject Object;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.right, out hit, 2f))
        {
            Object = hit.collider.gameObject;
        }
        else
        {
            Object = null;
        }
    }
    
    


    public void Attack()
    {
        if (Object == null)
        {
            return;
        }

        Tree treeComponent = Object.GetComponent<Tree>();
        if (treeComponent != null)
        {
            treeComponent.PickUp();
            Debug.Log("왜 오류뜸?");
        }
        else if (treeComponent == null)
        {
            Debug.Log("왜 비어있음?");
        }
    }
}
