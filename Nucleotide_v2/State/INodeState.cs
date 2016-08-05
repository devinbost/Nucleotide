using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    /// <summary>
    /// The key to successfully implementing INodeState is to ensure that its state is all extrinsic.
    /// </summary>
    public interface INodeState<T>
    {
        Node<T> Node { get; set; }
        bool IsChosen { get; }
        bool IsCut { get; }
        bool IsUnchosen { get; }
        void ChangeState(INodeState<T> edgeState);

        /// <summary>
        /// This method gets the next elements to process. 
        /// For a ChosenVertexState, it returns a list of UnchosenEdgeState objects.
        /// For an UnchosenEdgeState object, it returns a list (e.g. of size 1) of UnchosenVertexState objects.
        /// 
        /// To do that, we need to inject a container for the state objects. We also need to inject 
        /// 
        /// To make the state extrinsic to construct it from a flyweight factory, we would need to know the state
        /// of all of the EdgeNode and VertexNode objects. These states are required for the GetNext() method to 
        /// correctly get the elements with required state.
        /// Since the states can be pooled from our flyweight factory,
        /// 
        /// I would 
        /// </summary>
        /// <returns></returns>
        IEnumerable<INodeState<T>> GetNext();

        //void Cut();
        //void Choose();
        //IEdgeState Cut();
        //IEdgeState Choose();
    }
}