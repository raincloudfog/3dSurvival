using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

/// <summary>
/// �÷��̾�� �ٰ����� �ڵ�
/// </summary>
public class GoToPlayerNode : Node
{
    private Transform player;
    private Transform transform;
    
    //�����ڿ��� �÷��̾�� Ʈ���������� �޴´�.
    public GoToPlayerNode(Transform player, Transform transform)
    {
        this.player = player;
        this.transform = transform;
    }

    public override NodeState Evaluate()
    {
        transform.LookAt(player); // �÷��̾ �ٶ󺸰�
        transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime); // �÷��̾ ���󰡴¹��
        Debug.Log("���󰩴ϴ�.");
        return state = NodeState.RUNNING;
    }
}
