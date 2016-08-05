using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Exceptions
{
    [Serializable]
    public class NotEnoughEdgesException : IncidenceException
    {

        public NotEnoughEdgesException()
            : base() { }

        public NotEnoughEdgesException(string message)
            : base("Error:  " + message) { }
        public NotEnoughEdgesException(int vertexPosition1, int vertexPosition2)
            : base("Error: Not enough edges are incident to a pair of vertices! (Vertices " +
                                                     "are :" + vertexPosition1 + " and " + vertexPosition2 + " )")
        {

        }

        public NotEnoughEdgesException(string message, int vertexPosition1, int vertexPosition2)
            : base("Error:" + message + " Not enough edges are incident to a pair of vertices! (Vertices " +
                                                     "are :" + vertexPosition1 + " and " + vertexPosition2 + " )")
        {

        }
    }
}
