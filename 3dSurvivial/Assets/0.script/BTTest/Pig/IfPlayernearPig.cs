using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class IfPlayernearPig : Node
{
    Transform _transform;
    //List<Collider> colliders = new List<Collider>();
    
    public IfPlayernearPig(Transform transform)
    {
        _transform = transform;
        
    }

    public override NodeState Evaluate()
    {
        /*Collider[] colliders = Physics.OverlapSphere(_transform.position, 10f);
        //this.colliders.AddRange(colliders);


        foreach (Collider enemy in colliders)
        {
            if (enemy.gameObject.CompareTag("Player"))
            {
                if (Vector3.Distance(enemy.transform.position, _transform.position) < 5)
                {
                    return NodeState.SUCCESS;
                }
            }
        }*/

        
        if (Vector3.Distance(GameManager.Instance.player.transform.position, _transform.position) < 20)
        {
            Debug.Log("플레이어 근처다");
            return NodeState.SUCCESS;
        }
        else
        {
            Debug.Log("플레이어 멀다");
            return NodeState.FAILURE;
        }                
    }
}
