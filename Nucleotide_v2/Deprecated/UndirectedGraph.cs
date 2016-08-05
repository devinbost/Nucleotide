using System;
using System.Collections.Generic;
using System.Linq;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2.Deprecated
{
    public class UndirectedGraph<T> where T : IAdjacencyDirectableVisitable
    {
        // The UndirectedGraph will act as a proxy to allow one vertex to retrieve its neighbors.
        // The UndirectedGraph is also a composite.
        public VertexNode<T>[][] Vertices { get; set; }
        public Dictionary<int, T> VerticesDictionary { get; set; }

        [Obsolete]
        public SynchronizedCollection<VertexNode<T>> GetAdjacentNodes(VertexNode<T> sourceNode)
        {
            // This method needs to get the adjacent nodes from an adjacency matrix.
            var matches = this.Vertices[sourceNode.Position]
                .Where(t => t != null)
                .Select(t => t.Position);
            var collection = new SynchronizedCollection<VertexNode<T>>();

            return collection;
        }

        public int NextPosition
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}