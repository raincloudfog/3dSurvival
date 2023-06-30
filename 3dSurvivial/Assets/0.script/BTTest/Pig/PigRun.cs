using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigRun : Node
{
    Rigidbody rigid;
    Transform transform;
    float speed;

    
    float timer;
    public PigRun(Transform transform, Animal animal, Rigidbody rigid)
    {
        this.transform = transform;
        speed = animal.Runspeed;
        this.rigid = rigid;
    }

    public override NodeState Evaluate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        rigid.AddForce(transform.forward * speed);

        return NodeState.RUNNING;
        
        
    }
}
