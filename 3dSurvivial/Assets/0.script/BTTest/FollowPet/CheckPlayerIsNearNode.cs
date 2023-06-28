using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
/// <summary>
/// 플레이어가 근처인가를 확인하는 코드
/// </summary>
public class CheckPlayerIsNearNode : BehaviorTree.Node
{
    private static int playerLayerMask = 1<< LayerMask.NameToLayer("Player");
    private Transform transform; // 펫의 위치와 동일함.
    //private Animator anim;

    //생성될때 트랜스폼 아마도 본인? 혹은 따라다닐 객체 의 트랜스폼을 얻는다 아마도 자신같다.
    public CheckPlayerIsNearNode(Transform transform) 
    {
        this.transform = transform;
        //anim = transform.GetComponent<Animator>();
    }

    
    public override NodeState Evaluate()
    {
        
        var collider = Physics.OverlapSphere(transform.position, 5.0f, playerLayerMask);

        //만약 플레이어와의 거리가 0이라면 흐음 완전가깝다는건가 이해하기 애매하네 0 으로하니
        if(collider.Length <= 0)
        {
            //Debug.Log("거리가 가까움");
            return state = NodeState.FAILURE; // 근처가 아니므로 혹은 완전 가까이 있으므로 Fail
        }
        else
        {
            //Debug.Log("거리가 멀어짐");

        }

        //throw new System.NotImplementedException();
        return state = NodeState.SUCCESS; //거리가 멀다면Success
    }

    
}
