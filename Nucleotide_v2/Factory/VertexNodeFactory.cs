using System;
using System.Collections.Generic;
using Nucleotide_v2.Deprecated;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2.Factory
{
    /// <summary>
    /// Should the Id of an item be the same as its integer position?
    /// </summary>
    /// <typeparam name="T"></typeparam>
    //public class EdgeNodeFactory<T> : NodeFactory<T>
    //{
    //    //public T Source { get; set; }
    //    ////public T Target { get; set; } // Should these be of type T? Or are we purely representing the integer Id?
    //    ///// <summary>
    //    ///// We can leverage constructor injection to ensure that we can use the CreateNode() method on this object
    //    /////  and obtain the desired behavior.
    //    ///// </summary>
    //    ///// <param name="source"></param>
    //    ///// <param name="target"></param>
    //    //public EdgeNodeFactory(T source, T target)
    //    //{
    //    //    Source = source;
    //    //    Target = target;
    //    //}

    //    public Node<T> CreateNode(T source, T target)
    //        // If we're going to use constructor injection, then what's the point of using a factory?
    //    {
    //        var edgeNode = new EdgeNode<T>(source, target);
    //        return edgeNode;
    //    }

    //    public override Node<T> CreateNode(T source, T target, IEnumerable<T> list)
    //    {
    //        var edgeNode = this.CreateNode(source, target);
    //        return edgeNode;
    //    }
    //}

    // Construction of the adjacency matrix should require calling a NodeFactory<T> many times.
    // Perhaps I can use a builder to construct the adjacency matrix. Then perhaps I can do the same with the incidence matrix.

    public class VertexNodeFactory<T> : NodeFactory<T> where T : IAdjacencyDirectableVisitable
    {
        //public VertexNodeFactory(AdjacencyMatrixDictionaryDirector<VertexNode<string>> director)
        //{
        //    if (director == null)
        //    {
        //        throw new NullReferenceException("Director is null when constructing VertexNodeFactory!");
        //    }
        //    this.Director = director;
        //}
        
        public static VertexNode<T> CreateNode(T vertex, int position, IAdjacencyDirector director)
        {
            var edgeNode = new VertexNode<T>(vertex, position);
            edgeNode.Register(director);
            return edgeNode;
        }

        public static VertexNode<T> CreateNode(T vertex, int position, IAdjacencyDirector director, SynchronizedCollection<VertexNode<T>> adjacentVertices)
        // Ensures thread safety.
        {
            var vertexNode = CreateNode(vertex, position, director);
            // Convert to synchronizedCollection to make thread-safe.
            //vertexNode.AdjacentVertices = adjacentVertices;
            return vertexNode;
        }
        public static VertexNode<T> CreateNode(T vertex, int position, IAdjacencyDirector director, IEnumerable<T> adjacentVertices)
        // Ensures thread safety.
        {
            var vertexNode = CreateNode(vertex, position, director);
            // Convert to synchronizedCollection to make thread-safe.
            var collection = new SynchronizedCollection<VertexNode<T>>() { };

            foreach (var adjacentVertex in adjacentVertices)
            {
                var node = CreateNode(adjacentVertex, position, director);
                collection.Add(node);
            }
            //vertexNode.AdjacentVertices = collection;
            return vertexNode;
        }
    }
}