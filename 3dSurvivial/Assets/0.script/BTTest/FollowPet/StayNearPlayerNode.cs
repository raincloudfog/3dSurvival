using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

/// <summary>
/// �÷��̾� ��ó���� ��ٸ��⸦ �ϴ� �ڵ�
/// </summary>
public class StayNearPlayerNode : Node
{
    public StayNearPlayerNode(Transform transform)
    {

    }

    public override NodeState Evaluate()
    {
        //Debug.Log("������ ����");
        return state = NodeState.RUNNING; // ��尡 �������̶�� �˷���.
    }

    
}
