using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigDelay : Node
{
    public PigDelay() { }
    public PigDelay(List<Node> children) : base(children) { }

    float timer; // Ÿ�̸�
    public override NodeState Evaluate()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            Debug.Log("���� ��� ����");
            return NodeState.SUCCESS; // ���� ��� ����;
        }

        return NodeState.RUNNING;
    }

    
}
