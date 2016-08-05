using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Exceptions
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
