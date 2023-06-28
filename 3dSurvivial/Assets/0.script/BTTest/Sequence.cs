using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{

    /// <summary>
    /// Ʈ������ and�� ������ �Ѵ�
    /// �ϳ��� Failure��� Failure��ȯ�ϰ�
    /// ���δ� ���ٸ� Running , Success�� �ϳ��� ��ȯ�Ѵ�. (Running�� �켱������ ����.)
    /// </summary>
    public class SequenceNode : Node
    {
        public SequenceNode() : base() { } // �θ�Ŭ������ �����ڿ� ����.
        public SequenceNode(List<Node> children) : base(children) { } //�θ�Ŭ������ �����ڿ� ���� �Ű������� ����..??


        public override NodeState Evaluate()
        {
            bool bNowRunning = false; // ���� ���۵ǰ� �ִ����� ���ؼ� �� ���� ��

            foreach (Node node in childrenNode) // �ڽĳ�带 Ȯ���Ѵ�.
            {
                switch (node.Evaluate()) // �ڽĳ����� �ൿ�� ��ȯ�� Ȯ��
                {
                    case NodeState.RUNNING: // ���� ����ȴ��ϸ�
                        bNowRunning = true; // Ʈ��
                        continue; // ����ϱ�
                    case NodeState.FAILURE: // ���� �ƴ϶��
                        return state = NodeState.FAILURE; // false
                    case NodeState.SUCCESS: // �����ϸ� ��ӿ����� Ȯ��
                        continue;
                    case NodeState.END:
                    default:
                        continue;
                }
            }

            return state = bNowRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            // ���۵ǰ��ִ��� Ȯ���ϰ� �´ٸ� ���׽��� �ƴ϶�� ���� ����
        }
    }
}