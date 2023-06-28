using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
/// <summary>
/// �÷��̾ ��ó�ΰ��� Ȯ���ϴ� �ڵ�
/// </summary>
public class CheckPlayerIsNearNode : BehaviorTree.Node
{
    private static int playerLayerMask = 1<< LayerMask.NameToLayer("Player");
    private Transform transform; // ���� ��ġ�� ������.
    //private Animator anim;

    //�����ɶ� Ʈ������ �Ƹ��� ����? Ȥ�� ����ٴ� ��ü �� Ʈ�������� ��´� �Ƹ��� �ڽŰ���.
    public CheckPlayerIsNearNode(Transform transform) 
    {
        this.transform = transform;
        //anim = transform.GetComponent<Animator>();
    }

    
    public override NodeState Evaluate()
    {
        
        var collider = Physics.OverlapSphere(transform.position, 5.0f, playerLayerMask);

        //���� �÷��̾���� �Ÿ��� 0�̶�� ���� ���������ٴ°ǰ� �����ϱ� �ָ��ϳ� 0 �����ϴ�
        if(collider.Length <= 0)
        {
            //Debug.Log("�Ÿ��� �����");
            return state = NodeState.FAILURE; // ��ó�� �ƴϹǷ� Ȥ�� ���� ������ �����Ƿ� Fail
        }
        else
        {
            //Debug.Log("�Ÿ��� �־���");

        }

        //throw new System.NotImplementedException();
        return state = NodeState.SUCCESS; //�Ÿ��� �ִٸ�Success
    }

    
}
