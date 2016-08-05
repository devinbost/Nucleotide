using System;
using System.Collections.Generic;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2.Visit
{
    public interface IVertexNodeVisitor
    {
        void Visit(IAdjacencyDirectableVisitable visitable, int depth, Queue<int> positionQueue);

        //void AlternateProcessing(IAdjacencyDirectableVisitable firstVertex,
        //    IAdjacencyDirectableVisitable secondVertex,
        //    Dictionary<int, IAdjacencyDirectableVisitable> chosenVertices,
        //    int counter);
    }
}
