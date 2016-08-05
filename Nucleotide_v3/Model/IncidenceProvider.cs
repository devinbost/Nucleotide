using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v3.Exceptions;

namespace Nucleotide_v3.Model
{
    public abstract class IncidenceProvider : MatrixProvider
    {
        override protected internal bool IsVertexInMatrix(int vertexPosition)
        {
            lock (Values)
            { // Note: A row is a vertex, and a column is an edge.
                if (this.Values.Count < vertexPosition) // then vertexPosition is not included in matrix boundary at all.
                {
                    return false;
                }
                var rowContainsKey = this.Values.ContainsKey(vertexPosition);
                if (!rowContainsKey)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        virtual protected internal bool IsEdgeInMatrix(int edgePosition)
        {
            // We really should only need to check the first row if the entire matrix is consistent.
            // However, insertion time is not a big deal.

            var row = Values.FirstOrDefault();
            if (!row.Value.ContainsKey(edgePosition)) // i.e. if any row does not contain the column, then the edge is not in matrix.
            {
                return false;
            }
            return true;
        }

        abstract protected internal void AddEdge(int edgePosition);

        virtual protected internal void Add(int vertexPosition, int edgePosition)
        {
            lock (Values)
            {
                AddVertex(vertexPosition);
                AddEdge(edgePosition);
                var previousValue = Values[vertexPosition][edgePosition];
                Values[vertexPosition][edgePosition] = true;
                var verticesIncidentToEdge = GetIncidentVertices(edgePosition);
                if (verticesIncidentToEdge.Count > 2)
                {
                    Values[vertexPosition][edgePosition] = previousValue;
                    throw new IncidenceException("Error: The specified edge is already incident to two vertices! Edge = "
                        + edgePosition);
                }

                // Should we ensure that only two row values are true for the given column?
            }
            // if edge is not in matrix, we must add it. 
            // If the vertex is not in matrix, we must add it.
            // Then we can retrieve it and set its appropriate vertexPosition to true.
            //
        }

        virtual protected internal List<int> GetIncidentVertices(int edgePosition)
        {
            lock (Values)
            {
                var vertices = new List<int>(edgePosition);
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i][edgePosition])
                    {
                        vertices.Add(i);
                    }
                }
                return vertices;
            }
        }
        /// <summary>
        /// This method is slightly faster than GetIncidentVertices(..).
        /// </summary>
        /// <param name="edgePosition"></param>
        /// <returns></returns>
        virtual protected internal IEnumerable<int> GetIncidentVertexPositions(int edgePosition)
        {
            lock (Values)
            {
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i][edgePosition])
                    {
                        yield return i;
                    }
                }
            }
        }
        virtual protected internal List<int> GetIncidentEdges(int vertexPosition)
        {
            lock (Values)
            {
                var edges = new List<int>(vertexPosition);
                if (Values.ContainsKey(vertexPosition))
                {
                    for (int i = 0; i < Values[vertexPosition].Count; i++)
                    {
                        if (Values[vertexPosition][i]) // i.e. Values[vertexPosition][i] == true
                        {
                            edges.Add(i);
                        }
                    }
                }

                return edges;
            }
        }

        virtual protected internal bool AreVerticesBothIncident(int vertexPosition1, int vertexPosition2)
        {
            var edgesInBoth = GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2);
            if (edgesInBoth.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        virtual protected internal IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            var edgesIncidentToFirst = GetIncidentEdges(vertexPosition1);
            var edgesIncidentToSecond = GetIncidentEdges(vertexPosition2);
            var edgesInBoth = edgesIncidentToFirst.Intersect(edgesIncidentToSecond); // edgesInBoth.Count() should always be less than 2
            return edgesInBoth;
        }

        virtual protected internal int NextAvailableEdge
        {
            get
            {
                lock (Values)
                {
                    if (!Values.Any())
                    {
                        return 0;
                    }
                    var firstRow = Values.FirstOrDefault();
                    return firstRow.Value.Count;
                }
            }
        }
        //void SetIncidentVertex(int vertexPosition, int edgePosition);
        /// <summary>
        /// This method should return the edge position. If the vertices exist, it should set them.
        /// If the vertices don't exist, they must be added.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPosition2"></param>
        /// <returns></returns>
        virtual protected internal int SetVertices(int vertexPosition1, int vertexPosition2)
        {
            lock (Values)
            {
                var alreadyIncident = AreVerticesBothIncident(vertexPosition1, vertexPosition2);
                if (alreadyIncident)
                {
                    var edgesIncidentToBoth = GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2).ToList();
                    var count = edgesIncidentToBoth.Count();
                    if (count > 1)
                    {
                        throw new TooManyEdgesException(vertexPosition1, vertexPosition2);
                    }
                    else
                    {
                        if (!edgesIncidentToBoth.Any())
                        {
                            throw new IncidenceException("Error: At least one incident edge was expected! (Vertices " +
                                                     "are :" + vertexPosition1 + " and " + vertexPosition2 + " )");
                        }
                        else
                        {
                            if (count == 1)
                            {
                                return edgesIncidentToBoth.First();
                            }
                        }
                    }
                }
                var nextAvailableEdge = NextAvailableEdge;
                Add(vertexPosition1, nextAvailableEdge);
                Add(vertexPosition2, nextAvailableEdge);
                return nextAvailableEdge;
            }
        }

        /// <summary>
        /// This must return a list of edge positions. These are the edge positions that are generated from the provided vertices.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPositions"></param>
        /// <returns></returns>
        virtual protected internal List<int> SetVertices(int vertexPosition1, IEnumerable<int> vertexPositions)
        {
            lock (Values)
            {
                var edges = new List<int>();
                foreach (var vertexPosition2 in vertexPositions)
                {
                    var edge = SetVertices(vertexPosition1, vertexPosition2);
                    edges.Add(edge);
                }
                return edges;
            }
        }

        override protected internal void UnsetVertices(int vertexPosition1, int vertexPosition2)
        {
            lock (Values)
            {
                if (Values.ContainsKey(vertexPosition1) && Values.ContainsKey(vertexPosition2))
                {
                    var incidentEdges = GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2).ToList();
                    if (incidentEdges.Any())
                    {
                        if (incidentEdges.Count() > 1)
                        {
                            throw new TooManyEdgesException(vertexPosition1, vertexPosition2);
                        }
                        var edge = incidentEdges.FirstOrDefault();
                        Values[vertexPosition1][edge] = false;
                        Values[vertexPosition2][edge] = false;
                    }
                    else
                    {
                        throw new IncidenceException("Suddenly not enough edges! What happened?");
                    }

                }
            }
        }
    }
}

