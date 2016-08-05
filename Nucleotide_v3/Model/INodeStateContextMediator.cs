using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v3.Model
{
    public interface INodeStateContextMediator<E>
    {
        void DeleteEdge(int vertexPosition1, int vertexPosition2);
        List<int> GetIncidentVertices(int edgePosition);
        List<int> GetIncidentEdges(int vertexPosition);
        List<E> GetIncidentEdgeElements(int vertexPosition);
        IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2);
        E GetEdgeIncidentToBothVertices(int vertexPosition1, int vertexPosition2);
    }
}
