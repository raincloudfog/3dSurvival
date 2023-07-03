using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public interface IGetNowNodeState
{
    NowNodeState NowNode();
}

public interface IDgree
{
    void Dgree();
}

public class PigMoveTurn : SelectorNode
{
    //내가 움직일건지 회전중인지 뭔가 판별할...
    float timer; // 타이머         
    bool IsRotate = false;

    public PigMoveTurn(List<Node> children) : base(children) { }
    public override NodeState Evaluate()
    {

        foreach (Node node in childrenNode)
        {
                        
            if (node is IGetNowNodeState ) //필수
            {
                IGetNowNodeState Istate = node as IGetNowNodeState;
                
                if (IsRotate) //이미 회전중
                {
                    if (Istate.NowNode() == NowNodeState.Rotate)
                    {
                        state = node.Evaluate();
                        if (state != NodeState.RUNNING)
                        {
                            //그 evaluate에서 정해진 각도에 다다라서 false 를 반환하면 
                            IsRotate = false;
                            timer = 0;
                        }                                                                                                         
                        return state;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (timer < 5)
                    {
                        timer += Time.deltaTime;
                        if (Istate.NowNode() == NowNodeState.Move)
                        {
                            node.Evaluate(); //
                            return state = NodeState.RUNNING;
                        }                        
                    }
                    else
                    {
                        if (Istate.NowNode() == NowNodeState.Rotate)
                        {
                            IDgree dgree = node as IDgree;
                            //회전할 준비 세팅
                            //pigturn의 회전 처음 시작 세팅. 
                            //   evaluate에서 회전을 계속함. 
                            dgree.Dgree();
                            IsRotate = true;
                            return state = NodeState.RUNNING;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }


                return state = NodeState.SUCCESS;
            }
            else
                return state = NodeState.FAILURE;                            
        }






        //뭔가 움직일 조건이 아니면
        
        return state = NodeState.RUNNING;
    }
}
