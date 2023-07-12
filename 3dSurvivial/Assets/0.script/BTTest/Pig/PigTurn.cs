using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PigTurn : Node
{
    Animal pig;
    Transform transform;
 
    public PigTurn(Transform transform, Animal animal/*, NowNodeState nowNodeState*/)
    {
        this.transform = transform;
        pig = animal;
        //this.nowNodeState = nowNodeState;
    }

    public override NodeState Evaluate()
    {
        int rand = Random.Range(-180, 180);
        //Debug.Log(rand + "rand ");
        transform.rotation = Quaternion.Euler(new Vector3(0,rand , 0));
        //Debug.Log("µ½´Ï´Ù.");
        return NodeState.RUNNING;
        
    }

}
