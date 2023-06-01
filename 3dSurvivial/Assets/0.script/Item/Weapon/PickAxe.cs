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

        Debug.Log("�Ǿߵ�");

        Tree treeComponent = Object.GetComponent<Tree>();
        OreRock oreRockComponent = Object.GetComponent<OreRock>();

        
        if (treeComponent != null)
        {
            treeComponent.PickUp();
            Debug.Log("�� ������?");
        }
        else if (treeComponent == null)
        {
            Debug.Log("�� �������?");
        }

        if (oreRockComponent != null)
        {
            oreRockComponent.PickUp();
        }
        
    }
}
