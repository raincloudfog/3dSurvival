using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node
{
    Transform transform; 
    float speed; // 이동속도
    float timer; // 타이머
    Animal pig;
    Vector3 newvec; // 이동 거리
    Quaternion NewRotate; // 이동 방향
    Rigidbody rigid;

    bool isturn = false; // 방향전환


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
            Debug.Log("돼지 움직인다!");
            timer = 0;

            NewRotate = new Quaternion(0, Random.Range(0, 360), 0, 0);
            transform.rotation *= Quaternion.Slerp(transform.rotation, NewRotate, Time.deltaTime);
            //rigid.velocity = Vector3.zero;
        }
        

        
        Debug.Log("돼지 움직이는 중");
        //rigid.velocity = transform.forward * speed* Time.deltaTime;
        transform.position += transform.right * speed * Time.deltaTime;
        


        return NodeState.RUNNING; 
    }
    
}
