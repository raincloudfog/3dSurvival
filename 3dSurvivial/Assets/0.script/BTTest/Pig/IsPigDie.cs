using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;
public class IsPigDie : Node
{
    Animal pig;
    Animator anim; // 테스트용도
    public IsPigDie(Animal pig, Animator anim)
    {
        this.pig = pig;
        this.anim = anim;
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
