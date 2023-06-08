using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : Itemscript, IWeaponType
{
    RaycastHit hit;
    [SerializeField]
    GameObject Object;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.right * 2f);
    }

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
        if(GameManager.Instance.isActive == false)
        {
            return;
        }

        Debug.Log("µÇ¾ßµÊ");

        Tree treeComponent = Object.GetComponent<Tree>();
        OreRock oreRockComponent = Object.GetComponent<OreRock>();

        if (oreRockComponent != null)
        {
            oreRockComponent.PickUp();
        }
        
    }
}
