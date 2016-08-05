using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Exceptions
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
