using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Exceptions
{
    [Serializable]
    public class OrphanedVertexException : Exception
    {
        public OrphanedVertexException()
        : base() { }
    
    public OrphanedVertexException(string message)
        : base("Error: " + message) { }
    //public OrphanedVertexException(int vertexPosition1, int vertexPosition2, string message)
    //    : base("Error: Vertices " + vertexPosition1 + " and " + vertexPosition2 + " are not adjacent! " + message) { }
    }
}
