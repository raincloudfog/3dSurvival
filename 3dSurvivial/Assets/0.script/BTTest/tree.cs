using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{

    public abstract class Tree : MonoBehaviour
    {
        private Node rootNode = null; // 트리는 노드를 가지고 있는 하나의 나무 가지인거같다.

        protected virtual void Start()
        {
            rootNode = SetupBehaviorTree();
        }

        protected virtual void Update()
        {
            //만약 루트노드가 있다면
            //루트 노드의 자식을 확인
            if (rootNode != null)
            {
                //Debug.Log("일단 null은 아님");
                rootNode.Evaluate();
                //Debug.Log(rootNode);
            }
            else
            {
               // Debug.Log("null임");
                return;
            }
        }
        protected abstract Node SetupBehaviorTree();
        
    }
}