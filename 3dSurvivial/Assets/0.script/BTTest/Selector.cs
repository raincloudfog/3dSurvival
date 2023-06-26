using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }

        public override NodeState Evalaute()
        {
            

            foreach (Node node in children)
            {
                switch (node.Evalaute())
                {
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    case NodeState.SUCCES:
                        state = NodeState.SUCCES;
                        return state;
                    case NodeState.FAIL:
                        state = NodeState.FAIL;
                        continue;

                    default:
                        continue;
                }
            }

            state = NodeState.FAIL;
            return state;
        }
    }
}