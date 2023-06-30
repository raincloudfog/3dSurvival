using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node
{
    Transform transform; 
    float speed; // �̵��ӵ�
    float timer; // Ÿ�̸�
    Animal pig;
    Vector3 newvec; // �̵� �Ÿ�
    Quaternion NewRotate; // �̵� ����
    Rigidbody rigid;

    bool isturn = false; // ������ȯ


    public PigMove(Transform transform, Animal animal, Rigidbody rigid)
    {
        this.transform = transform;
        speed = animal.speed;
        this.pig = animal;
        this.rigid = rigid;
        isturn = true;
    }

    public override NodeState Evaluate()
    {
        
        //Debug.Log(pig.Hunger);
        timer += Time.deltaTime;
        

        if (timer > 2 && isturn == true)
        {
            Debug.Log("���� �����δ�!");
            timer = 0;

            NewRotate = new Quaternion(0, Random.Range(0, 360), 0, 0);
            transform.rotation *= Quaternion.Slerp(transform.rotation, NewRotate, Time.deltaTime);
            //rigid.velocity = Vector3.zero;
        }
        

        
        Debug.Log("���� �����̴� ��");
        //rigid.velocity = transform.forward * speed* Time.deltaTime;
        transform.position += transform.right * speed * Time.deltaTime;
        


        return NodeState.RUNNING; 
    }
    
}
