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
        timer += Time.deltaTime; // ������ �����ð��� �ƴ����� ��
        if(timer >= 1)
        {
            action();
            
            timer = 0;
            
            Debug.Log("��Դ���");
        }
        
        return NodeState.RUNNING;
    }
}
