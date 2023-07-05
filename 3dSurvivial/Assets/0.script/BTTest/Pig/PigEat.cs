using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

public class PigEat : Node
{
    [SerializeField]
    Animal pig;
    Animator anim;
    Action action;
    float timer;

    public PigEat(Animal animal, Animator anim,Action action)
    {
        pig = animal;
        this.anim = anim;
        this.action = action;
    }

    public override NodeState Evaluate()
    {
       
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            action();
            
            timer = 0;
            
            Debug.Log("นไธิดยม฿");
        }
        
        return NodeState.RUNNING;
    }
}
