using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class PigMove : Node
{
    private static int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    Transform transform; 
    float speed; // �̵��ӵ�
    float timer; // Ÿ�̸�
    Animal pig;

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
        if (pig.Hunger <= 5)
        {
            Debug.Log("���� �������.!");
            timer = 0;
            return NodeState.FAILURE;
        }

        else if (timer > 2)
        {
            Debug.Log("���� �����δ�!");
            timer = 0;
            Vector3 newvec = new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            transform.position = Vector3.Lerp(transform.position, newvec , speed * Time.deltaTime);
            
        }

        

        return NodeState.RUNNING; 
    }
    
}
