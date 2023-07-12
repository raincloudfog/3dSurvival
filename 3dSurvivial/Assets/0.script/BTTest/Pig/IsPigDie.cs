using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

/// <summary>
/// 돼지의 피가 전부다 달았는지 체크
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
