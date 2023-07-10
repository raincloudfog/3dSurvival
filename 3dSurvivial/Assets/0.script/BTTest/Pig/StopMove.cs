using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class StopMove : Node
{
    Rigidbody rigid;
    float[] rand = new float[] { 50, 50 };
    public StopMove(Rigidbody rigid)
    {
        this.rigid = rigid;
    }

    public override NodeState Evaluate()
    {
        float random = Choose(rand);
        if (Choose(rand) == 0)
        {
            rigid.velocity = Vector3.zero;
            Debug.Log("가만히 있는중");
        }
        else
        {
            Debug.Log("멈춤 끝남");
            return NodeState.FAILURE;
        }

        return NodeState.RUNNING;
    }

    float Choose(float[] probs)
    {
        float total = 0;
        foreach (float item in probs)
        {
            total += item;
        }
        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}
