using System;
using System.Collections.Generic;
using System.Linq;
using Nucleotide_v2.Exceptions;
using Nucleotide_v2.Provide;

namespace Nucleotide_v2.Direct
{
    namespace Nucleotide_v2.Direct
    {
        [Serializable]
        public class AdjacencyMatrixDictionaryDirector1 : IAdjacencyDirector
        {

            public AdjacencyMatrixDictionaryDirector1(IVertexDataProvider vertexDataProvider, IAdjacencyProvider adjacencyProvider)
            {
                if (vertexDataProvider == null)
                {
                    throw new NullReferenceException("Data provider cannot be null when constructing AdjacencyMatrixDictionaryDirector!");
                }
                this.VertexDataProvider = vertexDataProvider;
                if (adjacencyProvider == null)
                {
                    throw new NullReferenceException("adjacencyProvider cannot be null when constructing AdjacencyMatrixDictionaryDirector!");
                }
                this.AdjacencyProvider = adjacencyProvider;
                

            }

            public IDictionary<int, IAdjacencyDirectableVisitable> DirectableList
            {
                get
                {
                    return this.VertexDataProvider.Elements;
                }
            }

            public void Register(IAdjacencyDirectableVisitable directableVisitable)
            {
                if (directableVisitable == null)
                {
                    throw new NullReferenceException("Directable cannot be null when registering it with the AdjacencyMatrixDictionaryDirector!");
                }
                this.VertexDataProvider.Add(directableVisitable.Position, directableVisitable);
                this.AdjacencyProvider.Add(directableVisitable.Position);
                this.IncidenceProvider.AddVertex(directableVisitable.Position);
            }

            public void Deregister(IAdjacencyDirectableVisitable directableVisitable)
            {
                throw new NotImplementedException();
            }

            public IVertexDataProvider VertexDataProvider { get; set; }
            public IIncidenceProvider IncidenceProvider { get; set; }
            public IAdjacencyProvider AdjacencyProvider { get; set; }

            public IDictionary<int, IAdjacencyDirectableVisitable> RequestElements(IVertexDataProvider vertexDataProvider)
            {
                return vertexDataProvider.Elements;
            }

            public void SetAdjacentVertices(int vertexPosition1, IEnumerable<int> vertexPositions)
            {
                var vertexPositionsList = vertexPositions.ToList();
                lock (vertexPositionsList)
                {
                    var edges = this.IncidenceProvider.SetIncidentVertices(vertexPosition1, vertexPositionsList);

                    this.AdjacencyProvider.SetAdjacentVertices(vertexPosition1, vertexPositionsList);
                }
            }
            public IDictionary<int, IAdjacencyDirectableVisitable> Elements
            {
                get { return this.RequestElements(this.VertexDataProvider); }
            }

            public IDictionary<int, IAdjacencyDirectableVisitable> RequestAdjacentElements(int initialPosition)
            {
                var positions = this.AdjacencyProvider.GetAdjacentVertices(initialPosition);
                lock (positions)
                {
                    var elements = positions.Select(t => this.VertexDataProvider.Select(t)).ToDictionary(t => t.Position, t => t);
                    return elements;
                }
            }
            public void SetAdjacentVertices(int vertexPosition1, int vertexPosition2)
            {

                this.AdjacencyProvider.SetAdjacentVertices(vertexPosition1, vertexPosition2);
            }

            public void Cut(int vertexPosition1, int vertexPosition2)
            {
                lock (AdjacencyProvider.Values)
                {
                    if (DoesCutOrphanVertex(vertexPosition1, vertexPosition2))
                    {
                        throw new AdjacencyException("Error: The requested cut would orphan a vertex!");
                    }
                    this.AdjacencyProvider.UnsetAdjacencyVertices(vertexPosition1, vertexPosition2);
                }
            }

            public List<int> GetIncidentVertices(int edgePosition)
            {
                throw new NotImplementedException();
            }

            public List<int> GetIncidentEdges(int vertexPosition)
            {
                throw new NotImplementedException();
            }

            public List<EdgeNode> GetIncidentEdgeElements(int vertexPosition)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
            {
                throw new NotImplementedException();
            }

            public EdgeNode GetEdgeIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
            {
                throw new NotImplementedException();
            }

            public void Cut(IAdjacencyDirectableVisitable vertex1, IAdjacencyDirectableVisitable vertex2)
            {
                Cut(vertex1.Position, vertex2.Position);
            }
            public bool DoesCutOrphanVertex(int vertexPosition1, int vertexPosition2)
            {
                // Lock the adjacency matrix.
                lock (AdjacencyProvider.Values)
                {
                    var areVerticesAdjacent = this.AdjacencyProvider.AreVerticesBothAdjacent(vertexPosition1, vertexPosition2);
                    if (!areVerticesAdjacent) //i.e. Check if vertices are already not adjacent.
                    {
                        throw new AdjacencyException(vertexPosition1, vertexPosition2, "Vertices must exist and be adjacent when calling DoesCutOrphanVertex(..)!");
                    }

                    var first = AdjacencyProvider.Values[vertexPosition1][vertexPosition2];
                    var second = AdjacencyProvider.Values[vertexPosition2][vertexPosition1];
                    AdjacencyProvider.Values[vertexPosition1][vertexPosition2] = false;
                    AdjacencyProvider.Values[vertexPosition2][vertexPosition1] = false;
                    // Now check for orphans.
                    var firstMatches = AdjacencyProvider.Values[vertexPosition1];
                    var firstAdjacentMatches = firstMatches.Where(t => t.Value == true && t.Key != vertexPosition1); // We need a method for retrieving the vertices' adjacent elements.

                    var secondMatches = AdjacencyProvider.Values[vertexPosition2];
                    var secondAdjacentMatches = secondMatches.Where(t => t.Value == true && t.Key != vertexPosition2);
                    var firstCountIsBelow2 = firstAdjacentMatches.Count() < 2;
                    var secondCountIsBelow2 = secondAdjacentMatches.Count() < 2;

                    if (firstCountIsBelow2 || secondCountIsBelow2) // Then we have not orphaned any vertex.
                    {
                        // Then put back to normal.
                        AdjacencyProvider.Values[vertexPosition1][vertexPosition2] = first;
                        AdjacencyProvider.Values[vertexPosition2][vertexPosition1] = second;
                        return true;
                    }
                    // Else:
                    AdjacencyProvider.Values[vertexPosition1][vertexPosition2] = first;
                    AdjacencyProvider.Values[vertexPosition2][vertexPosition1] = second;
                    return false;
                }
                // First, unset the adjacency of the vertices.
                // Then, check for orphans.
                // Then, set the adjacency back the way it was.
                // Finally, unlock the adjacency matrix.
            }
        }
    }

}
