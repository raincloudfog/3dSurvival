using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class PigRun : Node
{
    private static int playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    Transform transform;
    float speed;

    public PigRun(Transform transform, Animal animal)
    {
        this.transform = transform;
        speed = animal.Runspeed;
    }

    public override NodeState Evaluate()
    {

        var collider = Physics.OverlapSphere(transform.position, 5.0f, playerLayerMask);


        if (collider.Length >= 5)
        {
            return state = NodeState.FAILURE;
        }
        else if (collider.Length <= 5)
        {
            transform.Translate(-transform.forward * speed, Space.World);
        }

        return NodeState.RUNNING;
    }
}
