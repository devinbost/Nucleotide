using System.Collections.Generic;

namespace Nucleotide_v2.Provide
{
    /// <summary>
    /// This Provider is responsible for providing data on the relationships between objects according to their positions.
    /// It tracks adjacency between elements. The actual elements should be tracked by an IVertexDataProvider.
    /// </summary>
    public interface IAdjacencyProvider
    {
        bool IsVertexInMatrix(int vertexPosition);
        Dictionary<int, Dictionary<int, bool>> Values { get;set; }
        void Add(int vertexPosition);
        void Delete(int vertexPosition);
        List<int> GetAdjacentVertices(int vertexPosition);
        bool AreVerticesBothAdjacent(int vertexPosition1, int vertexPosition2);
        void SetAdjacentVertices(int vertexPosition1, int vertexPosition2);
        void SetAdjacentVertices(int vertexPosition1, IEnumerable<int> vertexPositions);
        void UnsetAdjacencyVertices(int vertexPosition1, int vertexPosition2);
    }
}
