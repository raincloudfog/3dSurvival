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
        

        //플에이어와 거리가 가까우면 플레이어한태서 멀어집니다.
        if (Vector3.Distance(GameManager.Instance.player.transform.position, _transform.position) < 20)
        {
            //Debug.Log("플레이어 근처다");
            return NodeState.SUCCESS;
        }
        else
        {
            //Debug.Log("플레이어 멀다");
            return NodeState.FAILURE;
        }                
    }
}
