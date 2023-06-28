using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BehaviorTree
{
    public enum NodeState
    {
        RUNNING, // 실행중

        FAILURE, // 실패
        SUCCESS, // 성공
        END
    }
    public abstract class Node // 노드 부모 클래스
    {
        protected NodeState state; // 노드 스테이트 가지고 있음 // 이노드의 상태
        public Node parentNode; // 부모 노드를 가지고 있음 // 나의 이전 상태(위의 상태) // 만약 실패하면 다시 위로 올라갈수 있게
        protected List<Node> childrenNode = new List<Node>(); // 가지고 있는 자식노드들 // 

        public Node() // 생성자 생성해주기 // 초기화
        {
            parentNode = null; // 생성해주면서 부모 노드가 없다..??
        }

        public Node(List<Node> children) // 초기화
        {
            foreach (var child in children)
            {
                AttatchChild(child);
            }
        }

        public void AttatchChild(Node child) // 판별할 자식노드들 추가
        {
            childrenNode.Add(child); //자식 노드리스트에 더해주는 코드 // 자식들을 세팅
            child.parentNode = this; //자식 노드의 부모노드는 바로 자기 자신이다?? // 자식들이 생겼으니 자식들의 부모는 본인이 됨
        }

        /// <summary>
        /// 노드의 행동을 하고 상태를 반환 해주는 즉 행동하고 행동 변경 하는거 같다.
        /// </summary>
        /// <returns></returns>
        public abstract NodeState Evaluate(); // 상태 판별
    }


}