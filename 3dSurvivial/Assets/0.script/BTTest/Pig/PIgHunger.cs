using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PIgHunger : Node
{
    Animal pig;
    Animator anim;


    public PIgHunger(Animal animal, Animator anim)
    {
        pig = animal;
        this.anim = anim;
    }

    public override NodeState Evaluate()
    {
        if (pig.Hunger <= 20)
        {
            //Debug.Log("���� �������.!");            
            return NodeState.SUCCESS;
        }
        anim.SetBool("PigEat", false);
        return NodeState.FAILURE;
    }
}