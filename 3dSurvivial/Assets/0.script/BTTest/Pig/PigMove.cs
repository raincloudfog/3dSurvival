using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node, IGetNowNodeState
{
    Transform transformTR; 
    float speed; // �̵��ӵ�
    float timer; // Ÿ�̸�
    Animal pig;
    
    Rigidbody rigid;
    PigBT pigBT;

    //bool isturn = false; // ������ȯ


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
        if(pigBT.timer > 2) // �� �ٲ�ð��� ��¥ �ٲ� �ð�
        {
            pigBT.timer = 0;
            //Debug.Log("����");
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
