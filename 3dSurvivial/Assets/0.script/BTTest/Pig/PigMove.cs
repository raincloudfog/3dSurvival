using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node, IGetNowNodeState
{
    Transform transform; 
    float speed; // 이동속도
    float timer; // 타이머
    Animal pig;
    Animator anim;
    Rigidbody rigid;

    //bool isturn = false; // 방향전환


    public PigMove(Transform transform, Animal animal, Rigidbody rigid, Animator anim /*, NowNodeState nowNodeState*/)
    {
        this.transform = transform;
        speed = animal.speed;
        this.pig = animal;
        this.rigid = rigid;
        //isturn = true;
        this.anim = anim;
        //this.nowNodeState = nowNodeState;
    }

   

    public override NodeState Evaluate()
    {


        //Debug.Log("이동중");
        //rigid.velocity = transform.forward * speed* Time.deltaTime;
        anim.SetTrigger("PigMove");
        rigid.velocity = transform.right * speed;
        return NodeState.RUNNING;
                         
    }

    public NowNodeState NowNode()
    {
        return NowNodeState.Move;
    }
}
