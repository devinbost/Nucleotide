using Nucleotide_v2.Provide;

namespace Nucleotide_v2.State
{
    /// <summary>
    /// This class is utilized by a walk for the purpose of holding references to all of the 
    /// constructed flyweight INodeState objects during a walk. We should be able to query this mediation
    /// for information about node states for the purpose of simplifying node state changes during a walk.
    /// For example, if we pass this mediation into the EdgeNodeState's GetNext(..) method, then the GetNext(..) method
    /// can use the mediation to get edge positions 
    /// </summary>
    public class NodeStateContextMediation<T>
    {
        EdgeNodeFlyweightFactory EdgeNodeFactory {get; set; }
        VertexNodeFlyweightFactory<T> VertexNodeFactory{get; set; }

        EdgeNodeStateFlyweightFactory<T> EdgeNodeStateFactory { get; set; }
        VertexNodeStateFlyweightFactory<T> VertexNodeStateFactory { get; set; }
        //private IDictionary<int, EdgeNodeState<T>> EdgeStates { get; set; }
        //private IDictionary<int, VertexNodeState<T>> VertexStates { get; set; }

        private IAdjacencyProvider AdjacencyProvider { get; set; }
        private IIncidenceProvider IncidenceProvider { get; set; }
    }
}