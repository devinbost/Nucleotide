using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nucleotide_v2.Exceptions;

namespace Nucleotide_v2.Provide
{
    /// <summary>
    /// The IncidenceProvider and UndirectedDictionaryMatrixIncidenceProvider only provide information about positions.
    /// Edges are columns. (A column is an Edge.)
    /// Vertices are rows. (A row is a Vertex.)
    /// </summary>
    [Serializable]
    public class UndirectedDictionaryMatrixIncidenceProvider : IIncidenceProvider
    {
        // The sum of the values in each column must equal 2, or 0.
        // If the sum is 1, then the edge is an orphan. An edge cannot have >2 for its columns.
        // Each column represents an edge.
        private Dictionary<int, Dictionary<int, bool>> _values;

        public Dictionary<int, Dictionary<int, bool>> Values
        {
            get
            {
                return _values;
            }
            set { _values = value; }
        }
        public UndirectedDictionaryMatrixIncidenceProvider()
        {
            Values = new Dictionary<int, Dictionary<int, bool>>();
        }
        public bool IsVertexInMatrix(int vertexPosition)
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

        public bool IsEdgeInMatrix(int edgePosition)
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


        public void DeleteVertex(int vertexPosition)
        {
            if (this.Values.ContainsKey(vertexPosition))
            {
                this.Values.Remove(vertexPosition);
            }
        }

        public void Add(int vertexPosition, int edgePosition)
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
        public void AddEdge(int edgePosition)
        {
            AddEdge(edgePosition, ErrorOnDuplicate.No);
        }
        public void AddEdge(int edgePosition, ErrorOnDuplicate errorOnDuplicate)
        {
            // Remember, when we add a new edge, we must add the new column to every row.
            lock (Values)
            {
                if (!Values.Any())
                {
                    AddVertex(0);
                }
                if (!this.IsEdgeInMatrix(edgePosition)) // i.e. if column is not in all rows.
                {
                    foreach (var row in Values)  // then add the new column to every row
                    {
                        // Add up to the missing edge.
                        for (int i = 0; i <= edgePosition; i++) // Performance can be improved if we only need to check the diff.
                        {
                            if (!row.Value.ContainsKey(i))
                            {
                                row.Value.Add(i, false);
                            }
                        }
                       
                        {
                            if (errorOnDuplicate == ErrorOnDuplicate.Yes)
                            {
                                throw new IncidenceException("Duplicate edge = " + edgePosition + " detected!");
                            }
                        }

                    }
                }

            }
            
        }
        public void AddVertex(int vertexPosition, ErrorOnDuplicate errorOnDuplicate)
        {
            lock (Values)
            {
                if (!Values.Any())
                {
                    // Add values up to the specified vertex.
                    for (int i = 0; i <= vertexPosition; i++)
                    {
                        if (!Values.ContainsKey(i)) // if the row is missing, add it.
                        {
                            Values.Add(i, new Dictionary<int, bool>());
                            // Now that we've added a new row, we must create its columns up to the rowcount of the first row.
                            // Add an entry for edge 0.
                            if (!Values[i].ContainsKey(0))
                            {
                                Values[i].Add(0, false); // i.e. if the cell does not have a dictionary entry (for column 0), then add it. 
                            }
                            
                        }
                    }
                }
                var columnCount = Values.FirstOrDefault().Value.Count; // We may also need to ensure that all required columns exist.
                if (Values.ContainsKey(vertexPosition)) // If duplicate, throw exception if indicated.
                {
                    if (Values[vertexPosition].Count == columnCount) // if column counts match, we should be okay.
                    {
                        if (errorOnDuplicate == ErrorOnDuplicate.Yes)
                        {
                            throw new IncidenceException("Duplicate vertex = " + vertexPosition + " deteted!");
                        }
                    }
                    else  // if column counts don't match, then we need to create some columns.
                    {
                        // At this point, we know that Values[vertexPosition] exists.
                        for (int i = 0; i < columnCount; i++)
                        {
                            if (!Values[vertexPosition].ContainsKey(i))
                            {
                                Values[vertexPosition].Add(i, false);
                            }
                        } // Now that we've created the columns for the new row.
                        
                    }
                    
                }
                else // i.e. if row does not exist in matrix, we must create entries up to that row number.
                {
                    for (int i = 0; i <= vertexPosition; i++)
                    {
                        if (!Values.ContainsKey(i)) // if the row is missing, add it.
                        {
                            Values.Add(i, new Dictionary<int, bool>());
                            // Now that we've added a new row, we must create its columns up to the rowcount of the first row.
                            for (int j = 0; j < columnCount; j++)
                            {
                                Values[i].Add(j, false); // i.e. if the cell does not have a dictionary entry (for column), then add it.
                            }
                        }
                    }
                    
                }
            }
        }
        public void AddVertex(int vertexPosition)
        {
            AddVertex(vertexPosition, ErrorOnDuplicate.No);
        }

        /// <summary>
        /// This enum toggles whether or not an exception should be thrown if one or more of the provided values are not 
        /// in this matrix.
        /// </summary>
        public enum ErrorOnMissing
        {
            Yes,
            No
        }
        /// <summary>
        /// This enum indicates whether or not a vertex should be added to this matrix if its identity is missing from the matrix.
        /// </summary>
        public enum AddVertexToMatrixIfMissing
        {
            Yes,
            No
        }
        /// <summary>
        /// This enum indicates whether an exception should be thrown if one or more of the provided vertices already exist in this matrix.
        /// </summary>
        public enum ErrorOnDuplicate
        {
            Yes,
            No
        }
       

        public List<int> GetIncidentVertices(int edgePosition)
        {
            lock (Values)
            {
                var vertices = new List<int>();
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i][edgePosition] == true)
                    {
                        vertices.Add(i);
                    }
                }
                return vertices;
            }
        }

        public List<int> GetIncidentEdges(int vertexPosition)
        {
            lock (Values)
            {
                var edges = new List<int>();
                if (Values.ContainsKey(vertexPosition))
                {
                    for (int i = 0; i < Values[vertexPosition].Count; i++)
                    {
                        if (Values[vertexPosition][i] == true)
                        {
                            edges.Add(i);
                        }
                    }
                }
                
                return edges;
            }
        }

        public IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            var edgesIncidentToFirst = GetIncidentEdges(vertexPosition1);
            var edgesIncidentToSecond = GetIncidentEdges(vertexPosition2);
            var edgesInBoth = edgesIncidentToFirst.Intersect(edgesIncidentToSecond); // edgesInBoth.Count() should always be less than 2
            return edgesInBoth;
        } 
        public bool AreVerticesBothIncident(int vertexPosition1, int vertexPosition2)
        {
            // Determine if there is an edge that connects both vertices.
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

        public void SetIncidentVertex(int vertexPosition, int edgePosition)
        {
            Add(vertexPosition, edgePosition);
        }

        public int SetIncidentVertices(int vertexPosition1, int vertexPosition2)
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

        public int NextAvailableVertex
        {
            get { return Values.Count; }
        }
        public int NextAvailableEdge
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
        public List<int> SetIncidentVertices(int vertexPosition1, IEnumerable<int> vertexPositions)
        {
            lock (Values)
            {
                var edges = new List<int>();
                foreach (var vertexPosition2 in vertexPositions)
                {
                    var edge = SetIncidentVertices(vertexPosition1, vertexPosition2);
                    edges.Add(edge);
                }
                return edges;
            }
            
        }

        public void UnsetIncidentVertices(int vertexPosition1, int vertexPosition2)
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
