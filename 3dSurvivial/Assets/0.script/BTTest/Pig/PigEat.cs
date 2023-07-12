using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

public class PigEat : Node
{
    
    Action action;
    float timer;

    public PigEat(Action action)
    {
        this.action = action;
    }

    public override NodeState Evaluate()
    {
        timer += Time.deltaTime; // 실제로 지난시간은 아닐지도 모름
        if(timer >= 1)
        {
            action();
            
            timer = 0;
            
            Debug.Log("밥먹는중");
        }
        
        return NodeState.RUNNING;
    }
}
