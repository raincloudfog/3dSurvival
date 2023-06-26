using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree
{

    public enum NodeState
    {
        RUNNING,
        SUCCES,
        FAIL,
        END
    }
    public class Node : MonoBehaviour
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children)
        {
            foreach (Node Child in children)
            {
                _Attach(Child);
            }
        }
        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evalaute()
        {
            return NodeState.FAIL;
        }

        public void SetData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object value = null;
            if (_dataContext.TryGetValue(key, out value))
            {
                _dataContext.Remove(key);
                return value;
            }
                

            Node node = parent;
            while(node != null)
            {
                value = node.GetData(key);
                if(value != null)
                {
                    value = node.GetData(key);
                    if (value != null)
                        return value;
                    node = node.parent;
                }                
            }
            return null;
        }

        public bool clearData(string key)
        {
            if(_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;
            while(node != null)
            {
                bool cleared = node.clearData(key);
                if(cleared == true)
                {
                    return true;
                }
                node = node.parent;
            }
            return false;
        }
    }
}

