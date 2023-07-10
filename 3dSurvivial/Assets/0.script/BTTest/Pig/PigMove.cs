using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node, IGetNowNodeState
{
    Transform transformTR; 
    float speed; // 이동속도
    float timer; // 타이머
    Animal pig;
    Animator anim;
    Rigidbody rigid;
    PigBT pigBT;

    //bool isturn = false; // 방향전환


    public PigMove(Transform transform, Animal animal, Rigidbody rigid, Animator anim ,PigBT pigBT)
    {
        this.transformTR = transform;
        speed = animal.speed;
        this.pig = animal;
        this.rigid = rigid;
        //isturn = true;
        this.anim = anim;
        this.pigBT = pigBT;
        //this.nowNodeState = nowNodeState;
    }

   

    public override NodeState Evaluate()
    {
        if(pigBT.timer > 2)
        {
            pigBT.timer = 0;
            Debug.Log("멈춤");
            return NodeState.FAILURE;
        }

        //Debug.Log("이동중");
        //rigid.velocity = transform.forward * speed* Time.deltaTime;
        //anim.SetTrigger("PigMove");
        transformTR.position += transformTR.forward * speed * Time.deltaTime;
        /*Debug.Log("rigid.velocity"+rigid.velocity);
        Debug.Log("transform " + transformTR.position);*/
        return NodeState.RUNNING;
                         
    }

    public NowNodeState NowNode()
    {
        return NowNodeState.Move;
    }
}
