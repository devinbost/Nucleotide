namespace Nucleotide_v2.Factory
{
    /// <summary>
    /// We need to leverage the adjacency matrix to construct our vertices and their references to each other.
    /// The solution is like this:
    ///     We need to construct the NodeVertex objects. 
    ///     Possibly the best way to solve this problem is for each NodeVertex to retrieve its list of neighbors
    ///     by calling a method (on a property) that gets the list of neighbors from the parent UndirectedGraph.
    ///     That makes the parent UndirectedGraph a composite. So, each vertex must require a reference to the parent UndirectedGraph.
    ///     Then the vertex can execute a dynamic dispatch to a method on the UndirectedGraph to retrieve its neighbors.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AdjacencyMatrixFactory<T> : NodeFactory<T>
    {
        protected T[][] Nodes;
        private bool[][] References;
        // We must first update the references.
        public void Add()
        {
            
        }
    }
}