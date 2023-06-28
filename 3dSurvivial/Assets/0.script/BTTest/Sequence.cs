using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{

    /// <summary>
    /// 트리에서 and의 역할을 한다
    /// 하나라도 Failure라면 Failure반환하고
    /// 전부다 같다면 Running , Success중 하나를 반환한다. (Running이 우선순위가 높다.)
    /// </summary>
    public class SequenceNode : Node
    {
        public SequenceNode() : base() { } // 부모클래스의 생성자와 같다.
        public SequenceNode(List<Node> children) : base(children) { } //부모클래스의 생성자와 같고 매개변수도 같다..??


        public override NodeState Evaluate()
        {
            bool bNowRunning = false; // 지금 시작되고 있는지에 대해서 참 거짓 값

            foreach (Node node in childrenNode) // 자식노드를 확인한다.
            {
                switch (node.Evaluate()) // 자식노드들의 행동후 반환값 확인
                {
                    case NodeState.RUNNING: // 만약 진행된다하면
                        bNowRunning = true; // 트루
                        continue; // 계속하기
                    case NodeState.FAILURE: // 만약 아니라면
                        return state = NodeState.FAILURE; // false
                    case NodeState.SUCCESS: // 성공하면 계속옆에꺼 확인
                        continue;
                    case NodeState.END:
                    default:
                        continue;
                }
            }

            return state = bNowRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            // 시작되고있는지 확인하고 맞다면 러닝실행 아니라면 성공 실행
        }
    }
}