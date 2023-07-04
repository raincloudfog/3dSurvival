using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PIgHunger : Node
{
    Animal pig;
    

    public PIgHunger(Animal animal)
    {
        pig = animal;
        
    }

    public override NodeState Evaluate()
    {
        if (pig.Hunger <= 20)
        {
            //Debug.Log("돼지 배고프다.!");            
            return NodeState.SUCCESS;
        }
        return NodeState.FAILURE;
    }
}