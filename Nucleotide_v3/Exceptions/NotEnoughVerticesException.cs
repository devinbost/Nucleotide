using System;

namespace Nucleotide_v3.Exceptions
{
    [Serializable]
    public class NotEnoughVerticesException : IncidenceException
    {

        public NotEnoughVerticesException()
            : base() { }

        public NotEnoughVerticesException(string message)
            : base("Error:  " + message) { }

        public NotEnoughVerticesException(int edgePosition)
            : base("Error: Not enough vertices are incident to an edge! (Edge is: " + edgePosition)
        {

        }

    }
}