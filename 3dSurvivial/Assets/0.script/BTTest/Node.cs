using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING, // ������

        FAILURE, // ����
        SUCCESS, // ����
        END
    }
    public abstract class Node // ��� �θ� Ŭ����
    {
        protected NodeState state; // ��� ������Ʈ ������ ���� // �̳���� ����
        public Node parentNode; // �θ� ��带 ������ ���� // ���� ���� ����(���� ����) // ���� �����ϸ� �ٽ� ���� �ö󰥼� �ְ�
        protected List<Node> childrenNode = new List<Node>(); // ������ �ִ� �ڽĳ��� // 

        public Node() // ������ �������ֱ� // �ʱ�ȭ
        {
            parentNode = null; // �������ָ鼭 �θ� ��尡 ����..??
        }

        public Node(List<Node> children) // �ʱ�ȭ
        {
            foreach (var child in children)
            {
                AttatchChild(child);
            }
        }

        public void AttatchChild(Node child) // �Ǻ��� �ڽĳ��� �߰�
        {
            childrenNode.Add(child); //�ڽ� ��帮��Ʈ�� �����ִ� �ڵ� // �ڽĵ��� ����
            child.parentNode = this; //�ڽ� ����� �θ���� �ٷ� �ڱ� �ڽ��̴�?? // �ڽĵ��� �������� �ڽĵ��� �θ�� ������ ��
        }

        /// <summary>
        /// ����� �ൿ�� �ϰ� ���¸� ��ȯ ���ִ� �� �ൿ�ϰ� �ൿ ���� �ϴ°� ����.
        /// </summary>
        /// <returns></returns>
        public abstract NodeState Evaluate(); // ���� �Ǻ�
    }


}