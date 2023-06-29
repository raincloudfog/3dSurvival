using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PigEat : Node
{
    [SerializeField]
    Animal pig;
    Animator anim;

    float timer;

    public PigEat(Animal animal, Animator anim)
    {
        pig = animal;
        this.anim = anim;
    }

    public override NodeState Evaluate()
    {
        if (pig.Hunger >= 20)
        {
            Debug.Log("��ٸ���");
        }

        timer += Time.deltaTime;
        if(timer >= 1)
        {
            timer = 0;
            pig.Hunger += 100;
            Debug.Log("��Դ���");
        }
        
        return NodeState.RUNNING;
    }
}
