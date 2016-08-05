using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2.Provide
{
    public interface IIncidenceProvider
    {
        bool IsVertexInMatrix(int vertexPosition);
        bool IsEdgeInMatrix(int edgePosition);
        Dictionary<int, Dictionary<int, bool>> Values { get; set; }
        void AddEdge(int edgePosition);
        void AddVertex(int vertexPosition);
        void DeleteVertex(int vertexPosition);
        void Add(int vertexPosition, int edgePosition);
        List<int> GetIncidentVertices(int edgePosition);
        List<int> GetIncidentEdges(int vertexePosition);
        bool AreVerticesBothIncident(int vertexPosition1, int vertexPosition2);
        IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2);
        int NextAvailableVertex { get; }
        int NextAvailableEdge { get; }
        //void SetIncidentVertex(int vertexPosition, int edgePosition);
        /// <summary>
        /// This method should return the edge position. If the vertices exist, it should set them.
        /// If the vertices don't exist, they must be added.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPosition2"></param>
        /// <returns></returns>
        int SetIncidentVertices(int vertexPosition1, int vertexPosition2);
        /// <summary>
        /// This must return a list of edge positions.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPositions"></param>
        /// <returns></returns>
        List<int> SetIncidentVertices(int vertexPosition1, IEnumerable<int> vertexPositions);
        void UnsetIncidentVertices(int vertexPosition1, int vertexPosition2);
    }
    /// <summary>
    /// This Provider is responsible for providing data on the relationships between objects according to their positions.
    /// It tracks adjacency between elements. The actual elements should be tracked by an IVertexDataProvider.
    /// </summary>
   
       
    
}
