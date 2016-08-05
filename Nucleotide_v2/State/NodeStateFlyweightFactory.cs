namespace Nucleotide_v2.State
{
    /// <summary>
    /// This class must implement the Flyweight design pattern.
    /// </summary>
    public abstract class NodeStateFlyweightFactory<T>
    {
        private static NodeStateFlyweightFactory<T> Factory = null;
        //public abstract INodeState<T> GetFlyweight(int positionId);
        public abstract INodeState<T> GetFlyweight(int positionId, NodeFlyweightFactory<T> factory);
        public INodeState<T> Contents(int positionId, NodeFlyweightFactory<T> factory)
        {
            return this.GetFlyweight(positionId, factory);
        }

        

    }
}