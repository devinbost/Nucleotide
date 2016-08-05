using System;

namespace Nucleotide_v3.Exceptions
{
    [Serializable]
    public class IncidenceException : Exception
    {
        public IncidenceException()
            : base() { }

        public IncidenceException(string message)
            : base("Error:  " + message) { }
        public IncidenceException(int vertexPosition1, int vertexPosition2, string message)
            : base("Error: Problem with " + vertexPosition1 + " and " + vertexPosition2 + " ! " + message) { }
    }
}
