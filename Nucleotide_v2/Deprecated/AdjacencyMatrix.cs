namespace Nucleotide_v2.Deprecated
{
    public class AdjacencyMatrix<T> // Should this store indexes of position only?
    {
        private T[][] storage; // Should we offset access to the elements by 1? // Can I override the indexer?
        // private GraphType graphType;
        
        // for a given pair of positions, we can determine if an edge exists.
        // We can also get all of the positions where a given value is true (e.g. for a particular column).

        // We could construct the matrix from a list of edges.

        // We could also construct the matrix if we have each vertex and each vertex's list of neighbors.

        // Remember, lists must be thread safe.

        // I need a method to get the SynchronizedCollection<VertexNode<T>> of vertices adjacent to a given vertex.

        // The matrix can be either for a directed or an undirected UndirectedGraph.
    }
}