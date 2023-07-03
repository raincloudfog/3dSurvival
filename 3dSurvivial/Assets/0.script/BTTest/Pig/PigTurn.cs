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
    //bool isturn;
    //float a; // 움직일 방향
    //float timer = 0;
    //float turntimer = 0;
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
        //timer += Time.deltaTime;
        //turntimer += Time.deltaTime;

        //if(turntimer > 2)
        //{
        //    turntimer = 0;
        //    Debug.Log("방향 전환 실시!!");
        //    isturn = !isturn;
        //}
        //if(timer> 5)
        //{
        //    Debug.Log("이제 도는것도 끝");
        //    timer = 0;
        //    return NodeState.FAILURE;
        //}

        //if (isturn)
        //{
        //    a -= 1;
        //}
        //else if(!isturn)
        //{
        //    a += 1;
        //}
        
        if (_transform.rotation == Vecdgree) 
        {
            Debug.Log("회전 끝" + _transform.rotation + "/" + Vecdgree);
            return NodeState.SUCCESS;
        }
        else
        { 
            _transform.rotation = Quaternion.Lerp(_transform.rotation, Vecdgree, Time.deltaTime * 5f);
            //Debug.Log("PigTurn" + _transform.rotation);
            Debug.Log("회전비교" + _transform.rotation + "/" + Vecdgree);

            return NodeState.RUNNING;
        }
    }

    public NowNodeState NowNode()
    {
        return NowNodeState.Rotate;
    }
}
