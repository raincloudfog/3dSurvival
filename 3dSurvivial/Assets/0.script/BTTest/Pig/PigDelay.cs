using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigDelay : Node
{
    public PigDelay() { }
    public PigDelay(List<Node> children) : base(children) { }

    float timer; // 타이머
    public override NodeState Evaluate()
    {
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            Debug.Log("다음 노드 실행");
            return NodeState.SUCCESS; // 다음 노드 실행;
        }

        return NodeState.RUNNING;
    }

    
}
