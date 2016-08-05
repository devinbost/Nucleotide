namespace Nucleotide_v2.State
{
    /// <summary>
    /// This class should be responsible for using the existing factories to construct a NodeState and a Node and
    /// combining them to create a NodeStateMediation object unless one has already been created.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NodeStateMediationFlyweightFactory<T>
    {
        private EdgeNodeStateFlyweightFactory<T> NodeStateFlyweightFactory = EdgeNodeStateFlyweightFactory<T>.GetFactory();
        private NodeFlyweightFactory<T> VertexNodeFlyweightFactory = VertexNodeFlyweightFactory<T>.GetFactory();
    }
}