using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{


    /// <summary>
    /// Ʈ������ or������ �Ѵ�.
    /// �ϳ��� Running �̰ų� Success��� �ٷ� ��ȯ �����ش�.
    /// 
    /// </summary>
    public class SelectorNode : Node
    {
        public SelectorNode() : base() { } // �θ� Ŭ������ �Ȱ��� ������ 
        public SelectorNode(List<Node> children) : base(children) { } // �θ�Ŭ������ �Ȱ��� �����ڿ� �Ű�����

        public override NodeState Evaluate()
        {
            foreach (Node node in childrenNode)
            {
                switch (node.Evaluate())
                {
                    case NodeState.RUNNING:
                        return state = NodeState.RUNNING;
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        return NodeState.SUCCESS;
                    case NodeState.END:
                    default:
                        continue;
                }
            }

            return state = NodeState.FAILURE;
        }
    }
}