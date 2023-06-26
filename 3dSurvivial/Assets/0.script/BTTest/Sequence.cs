using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{
    public class Sequence : Node
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evalaute()
        {
            bool anyChildIsRunning = false;

            foreach (Node node in children)
            {
                switch (node.Evalaute())
                {
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    case NodeState.SUCCES:
                        continue;
                    case NodeState.FAIL:
                        state = NodeState.FAIL;
                        return state;
                    
                    default:
                        state = NodeState.SUCCES;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCES;
            return state;
        }
    }
}