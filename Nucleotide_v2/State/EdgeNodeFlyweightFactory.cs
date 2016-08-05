using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    /// <summary>
    /// Note: This factory does not distinguish between edge nodes that have identical positionId values!
    /// This factory also does not add the elements to their corresponding matrices.
    /// </summary>
    public class EdgeNodeFlyweightFactory : NodeFlyweightFactory<string>
    {
        private static EdgeNodeFlyweightFactory Factory = null;
        public new IDictionary<int, UndirectedEdgeNode> Nodes { get; set; }

        public override Node<string> GetFlyweight(int positionId)
        {
            return Construct(positionId);
        }

        public EdgeNodeFlyweightFactory()
        {
            this.Nodes = new Dictionary<int, UndirectedEdgeNode>();
        }

        public new UndirectedEdgeNode Construct(int position)
        {
            lock (Nodes)
            {
                if (!this.Nodes.ContainsKey(position))
                {
                    // Then the item hasn't been constructed yet and needs to be constructed.
                    var node = new UndirectedEdgeNode(position);
                    Nodes.Add(position, node);
                    return node;
                }
                else
                {
                    return Nodes[position];
                }
            }

        }

        public static NodeFlyweightFactory<string> GetFactory()
        {
            if (Factory == null)
            {
                Factory = new EdgeNodeFlyweightFactory();
            }
            return Factory;
        }

        public UndirectedEdgeNode Construct(int position, string value)
        {
            lock (Nodes)
            {
                if (!this.Nodes.ContainsKey(position))
                {
                    // Then the item hasn't been constructed yet and needs to be constructed.
                    var node = new UndirectedEdgeNode(position: position, value:value);
                    Nodes.Add(position, node);
                    return node;
                }
                else
                {
                    return Nodes[position];
                }
            }
        }
        public UndirectedEdgeNode Construct(int id, string value, int position)
        {
            lock (Nodes)
            {
                if (!this.Nodes.ContainsKey(position))
                {
                    // Then the item hasn't been constructed yet and needs to be constructed.
                    var node = new UndirectedEdgeNode(id, value, position);
                    Nodes.Add(position, node);
                    return node;
                }
                else
                {
                    return Nodes[position];
                }
            }
        }



        //public class VertexNodeStateFlyweightFactory<T> : NodeStateFlyweightFactory<T>
        //{

        //}
    }
}