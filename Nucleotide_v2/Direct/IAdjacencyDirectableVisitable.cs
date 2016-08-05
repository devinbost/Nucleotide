using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Visit;

namespace Nucleotide_v2.Direct
{
    public interface IAdjacencyDirectableVisitable : IPositionable, IWeighted
    {
        void Deregister();
        IDictionary<int, IAdjacencyDirectableVisitable> DirectableList { get; }
        IAdjacencyDirector AdjacencyDirector { get; set; }
        IDictionary<int, IAdjacencyDirectableVisitable> AdjacentDirectables { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> RequestAdjacentDirectables(int initialPosition);
        void Accept(IVertexNodeVisitor visitor, int depth, Queue<int> positionQueue);
        bool Chosen { get; set; }
        IDictionary<int, IAdjacencyDirectableVisitable> AdjacentChosenElements { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> AdjacentUnchosenElements { get; }
        void Cut(IAdjacencyDirectableVisitable adjacentVertexToCut);
        IDictionary<int, IAdjacencyDirectableVisitable> AdjacentUnchosenElementsThatOrphanTarget { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> AdjacentUnchosenElementsThatDoNotOrphanTarget { get; }
        void Choose();
        bool HasTwoAdjacentChosenElements { get; }
        void CutAllAdjacentUnchosenElementsThatDoNotOrphanTarget();
        IDictionary<int, IAdjacencyDirectableVisitable> DecideNext { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> IncidentChosenElements { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> UnchosenEdgesWithUnchosenVertices { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> ChosenEdges { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> UnchosenEdgesThatDontOrphanTargetVertex { get; }
    }
}
