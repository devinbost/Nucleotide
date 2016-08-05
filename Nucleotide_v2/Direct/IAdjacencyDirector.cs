using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Provide;

namespace Nucleotide_v2.Direct
{
    public interface IAdjacencyDirector
    {
        IDictionary<int, IAdjacencyDirectableVisitable> DirectableList { get; }
        void Register(IAdjacencyDirectableVisitable directableVisitable);
        void Deregister(IAdjacencyDirectableVisitable directableVisitable);
        IVertexDataProvider VertexDataProvider { get; set; } 
        IAdjacencyProvider AdjacencyProvider { get; set; }
        IIncidenceProvider IncidenceProvider { get; set; }
        /// <summary>
        /// This method should utilize an IVertexDataProvider that is provided by constructor injection.
        /// Then we can have an overload that takes no parameters and/or call it from our Elements property getter.
        /// </summary>
        /// <param name="vertexDataProvider"></param>
        /// <returns></returns>
        IDictionary<int, IAdjacencyDirectableVisitable> RequestElements(IVertexDataProvider vertexDataProvider);
        IDictionary<int, IAdjacencyDirectableVisitable> Elements { get; }
        IDictionary<int, IAdjacencyDirectableVisitable> RequestAdjacentElements(int initialPosition);
        bool DoesCutOrphanVertex(int vertexPosition1, int vertexPosition2);
        void Cut(int vertexPosition1, int vertexPosition2);
        List<int> GetIncidentVertices(int edgePosition);
        List<int> GetIncidentEdges(int vertexPosition);
        List<EdgeNode> GetIncidentEdgeElements(int vertexPosition);
        IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2);
        EdgeNode GetEdgeIncidentToBothVertices(int vertexPosition1, int vertexPosition2);
    }
}
