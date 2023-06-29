using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigRun : Node
{
    
    Transform transform;
    float speed;
    
    float timer;
    public PigRun(Transform transform, Animal animal)
    {
        this.transform = transform;
        speed = animal.Runspeed;
    }

    public override NodeState Evaluate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.forward * speed, Time.deltaTime);

        return NodeState.RUNNING;
        
        
    }
}
