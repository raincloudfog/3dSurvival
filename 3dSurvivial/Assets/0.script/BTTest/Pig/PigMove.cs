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

    public PigMove(Transform transform, Animal animal)
    {
        this.transform = transform;
        speed = animal.speed;
        this.pig = animal;
    }

    public override NodeState Evaluate()
    {
        
        //Debug.Log(pig.Hunger);
        timer += Time.deltaTime;
        

        if (timer > 2)
        {
            Debug.Log("���� �����δ�!");
            timer = 0;

            NewRotate = new Quaternion(0, Random.Range(0, 360), 0,0);
        }

        Vector3 move = Vector3.Lerp(transform.position, transform.forward, speed * Time.deltaTime);
        Debug.Log(move);
        transform.position = move;
        transform.rotation = Quaternion.Slerp(transform.rotation, NewRotate, Time.deltaTime);


        return NodeState.RUNNING; 
    }
    
}
