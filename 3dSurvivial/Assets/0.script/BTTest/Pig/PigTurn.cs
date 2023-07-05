using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class PigTurn : Node, IGetNowNodeState,IDgree
{
    Animal pig;
    Transform _transform;
    float degree; //회전할 각도
    Quaternion Vecdgree;
    
    public PigTurn(Transform transform, Animal animal/*, NowNodeState nowNodeState*/)
    {
        _transform = transform;
        pig = animal;
        //this.nowNodeState = nowNodeState;
    }

    public void Dgree()
    {
        degree = Random.Range(-180,180);
        Vecdgree = Quaternion.Euler(0, degree, 0);
    }

    public override NodeState Evaluate()
    {
        if (_transform.rotation == Vecdgree) 
        {
            return NodeState.SUCCESS;
        }
        else
        { 
            _transform.rotation = Quaternion.Lerp(_transform.rotation, Vecdgree, Time.deltaTime * 5f);
            return NodeState.RUNNING;
        }
    }

    public NowNodeState NowNode()
    {
        return NowNodeState.Rotate;
    }
}
