using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

/// <summary>
/// 플레이어에게 다가가는 코드
/// </summary>
public class GoToPlayerNode : Node
{
    private Transform player;
    private Transform transform;
    
    //생성자에서 플레이어와 트랜스폼값을 받는다.
    public GoToPlayerNode(Transform player, Transform transform)
    {
        this.player = player;
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        transform.LookAt(player); // 플레이어를 바라보고
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime); // 플레이어를 따라가는방식
        Debug.Log("따라갑니다.");
        return state = NodeState.RUNNING;
    }
}
