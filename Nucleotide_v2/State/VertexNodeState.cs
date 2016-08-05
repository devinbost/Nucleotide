using System;
using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    public class VertexNodeState<T> : INodeState<T>
    {
        public Node<T> Node { get; set; }
        public bool IsChosen { get; private set; }
        public bool IsCut { get; private set; }
        public bool IsUnchosen { get; private set; }

        public void ChangeState(INodeState<T> edgeState)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INodeState<T>> GetNext()
        {
            throw new NotImplementedException();
        }
        // public VertexNodeState(Node<T> node)
        //{
        //    Node = node;
        //}
    }
}