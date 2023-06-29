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
            Debug.Log("돼지 움직인다!");
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
