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
    
    Rigidbody rigid;
    PigBT pigBT;

    //bool isturn = false; // 방향전환


    public PigMove(Transform transform, Animal animal, Rigidbody rigid,PigBT pigBT)
    {
        this.transformTR = transform;
        speed = animal.speed;
        this.pig = animal;
        this.rigid = rigid;
        //isturn = true;
        
        this.pigBT = pigBT;
        //this.nowNodeState = nowNodeState;
    }

   

    public override NodeState Evaluate()
    {
        if(pigBT.timer > 2) // 이 바뀐시간이 진짜 바뀐 시간
        {
            pigBT.timer = 0;
            //Debug.Log("멈춤");
            return NodeState.FAILURE;
        }
        transformTR.position += transformTR.forward * speed * Time.deltaTime;
        return NodeState.RUNNING;
                         
    }

    public NowNodeState NowNode()
    {
        return NowNodeState.Move;
    }
}
