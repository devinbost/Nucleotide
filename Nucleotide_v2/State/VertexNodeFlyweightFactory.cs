using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    public class VertexNodeFlyweightFactory<T> : NodeFlyweightFactory<T>
    {
        private static VertexNodeFlyweightFactory<T> Factory = null;
        public new IDictionary<int, VertexNode<T>> Nodes { get; set; }

        public override Node<T> GetFlyweight(int positionId)
        {
            return Construct(positionId);
        }

        public VertexNodeFlyweightFactory()
        {
            this.Nodes = new Dictionary<int, VertexNode<T>>();
        }

        public new VertexNode<T> Construct(int position)
        {
            lock (Nodes)
            {
                if (!this.Nodes.ContainsKey(position))
                {
                    // Then the item hasn't been constructed yet and needs to be constructed.
                    var node = new VertexNode<T>(position);
                    Nodes.Add(position, node);
                    return node;
                }
                else
                {
                    return Nodes[position];
                }
            }

        }

        public static NodeFlyweightFactory<T> GetFactory()
        {

            if (Factory == null)
            {
                Factory = new VertexNodeFlyweightFactory<T>();
            }
            return Factory;

        }

        public VertexNode<T> Construct(int position, T value)
        {
            lock (Nodes)
            {
                if (!this.Nodes.ContainsKey(position))
                {
                    // Then the item hasn't been constructed yet and needs to be constructed.
                    var node = new VertexNode<T>(position: position, value: value);
                    Nodes.Add(position, node);
                    return node;
                }
                else
                {
                    return Nodes[position];
                }
            }
        }

    }
}