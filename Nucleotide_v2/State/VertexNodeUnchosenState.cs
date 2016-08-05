using System.Collections.Generic;
using Nucleotide_v2.Provide;

namespace Nucleotide_v2.State
{
    public class VertexNodeUnchosenState<T> : VertexNodeState<T>
    {
        private List<int> IncidentEdgePositions(IIncidenceProvider incidenceProvider)
        {
            return incidenceProvider.GetIncidentEdges(this.Node.Position);
        }
        // Need method that uses edgePosition to get edgeNodeState from container


    }
}