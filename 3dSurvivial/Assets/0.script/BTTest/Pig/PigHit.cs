using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigHit : Node
{
    Animal pig;
    int CurHp;

    public PigHit(Animal animal)
    {
        pig = animal;
        CurHp = animal.Hp;
    }
    
    public override NodeState Evaluate()
    {
        if(CurHp > pig.Hp)
        {
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }   
}
