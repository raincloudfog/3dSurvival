using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

/// <summary>
/// ������ �ǰ� ���δ� �޾Ҵ��� üũ
/// </summary>
public class IsPigDie : Node
{
    Animal pig;
    
    public IsPigDie(Animal pig)
    {
        this.pig = pig;
    }

    public override NodeState Evaluate()
    {
        
        if(pig.Hp <= 0)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }


}
