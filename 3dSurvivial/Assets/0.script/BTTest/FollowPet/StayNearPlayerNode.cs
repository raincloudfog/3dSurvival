using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

/// <summary>
/// 플레이어 근처에서 기다리기를 하는 코드
/// </summary>
public class StayNearPlayerNode : Node
{
    public StayNearPlayerNode(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        //Debug.Log("가만히 있음");
        return state = NodeState.RUNNING; // 노드가 실행중이라고 알려줌.
    }

    
}
