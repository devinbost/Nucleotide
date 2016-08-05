using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    public class EdgeNodeStateFlyweightFactory<T> : NodeStateFlyweightFactory<T>
    {
        private static EdgeNodeStateFlyweightFactory<T> Factory = null;
        public IDictionary<int, EdgeNodeState<T>> Nodes { get; set; }
        private EdgeNodeStateFlyweightFactory() // defeats instantiation
        {
            
        }

        public override INodeState<T> GetFlyweight(int positionId, NodeFlyweightFactory<T> factory)
        {
            throw new System.NotImplementedException();
        }

        //public new EdgeNodeState<T> Contents(int positionId, NodeFlyweightFactory<T> factory)
        //{
        //    return (EdgeNodeChosenState<T>)this.GetFlyweight(positionId, factory);
        //}

        //public override INodeState<T> GetFlyweight(int positionId, NodeFlyweightFactory<T> factory )
        //{
        //    lock (Nodes)
        //    {
        //        if (!this.Nodes.ContainsKey(positionId))
        //        {
        //            // Then the item hasn't been constructed yet and needs to be constructed.
        //            var node = factory.GetFlyweight(positionId);
        //            var nodeState = new EdgeNodeState<T>(node); // Needs to use factory.
        //            Nodes.Add(positionId, nodeState);
        //            return nodeState;
        //        }
        //        return Nodes[positionId];
        //    }
        //}

        public static EdgeNodeStateFlyweightFactory<T> GetFactory()
        {
            if (Factory == null)
            {
                Factory = new EdgeNodeStateFlyweightFactory<T>();
            }
            return Factory;
        }
    }
}