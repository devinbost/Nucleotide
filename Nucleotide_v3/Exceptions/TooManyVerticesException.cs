using System;

namespace Nucleotide_v3.Exceptions
{
    [Serializable]
    public class TooManyVerticesException : IncidenceException
    {

        public TooManyVerticesException()
            : base() { }

        public TooManyVerticesException(string message)
            : base("Error:  " + message) { }

        public TooManyVerticesException(int edgePosition)
            : base("Error: Too many vertices are incident to an edge! (Edge is: " + edgePosition)
        {

        }

    }
}