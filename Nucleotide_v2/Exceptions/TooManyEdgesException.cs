﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Exceptions
{
    [Serializable]
    public class TooManyEdgesException : IncidenceException
    {

        public TooManyEdgesException()
            : base() { }

        public TooManyEdgesException(string message)
            : base("Error:  " + message) { }
        public TooManyEdgesException(int vertexPosition1, int vertexPosition2)
            : base("Error: Too many edges are incident to a pair of vertices! (Vertices " +
                                                     "are :" + vertexPosition1 + " and " + vertexPosition2 + " )")
        {

        }

        public TooManyEdgesException(string message, int vertexPosition1, int vertexPosition2)
            : base("Error:" + message + " Too many edges are incident to a pair of vertices! (Vertices " +
                                                     "are :" + vertexPosition1 + " and " + vertexPosition2 + " )")
        {
            
        }
    }
}
