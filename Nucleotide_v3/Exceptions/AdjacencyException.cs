using System;

namespace Nucleotide_v3.Exceptions
{
    [Serializable]
    public class AdjacencyException : Exception
    {
        public AdjacencyException()
        : base() { }
    
    public AdjacencyException(string message)
        : base("Error: Vertices are not adjacent! " + message) { }
    public AdjacencyException(int vertexPosition1, int vertexPosition2, string message)
        : base("Error: Vertices " + vertexPosition1 + " and " + vertexPosition2 + " are not adjacent! " + message) { }
    }
    
}
