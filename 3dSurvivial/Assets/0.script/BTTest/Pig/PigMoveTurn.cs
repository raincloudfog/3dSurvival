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
    //���� �����ϰ��� ȸ�������� ���� �Ǻ���...
    float timer; // Ÿ�̸�         
    bool IsRotate = false;

    public PigMoveTurn(List<Node> children) : base(children) { }
    public override NodeState Evaluate()
    {

        foreach (Node node in childrenNode)
        {
                        
            if (node is IGetNowNodeState ) //�ʼ�
            {
                IGetNowNodeState Istate = node as IGetNowNodeState;
                
                if (IsRotate) //�̹� ȸ����
                {
                    if (Istate.NowNode() == NowNodeState.Rotate)
                    {
                        state = node.Evaluate();
                        if (state != NodeState.RUNNING)
                        {
                            //�� evaluate���� ������ ������ �ٴٶ� false �� ��ȯ�ϸ� 
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
                            //ȸ���� �غ� ����
                            //pigturn�� ȸ�� ó�� ���� ����. 
                            //   evaluate���� ȸ���� �����. 
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






        //���� ������ ������ �ƴϸ�
        
        return state = NodeState.RUNNING;
    }
}
