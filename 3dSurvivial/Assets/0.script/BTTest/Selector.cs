using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{


    /// <summary>
    /// 트리에서 or역할을 한다.
    /// 하나라도 Running 이거나 Success라면 바로 반환 시켜준다.
    /// 
    /// </summary>
    public class SelectorNode : Node
    {
        public SelectorNode() : base() { } // 부모 클래스와 똑같은 생성자 
        public SelectorNode(List<Node> children) : base(children) { } // 부모클래스와 똑같은 생성자와 매개변수

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