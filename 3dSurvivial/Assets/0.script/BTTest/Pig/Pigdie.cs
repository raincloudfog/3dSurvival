using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System;

public class Pigdie : Node
{
    GameObject pig;
    Action action;
    public Pigdie(GameObject pig,Action action)
    {
        this.pig = pig;
        this.action = action;
    }

    public override NodeState Evaluate()
    {
        action();
        return NodeState.RUNNING;
    }
}
