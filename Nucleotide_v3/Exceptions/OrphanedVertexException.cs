using System;

namespace Nucleotide_v3.Exceptions
{
    [Serializable]
    public class OrphanedVertexException : IncidenceException
    {
        public OrphanedVertexException()
        : base() { }
    
    public OrphanedVertexException(string message)
        : base("Error: " + message) { }
    //public OrphanedVertexException(int vertexPosition1, int vertexPosition2, string message)
    //    : base("Error: Vertices " + vertexPosition1 + " and " + vertexPosition2 + " are not adjacent! " + message) { }
    }
}
