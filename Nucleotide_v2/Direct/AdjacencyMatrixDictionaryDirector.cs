using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Exceptions;
using Nucleotide_v2.Provide;

namespace Nucleotide_v2.Direct
{
    [Serializable]
    public class AdjacencyMatrixDictionaryDirector<T> : IAdjacencyDirector
    {

        public AdjacencyMatrixDictionaryDirector(IVertexDataProvider vertexDataProvider, IAdjacencyProvider adjacencyProvider, 
            IIncidenceProvider incidenceProvider, EdgeNodeDictionaryProvider edgeNodeDictionaryProvider )
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
            if (incidenceProvider == null)
            {
                throw new NullReferenceException("incidenceProvider cannot be null when constructing AdjacencyMatrixDictionaryDirector!");
            }
            this.IncidenceProvider = incidenceProvider;
            if (edgeNodeDictionaryProvider == null)
            {
                throw new NullReferenceException("edgeNodeDictionaryProvider cannot be null when constructing AdjacencyMatrixDictionaryDirector!");
            }
            this.EdgeNodeDictionaryProvider = edgeNodeDictionaryProvider;
        }
        public EdgeNodeDictionaryProvider EdgeNodeDictionaryProvider { get; set; }
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
            directableVisitable.AdjacencyDirector = this;
            if (!this.VertexDataProvider.Elements.ContainsKey(directableVisitable.Position))
            {
                this.VertexDataProvider.Add(directableVisitable.Position, directableVisitable);
            }
            if (!this.AdjacencyProvider.Values.ContainsKey(directableVisitable.Position))
            {
                this.AdjacencyProvider.Add(directableVisitable.Position);
            }
            if (!this.IncidenceProvider.Values.ContainsKey(directableVisitable.Position))
            {
                this.IncidenceProvider.AddVertex(directableVisitable.Position);
            }
        }

        public void Deregister(IAdjacencyDirectableVisitable directableVisitable)
        {
            if (directableVisitable == null)
            {
                throw new NullReferenceException("Directable cannot be null when deregistering it with the AdjacencyMatrixDictionaryDirector!");
            }
            directableVisitable.AdjacencyDirector = null;
            this.VertexDataProvider.Delete(directableVisitable.Position);
            //this.AdjacencyProvider.Delete(directableVisitable.Position);
            //this.IncidenceProvider.DeleteVertex(directableVisitable.Position);
        }

        public IVertexDataProvider VertexDataProvider { get; set; }
        public IIncidenceProvider IncidenceProvider { get; set; }
        public IAdjacencyProvider AdjacencyProvider { get; set; }

        public IDictionary<int, IAdjacencyDirectableVisitable> RequestElements(IVertexDataProvider vertexDataProvider)
        {
            return vertexDataProvider.Elements;
        }
        public void Add(int vertexPosition1, IEnumerable<int> vertexPositions)
        {
            SetAdjacentVertices(vertexPosition1, vertexPositions);
        }
        
        public bool AreVerticesBothIncident(int vertexPosition1, int vertexPosition2)
        {
            return this.IncidenceProvider.AreVerticesBothIncident(vertexPosition1, vertexPosition2);
        }
        public IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            var edges = this.IncidenceProvider.GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2);
            return edges;
        }
        public EdgeNode GetEdgeIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            var edges = this.IncidenceProvider.GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2).ToList();
            if (edges.Count > 1)
            {
                throw new TooManyEdgesException(vertexPosition1, vertexPosition2);
            }
            if (!edges.Any())
            {
                throw new NotEnoughEdgesException(
                    "See GetEdgeIncidentToBothVertices() in AdjacencyMatrixDictionaryDirector. ", vertexPosition1,
                    vertexPosition2);
            }
            var firstEdge = edges.FirstOrDefault();
            // what is firstEdge if no edges exist?
            var node = this.EdgeNodeDictionaryProvider.GetEdgeNodeByEdgePosition(firstEdge);
            return node;
        } 
        public void SetAdjacentVertices(int vertexPosition1, IEnumerable<int> vertexPositions)
        {
            var vertexPositionsList = vertexPositions.ToList();
            lock (vertexPositionsList)
            {
                this.ConstructEdgesFromVertexPairs(vertexPosition1, vertexPositionsList);
                this.AdjacencyProvider.SetAdjacentVertices(vertexPosition1, vertexPositionsList);
            }
        }

        private void ConstructEdgesFromVertexPairs(int vertexPosition1, List<int> vertexPositionsList)
        {
            var edges = this.IncidenceProvider.SetIncidentVertices(vertexPosition1, vertexPositionsList);
            // I could use a factory method here that constructs EdgeNode<T> objects.
            lock (edges)
            {
                edges.ForEach(ConstructEdgeFromPosition);
            }
        }

        public List<int> GetIncidentEdges(int vertexPosition)
        {
            return this.IncidenceProvider.GetIncidentEdges(vertexPosition);
        }
        public List<EdgeNode> GetIncidentEdgeElements(int vertexPosition)
        {
            var edgePositions = this.GetIncidentEdges(vertexPosition);
            var edgeElements = new List<EdgeNode>();
            foreach (var edgePosition in edgePositions)
            {
                var element = this.EdgeNodeDictionaryProvider.Select(edgePosition);
                edgeElements.Add(element);
            }
            return edgeElements;
        }
        public List<int> GetIncidentVertices(int edgePosition)
        {
            return this.IncidenceProvider.GetIncidentVertices(edgePosition);
        }
        private void ConstructEdgeFromPosition(int edgePosition)
        {
            var newNode = new EdgeNode(edgePosition);
            EdgeNodeDictionaryProvider.Add(edgePosition, newNode);
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
            this.ConstructEdgeFromVertexPair(vertexPosition1, vertexPosition2);
            this.AdjacencyProvider.SetAdjacentVertices(vertexPosition1, vertexPosition2);
        }

        public void Add(int vertexPosition1, int vertexPosition2)
        {
            SetAdjacentVertices(vertexPosition1, vertexPosition2);
        }
        private void ConstructEdgeFromVertexPair(int vertexPosition1, int vertexPosition2)
        {
            var edgePosition = this.IncidenceProvider.SetIncidentVertices(vertexPosition1, vertexPosition2);
            this.ConstructEdgeFromPosition(edgePosition);
        }
        /// <summary>
        /// This method calls AdjacencyProvider.UnsetAdjacencyVertices(..) and IncidenceProvider.UnsetIncidentVertices(..)
        /// after checking if the cut orphans vertices.
        /// Note: We may want a parameter that allows us to force the cut to occur even if it would create an orphan.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPosition2"></param>
        public void Cut(int vertexPosition1, int vertexPosition2)
        {
            lock (AdjacencyProvider.Values)
            {
                lock (IncidenceProvider.Values)
                {
                    if (DoesCutOrphanVertex(vertexPosition1, vertexPosition2))
                    {
                        throw new AdjacencyException("Error: The requested cut would orphan a vertex!");
                    }
                    this.AdjacencyProvider.UnsetAdjacencyVertices(vertexPosition1, vertexPosition2);
                    this.IncidenceProvider.UnsetIncidentVertices(vertexPosition1, vertexPosition2);
                }
                
                
            }
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

                if ( firstCountIsBelow2 || secondCountIsBelow2) // Then we have not orphaned any vertex.
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
