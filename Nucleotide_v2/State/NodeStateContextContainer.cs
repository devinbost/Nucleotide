using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    public class NodeStateContextContainer<T>
    {
        private IDictionary<int, EdgeNodeState<T>> EdgeStates { get; set; }
        private IDictionary<int, VertexNodeState<T>> VertexStates { get; set; }
        NodeStateContextMediation<T> NodeStateContextMediation { get; set; }

        void ChangeEdgeState(EdgeNodeState<T> edgeNodeState)
        {
            // get the matching element from EdgeStates. Then swap it out with 
            // the correct, updated state for that node.
        }
        void ChangeVertexState(VertexNodeState<T> edgeNodeState)
        {

        }

        //NodeStateContextContainer<T> Clone()
        //{
            
        //}
    }

    public class NodeStateContext<T>
    {
        private INodeState<T> NodeState;

        void ChangeNodeState()
        {
            //NodeState.
        }
    }
    public class EdgeNodeStateContext<T> : NodeStateContext<T>
    {

    }
    public class VertexNodeStateContext<T> : NodeStateContext<T>
    {

    }
}