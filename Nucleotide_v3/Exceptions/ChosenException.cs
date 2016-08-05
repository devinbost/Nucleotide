using System;

namespace Nucleotide_v3.Exceptions
{
    [Serializable]
    public class ChosenException : Exception
    {
        public ChosenException()
            : base() { }

        public ChosenException(string message)
            : base("Error:  " + message) { }
        
        public ChosenException(int vertexPosition1, int vertexPosition2)
            : base("Error: Vertices " + vertexPosition1 + " and " + vertexPosition2 + " were not chosen when they should be. ") { }
        public ChosenException(int vertexPosition1, int vertexPosition2, string message)
            : base("Error: Vertices " + vertexPosition1 + " and " + vertexPosition2 + " were not chosen when they should be. " +
            message) { }
    }
}
