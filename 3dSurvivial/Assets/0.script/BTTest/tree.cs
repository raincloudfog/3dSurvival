using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{

    public abstract class Tree : MonoBehaviour
    {
        private Node rootNode = null; // Ʈ���� ��带 ������ �ִ� �ϳ��� ���� �����ΰŰ���.

        protected virtual void Start()
        {
            rootNode = SetupBehaviorTree();
        }

        protected virtual void Update()
        {
            //���� ��Ʈ��尡 �ִٸ�
            //��Ʈ ����� �ڽ��� Ȯ��
            if (rootNode != null)
            {
                //Debug.Log("�ϴ� null�� �ƴ�");
                rootNode.Evaluate();
                //Debug.Log(rootNode);
            }
            else
            {
               // Debug.Log("null��");
                return;
            }
        }
        protected abstract Node SetupBehaviorTree();
        
    }
}