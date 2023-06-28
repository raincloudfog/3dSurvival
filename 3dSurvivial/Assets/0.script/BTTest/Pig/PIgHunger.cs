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
        if(pig.Hunger >= 20)
        {
            Debug.Log("นไดูธิภฝ");
            return NodeState.FAILURE;
        }
        pig.Hunger += 5;
        Debug.Log("นไธิดยม฿");
        return NodeState.RUNNING;
    }
}
