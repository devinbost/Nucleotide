using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    public class VertexNodeStateFlyweightFactory<T> : NodeStateFlyweightFactory<T>
    {
        private static VertexNodeStateFlyweightFactory<T> Factory = null;
        public IDictionary<int, VertexNodeState<T>> Nodes { get; set; }
        private VertexNodeStateFlyweightFactory() // defeats instantiation
        {
            
        }

        public override INodeState<T> GetFlyweight(int positionId, NodeFlyweightFactory<T> factory)
        {
            throw new System.NotImplementedException();
        }

        public new VertexNodeState<T> Contents(int positionId, NodeFlyweightFactory<T> factory)
        {
            return (VertexNodeState<T>)this.GetFlyweight(positionId, factory);
        }

        //public override INodeState<T> GetFlyweight(int positionId, NodeFlyweightFactory<T> factory )
        //{
        //    lock (Nodes)
        //    {
        //        if (!this.Nodes.ContainsKey(positionId))
        //        {
        //            // Then the item hasn't been constructed yet and needs to be constructed.
        //            var node = factory.GetFlyweight(positionId);
        //            var nodeState = new VertexNodeState<T>(node);
        //            Nodes.Add(positionId, nodeState);
        //            return nodeState;
        //        }
        //        return Nodes[positionId];
        //    }
        //}

        public static VertexNodeStateFlyweightFactory<T> GetFactory()
        {
            if (Factory == null)
            {
                Factory = new VertexNodeStateFlyweightFactory<T>();
            }
            return Factory;
        }
    }
}