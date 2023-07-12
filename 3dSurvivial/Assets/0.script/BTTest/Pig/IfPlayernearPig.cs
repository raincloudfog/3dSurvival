using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class IfPlayernearPig : Node
{
    Transform _transform;
    //List<Collider> colliders = new List<Collider>();
    
    public IfPlayernearPig(Transform transform)
    {
        _transform = transform;
        
    }

    public override NodeState Evaluate()
    {
        

        //�ÿ��̾�� �Ÿ��� ������ �÷��̾����¼� �־����ϴ�.
        if (Vector3.Distance(GameManager.Instance.player.transform.position, _transform.position) < 20)
        {
            //Debug.Log("�÷��̾� ��ó��");
            return NodeState.SUCCESS;
        }
        else
        {
            //Debug.Log("�÷��̾� �ִ�");
            return NodeState.FAILURE;
        }                
    }
}
