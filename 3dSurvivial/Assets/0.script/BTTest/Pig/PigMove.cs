using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node, IGetNowNodeState
{
    Transform transform; 
    float speed; // �̵��ӵ�
    float timer; // Ÿ�̸�
    Animal pig;
    
    Rigidbody rigid;

    bool isturn = false; // ������ȯ


    public PigMove(Transform transform, Animal animal, Rigidbody rigid /*, NowNodeState nowNodeState*/)
    {
        this.transform = transform;
        speed = animal.speed;
        this.pig = animal;
        this.rigid = rigid;
        isturn = true;
        //this.nowNodeState = nowNodeState;
    }

   

    public override NodeState Evaluate()
    {


        Debug.Log("�̵���");
            //rigid.velocity = transform.forward * speed* Time.deltaTime;
            rigid.velocity = transform.right * speed;
            return NodeState.RUNNING;
                         
    }

    public NowNodeState NowNode()
    {
        return NowNodeState.Move;
    }
}
