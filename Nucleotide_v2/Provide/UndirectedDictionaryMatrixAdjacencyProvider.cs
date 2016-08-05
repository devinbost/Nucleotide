using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Nucleotide_v2.Provide
{
    [Serializable]
    public class UndirectedDictionaryMatrixAdjacencyProvider : IAdjacencyProvider
    {
        private Dictionary<int, Dictionary<int, bool>>  _values;

        public Dictionary<int, Dictionary<int, bool>> Values
        {
            get
            {
                //if (_values == null)
                //{
                //    return  new SynchronizedCollection<SynchronizedCollection<bool>>();
                //}
                //else
                //{
                return _values;
                //}
            }
            set { _values = value; }
        }

        /* To add a new vertex, we need to do this: 
                for each array, 
                    CopyTo an array with larger size by +1
         * We must lock the collection during enumeration to ensure thread-safety.
         * 
               */
        //bool[][] Values { get; set; }
        public UndirectedDictionaryMatrixAdjacencyProvider()
        {
            Values = new Dictionary<int, Dictionary<int, bool>>();
        }

        //public UndirectedAdjacencyMatrix(int size)
        //{
        //    Values = new bool[size][];
        //    for (int i = 0; i < size; i++)
        //    {
        //        Values[i] = new bool[size];
        //        for (int j = 0; j < size; j++)
        //        {
        //            Values[i][j] = false;
        //        }
        //    }

        //}
        // For thread-safe enumeration, see: http://www.codeproject.com/Articles/56575/Thread-safe-enumeration-in-C
        public void Add(int vertexPosition, ErrorOnDuplicate errorOnDuplicate)
        {
            lock (Values)
            {
                // first we must check if the vertexPosition is larger than size of array.
                var currentRowCount = Values.Count;
                if (vertexPosition < currentRowCount)
                {
                    // then we must check if the identity element is true. If so, the array is already occupied there, so throw an exception.
                    if (Values.ContainsKey(vertexPosition) && Values[vertexPosition].ContainsKey(vertexPosition))
                    {
                        if (Values[vertexPosition][vertexPosition] == true)
                        {
                            if (errorOnDuplicate == ErrorOnDuplicate.Yes)
                            {
                                throw new DuplicateNameException(
                                "Error: Element already exists at specified position in UndirectedAdjacencyMatrix.");
                            }
                            // else, do nothing.

                        }
                        else
                        {
                            // Else, we can set the identity for that position to true.
                            Values[vertexPosition][vertexPosition] = true;
                        }
                    }
                }
                else
                {
                    var rowCountDiff = vertexPosition - currentRowCount; // 2 = 10 - 8.
                    for (int i = 0; i <= rowCountDiff; i++)
                    {
                        // for each place in the gap, we must construct a row with size equal to our new position.
                        var newRow = new Dictionary<int, bool>(vertexPosition);
                        // we need to first initialize the values of the new row.
                        for (int j = 0; j <= vertexPosition; j++)
                        // the number of column values we must add increases with the number of rows.
                        {
                            newRow.Add(j, false); // initialize to default as false.
                        }
                        // Values.Add(i + size -1,newRow); // Use this line if we get out of bounds exception.
                        Values.Add(i + currentRowCount, newRow); // These keys must be new (>i) because we are adding the elements to the end of the list.
                        // If any rows have fewer elements (i.e. columns) than newRow, we must add elements (false) to them.
                        // Get rows that have fewer elements than newRow.
                        var newRowColumns = newRow.Count;
                        for (int j = 0; j < Values.Count; j++) // < or <= ??
                        {
                            int currentColumnCount = Values[j].Count;
                            if (currentColumnCount < newRow.Count) // i.e. if our rows don't yet have same numbers of columns.
                            {
                                var columnCountDiff = newRowColumns - currentColumnCount; // i.e. get the diff for the starting index position of new columns
                                for (int k = 0; k < columnCountDiff; k++)
                                {
                                    Values[j].Add(k + currentColumnCount, false);
                                    // Add default elements to the row until the number of elements matches newRow.
                                }
                            }
                        }

                        // At this point, all of the rows should have equal numbers of columns.

                        for (int j = 0; j < vertexPosition; j++)
                        {
                            // all of the new row values should be false except for the row value at our vertexPosition.
                            var pos = currentRowCount + i;
                            var row = Values[pos];
                            Values[currentRowCount + i][j] = false;
                        }
                    }
                    Values[vertexPosition][vertexPosition] = true;
                }   
            }
        }

        public void Add(int vertexPosition)
        {
            Add(vertexPosition, ErrorOnDuplicate.No);
        }

        public void Delete(int vertexPosition)
        {
            if (this.Values.ContainsKey(vertexPosition))
            {
                this.Values.Remove(vertexPosition);
            }
        }

        public List<int> GetAdjacentVertices(int vertexPosition)
        {
            lock (Values)
            {
                var matchingRow = Values[vertexPosition];
                var matchingColumns = matchingRow
                    .Where(t => t.Value == true && t.Key != vertexPosition)
                    .Select(t => t.Key).ToList();
                return matchingColumns;
            }
        }

        public bool AreVerticesBothAdjacent(int vertexPosition1, int vertexPosition2)
        {
            return AreVerticesBothAdjacent(vertexPosition1, vertexPosition2, ErrorOnMissing.No);
        }

        public void SetAdjacentVertices(int vertexPosition1, int vertexPosition2)
        {
            SetAdjacentVertices(vertexPosition1, vertexPosition2,AddVertexToMatrixIfMissing.Yes);
        }
        
        public void SetAdjacentVertices(int vertexPosition1, IEnumerable<int> vertexPositions)
        {
            var vertexPositionList = vertexPositions.ToList();
            lock (vertexPositionList)
            {
                SetAdjacentVertices(vertexPosition1, vertexPositionList, AddVertexToMatrixIfMissing.Yes);
            }
        }

        public void UnsetAdjacencyVertices(int vertexPosition1, int vertexPosition2)
        {
            UnsetAdjacencyVertices(vertexPosition1, vertexPosition2, ErrorOnMissing.Yes);
        }
        public void UnsetAdjacencyVertices(int vertexPosition1, int vertexPosition2, ErrorOnMissing errorOnMissing)
        {
            lock (Values)
            {
                var vertex1InMatrix = this.IsVertexInMatrix(vertexPosition1);
                var vertex2InMatrix = this.IsVertexInMatrix(vertexPosition2);
                #region checkIfMissing
                if (errorOnMissing == ErrorOnMissing.Yes) // i.e. If we are not to add the vertex if it doesn't exist in the matrix:
                {
                    // then if vertices are not in the matrix yet, throw an exception.
                    if (!vertex1InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition1", "Vertex does not exist in matrix yet!");
                    }
                    if (!vertex2InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition2", "Vertex does not exist in matrix yet!");
                    }
                }
                if (errorOnMissing == ErrorOnMissing.No)
                {
                    if (!vertex1InMatrix)  // then if vertices are not in the matrix yet, they should be added.
                    {
                        this.Add(vertexPosition1);
                    }
                    if (!vertex2InMatrix)
                    {
                        this.Add(vertexPosition2);
                    }

                }
                #endregion
                // Now that both vertices are included in the matrix, we can set their adjacencies.
                // This means vertexPosition1 should be true at vertexPosition2
                //      and vertexPosition2 should be true at vertexPosition1.
                Values[vertexPosition1][vertexPosition2] = false;
                Values[vertexPosition2][vertexPosition1] = false;
            }
            
        }
        /// <summary>
        /// Note: This method could cause thread-safety issues unless we lock the collection first.
        /// </summary>
        /// <param name="vertexPosition"></param>
        /// <returns></returns>
        public bool IsVertexInMatrix(int vertexPosition)
        {
            lock (Values)
            {
                if (this.Values.Count < vertexPosition) // then vertexPosition is not included in matrix boundary at all.
                {
                    return false;
                }
                var rowContainsKey = this.Values.ContainsKey(vertexPosition);
                if (!rowContainsKey)
                {
                    return false;
                }
                var matchingRow = Values[vertexPosition];
                var columnContainsKey = matchingRow.ContainsKey(vertexPosition);
                if (!columnContainsKey)
                {
                    return false;
                }
                var cellValue = matchingRow[vertexPosition]; // This should be the identity value.
                return cellValue;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPosition2"></param>
        /// <param name="errorOnMissing">If set to No, then this method returns false if the specified vertex does not exist in this matrix.</param>
        /// <returns></returns>
        [Obsolete("This method has performance limitations. Otherwise, it works.")]
        public AreVerticesAdjacent HowVerticesBothAdjacent(int vertexPosition1, int vertexPosition2)
        {
            lock (Values)
            {
                var isVertex1InMatrix = IsVertexInMatrix(vertexPosition1);
                var isVertex2InMatrix = IsVertexInMatrix(vertexPosition2);
                if (!isVertex1InMatrix || !isVertex2InMatrix)
                {
                    return AreVerticesAdjacent.VertexIsMissingFromMatrix;
                }
                var adjacentToVertexPosition1 = this.GetAdjacentVertices(vertexPosition1);
                var adjacentToVertexPosition2 = this.GetAdjacentVertices(vertexPosition2);
                var adjacentTo1Contains2 = adjacentToVertexPosition1.Contains(vertexPosition2);
                var adjacentTo2Contains1 = adjacentToVertexPosition2.Contains(vertexPosition1);
                if (adjacentTo1Contains2 && adjacentTo2Contains1)
                {
                    return AreVerticesAdjacent.BothVerticesAreAdjacent;
                }
                if (adjacentTo1Contains2)
                {
                    return AreVerticesAdjacent.SourceVertexIsAdjacentToTarget;
                }
                if (adjacentTo2Contains1)
                {
                    return AreVerticesAdjacent.TargetVertexIsAdjacentToSource;
                }
                return AreVerticesAdjacent.NeitherVerticesAreAdjacent;
            }
            
        }
        public bool AreVerticesBothAdjacent(int vertexPosition1, int vertexPosition2, ErrorOnMissing errorOnMissing)
        {
            lock (Values)
            {
                var isVertex1InMatrix = IsVertexInMatrix(vertexPosition1);
                var isVertex2InMatrix = IsVertexInMatrix(vertexPosition2);
                if (errorOnMissing == ErrorOnMissing.Yes)
                {
                    if (!isVertex1InMatrix && !isVertex2InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition1, vertexPosition2", "Provided vertices do not exist in matrix!");
                    }
                    if (!isVertex1InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition1", "Provided vertex does not exist in matrix!");
                    }
                    if (!isVertex2InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition2", "Provided vertex does not exist in matrix!");
                    }
                }
                if (errorOnMissing == ErrorOnMissing.No)
                {
                    if (!isVertex1InMatrix || !isVertex2InMatrix)
                    {
                        return false;
                    }
                }
                var vertex2AdjacentToVertex1 = Values[vertexPosition1][vertexPosition2];
                var vertex1AdjacentToVertex2 = Values[vertexPosition2][vertexPosition1];
                if (vertex1AdjacentToVertex2 && vertex2AdjacentToVertex1)
                {
                    return true;
                }
                return false;
            }
        }
        /// <summary>
        /// These positions are zero-indexed! This sets the undirected adjacency values to true for the matrix.
        /// Note: If the values are not yet part of the matrix, AddVertexToMatrixIfMissing allows you to specify if they should be
        /// added or if an exception should be thrown.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPosition2"></param>
        /// <param name="addVertexToMatrixIfMissing">This parameter specifies if the vertices should be added to the matrix if their identities do not exist in the matrix yet.</param>
        /// <returns></returns>
        public void SetAdjacentVertices(int vertexPosition1, int vertexPosition2, AddVertexToMatrixIfMissing addVertexToMatrixIfMissing)
        {
            lock (Values)
            {
                var vertex1InMatrix = this.IsVertexInMatrix(vertexPosition1);
                var vertex2InMatrix = this.IsVertexInMatrix(vertexPosition2);
                #region checkIfMissing
                if (addVertexToMatrixIfMissing == AddVertexToMatrixIfMissing.No) // i.e. If we are not to add the vertex if it doesn't exist in the matrix:
                {
                    // then if vertices are not in the matrix yet, throw an exception.
                    if (!vertex1InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition1", "Vertex does not exist in matrix yet!");
                    }
                    if (!vertex2InMatrix)
                    {
                        throw new ArgumentOutOfRangeException("vertexPosition2", "Vertex does not exist in matrix yet!");
                    }
                }
                if (addVertexToMatrixIfMissing == AddVertexToMatrixIfMissing.Yes)
                {
                    if (!vertex1InMatrix)  // then if vertices are not in the matrix yet, they should be added.
                    {
                        this.Add(vertexPosition1);
                    }
                    if (!vertex2InMatrix)
                    {
                        this.Add(vertexPosition2);
                    }

                }
                #endregion
                // Now that both vertices are included in the matrix, we can set their adjacencies.
                // This means vertexPosition1 should be true at vertexPosition2
                //      and vertexPosition2 should be true at vertexPosition1.
                Values[vertexPosition1][vertexPosition2] = true;
                Values[vertexPosition2][vertexPosition1] = true;
            }
            
        }
        /// <summary>
        /// This method sets the adjacency indications on the adjacency matrix for the source vertex to each of the target vertices.
        /// </summary>
        /// <param name="vertexPosition1">Source vertex</param>
        /// <param name="vertexPositions">Target list.</param>
        /// <param name="addVertexToMatrixIfMissing"></param>
        public void SetAdjacentVertices(int vertexPosition1, IEnumerable<int> vertexPositions, AddVertexToMatrixIfMissing addVertexToMatrixIfMissing)
        {
            var vertexPositionsList = vertexPositions.ToList();
            lock (vertexPositionsList)
            {
                lock (Values)
                {
                    var vertex1InMatrix = this.IsVertexInMatrix(vertexPosition1);

                    var verticesNotInMatrix = vertexPositionsList.Where(t => !IsVertexInMatrix(t)).ToList();
                    #region checkIfMissing
                    if (addVertexToMatrixIfMissing == AddVertexToMatrixIfMissing.No) // i.e. If we are not to add the vertex if it doesn't exist in the matrix:
                    {
                        // then if vertices are not in the matrix yet, throw an exception.
                        if (!vertex1InMatrix)
                        {
                            throw new ArgumentOutOfRangeException("vertexPosition1", "Vertex does not exist in matrix yet!");
                        }
                        if (verticesNotInMatrix.Any())
                        {
                            throw new ArgumentOutOfRangeException("vertexPositions", "One or more vertices does not exist in matrix yet!");
                        }
                    }
                    if (addVertexToMatrixIfMissing == AddVertexToMatrixIfMissing.Yes)
                    {
                        if (!vertex1InMatrix)  // then if vertices are not in the matrix yet, they should be added.
                        {
                            this.Add(vertexPosition1);
                        }
                        verticesNotInMatrix.ForEach(t => this.Add(t)); // Add vertices to matrix if missing.
                    }
                    #endregion
                    vertexPositionsList.ForEach(t => SetAdjacentVertices(vertexPosition1, t));
                    // Now that both vertices are included in the matrix, we can set their adjacencies.
                }
            }
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

        /// <summary>
        /// This enum toggles whether or not an exception should be thrown if one or more of the provided values are not 
        /// in this matrix.
        /// </summary>
        public enum ErrorOnMissing
        {
            Yes,
            No
        }

        public enum AreVerticesAdjacent
        {
            BothVerticesAreAdjacent,
            SourceVertexIsAdjacentToTarget,
            TargetVertexIsAdjacentToSource,
            NeitherVerticesAreAdjacent,
            VertexIsMissingFromMatrix
        }
    }
}