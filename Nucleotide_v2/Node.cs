using System;
using System.CodeDom;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Deprecated;

namespace Nucleotide_v2
{
    [Serializable]
    public  class Node<T> : IPositionable, IWeighted
    { // The node's neighbors are a fascade to dynamically dispatched lookup via UndirectedGraph proxy.
        public int Id { get; set; }
        public int Weight { get; set; }
        // We need to be able to add a Weight to any node, regardless of whether it is an edge or a vertex.
        // We need some type of collection that allows us to 
        public T Value { get; set; } // If value can be any type, but position can only be a type involving one or more integers, 
            // then we need some way to distinguish the value the node is containing and the position of the node itself.
        public int Position { get; set; }


        public Node()
        {
            
        }
        
        public Node(int id, int weight, T value, int position)
        {
            Id = id;
            Weight = weight;
            Value = value;
            Position = position;
        }

        public Node(int id, T value, int position)
            : this(id: id, weight: 0, value: value, position: position)
        {
            
        }
        public Node(int position, T value)
            : this(id: 0, weight: 0, value: value, position: position)
        {

        }
        public Node(int position)
        {
            Position = position;
            Weight = 0;
        }
    }

    // We need a factory method that constructs a collection of nodes from a list or array of integers.
    /* What do the visitors need to produce?
     * Total of weights.
     * 
     * 
     * 
     * */

    // If I have an adjacency matrix, then my VertexNode<T> objects can be retrieved from the adjacency matrix?
    // I need a factory method for constructing VertexNode<T> objects.

    //public class VertexNodeVisitor<T> : VertexNodeVisitor<T>
    //{
    //    public override void Visit(Node<T> node, Action<T> action)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

// We could create a factory for constructing the visit actions/operations from strings at runtime.
    // I need a vertex to be able to utilize perhaps a builder that uses a visitor?
}

/* Requirements:
 * 
 * I need an adjacency matrix as a backend data storage? This should allow me to quickly lookup which vertices are adjacent to a given vertex.
 * It also allows constant time checks (to determine if two vertices are adjacent.)
 * 
 * I need a node to have a property with its edges. These must somehow connect the nodes, such that I should be able to get the 
 * vertices that are adjacent to a given vertex (from that given vertex).
 * 
 * 
 */
