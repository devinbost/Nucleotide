namespace Nucleotide_v2.State
{
    /// <summary>
    /// This singleton (data provider?) is responsible for keeping track of Flyweight construction of Edge objects and Edge
    /// state. We should only need to clone Edge State data once we have already saved a given Edge, its Vertexes, Mediator, 
    /// and the Adjacency/Incidence matrix providers. 
    /// 
    /// DeepClone() is expensive and wasteful. If changes to an Edge state never are actually saved on the Edge object itself,
    /// then we will never need to clone the Edge objects: Instead, we can save the EdgeNodeState-Edge data for a given 
    /// Walk position. (e.g. a table keyed by EdgeStateID-EdgeID-WalkPathID ). In this way, we are removing EdgeNodeState from
    /// both the Incidence matrix and the Edge itself.
    /// 
    /// When given a Path, (note that paths can be partial and/or incomplete and/or cycles,) it must 
    ///     construct the PathID and check its data storage. It should either:
    ///     1. Return the associated Edge object data.
    ///     2. Construct 
    /// 
    /// 
    /// When given an EdgeID and a State, it should be able to provide the list of paths where that Edge has the specified State.
    /// </summary>
    public class EdgeStateContext
    {
        private EdgeStateContext _thisEdgeStateContext = null;
        private EdgeStateContext() // private constructor defeats external instantiation.
        {
        }

        public EdgeStateContext GetEdgeStateTracker()
        {
            if (_thisEdgeStateContext == null)
            {
                _thisEdgeStateContext = new EdgeStateContext();
            }
            return _thisEdgeStateContext;
        }

        
        //public EdgeNodeState GetEdgeState(WalkPath walkPath, int edgeNodePosition)
        //{
            
        //}
    }
}
