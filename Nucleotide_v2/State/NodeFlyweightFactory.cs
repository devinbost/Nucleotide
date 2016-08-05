using System.Collections.Generic;

namespace Nucleotide_v2.State
{
    public abstract class NodeFlyweightFactory<T>
    {
        public IDictionary<int, Node<T>> Nodes { get; set; }
        public abstract Node<T> GetFlyweight(int positionId);
        private static NodeFlyweightFactory<T> Factory = null;
        public Node<T> Contents(int positionId)
        {
            return this.GetFlyweight(positionId);
        }

        public virtual Node<T> Construct(int position)
        {
            lock (Nodes)
            {
                if (!this.Nodes.ContainsKey(position))
                {
                    // Then the item hasn't been constructed yet and needs to be constructed.
                    var node = new Node<T>(position);
                    Nodes.Add(position, node);
                    return node;
                }
                else
                {
                    return Nodes[position];
                }
            }
        }
        //public NodeFlyweightFactory<T> GetFactory();
    }
}