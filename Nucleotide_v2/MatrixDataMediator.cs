using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Direct;
using Nucleotide_v2.Provide;

namespace Nucleotide_v2
{
    /// <summary>
    /// This class should act as a mediator between the UndirectedDictionaryMatrixAdjacencyProvider and our internal storage.
    /// The storage should be a dictionary where the diagonal values of the matrix correspond to the keys of the 
    /// items in the dictionary.
    /// </summary>
    //public class MatrixDataMediator<T> : IAdjacencyDirector<T>
    //{
    //    public UndirectedDictionaryMatrixAdjacencyProvider Matrix { get; set; }
    //    public IDictionary<int, IAdjacencyDirectableVisitable<T>> RequestElements(IVertexDataProvider<T> VertexDataProvider)
    //    {
    //        return VertexDataProvider.Elements;
    //    }

    //    public IDictionary<int, IAdjacencyDirectableVisitable<T>> RequestAdjacentElements(int initialPosition)
    //    {
    //        return this.AdjacencyProvider.GetAdjacentVertices(initialPosition);
    //    }

    //    public IDictionary<int, T> Elements { get; set; }

    //    // Node objects can request their adjacent Node objects from the Mediator.
    //        // The mediator takes the position int of the Node and gets the adjacent positions from the adjacency
    //        // matrix. This will always be a class with an adjacency matrix.
    //        // The position values are then returned to the mediator. The mediator then uses those position values
    //        // to query a data storage provider for the associated objects. (We are requesting the set of objects
    //        // with the specified position ID values.) 
    //        // If the requesting client is asking the mediator for resolved objects, then the mediator 
    //        // returns the resulting objects to the caller.
    //        // That data provider then returns the requested positions to the Mediator.
    //        // The mediator then arranges 
    //    // The UndirectedDictionaryMatrixAdjacencyProvider can  

    //    // The mediator needs to know that it can perform these tasks:
    //        // 1. Resolve the adjacent positions (from a given position) by asking an AdjacencyMatrix.
    //        // 2. Resolve a position ID value into an object by asking a VertexDataProvider.
    //        // 3. Return a list of resolved objects to the calling Node.
    //        // 4. Update the VertexDataProvider when the Node changes. (The mediator can be an Observer of the Nodes.)
    //        // 5. Allow a Visitor to visit a node with a particular position and perform an activity (to update the node)
    //        //     (where the update gets pushed to the VertexDataProvider).
    //    public void Add(int vertexPosition, T element) // This is if we are adding an element that contains data.
    //    {
    //        this.Elements.Add(vertexPosition, element);
    //        this.Matrix.Add(vertexPosition);
    //    }
    //    public void Add(int vertexPosition)
    //    {
    //        //var vertexNode = new VertexNode<int>()
    //        //this.Elements.Add(vertexPosition, element);
    //        //this.Matrix.Add(vertexPosition);
    //    }

    //    public List<int> GetAdjacent(int vertexPosition)
    //    {
    //        return this.Matrix.GetAdjacentVertices(vertexPosition);
    //    }

    //    //public List<IDirectable> GetAdjacentElements(IDirectable directable)
    //    //{
    //    //    throw new NotImplementedException();
    //    //}

    //    public IVertexDataProvider<T> VertexDataProvider { get; set; }

    //    public IAdjacencyProvider AdjacencyProvider
    //    {
    //        get { throw new NotImplementedException(); }
    //        set { throw new NotImplementedException(); }
    //    }

    //    public List<IVertexDataProvider<T>> DirectableList { get; set; }
    //    public void Register(IDirectable<T> directable)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    Dictionary<int, IDirectable<T>> IDirector<T>.DirectableList
    //    {
    //        get { throw new NotImplementedException(); }
    //    }
    //}
}
