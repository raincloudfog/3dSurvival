using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigRun : Node
{
    Rigidbody rigid;
    Transform transform;
    float speed;
    float timer = 0; 
    
    
    public PigRun(Transform transform, Animal animal, Rigidbody rigid)
    {
        this.transform = transform;
        speed = animal.Runspeed;
        this.rigid = rigid;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("�޷�!!");
        timer += Time.deltaTime;
        if(timer > 2)
        {
            timer = 0;
            Debug.Log("�޸���� ������.");
            rigid.velocity = Vector3.zero;
            return NodeState.FAILURE;
        }

        //transform.position += transform.forward * speed * Time.deltaTime;
        //rigid.AddForce(transform.forward * speed);
        rigid.velocity = transform.right * speed;
        return NodeState.RUNNING;
        
        
    }
}
