using System;
using System.Collections.Generic;
using System.Linq;

namespace Nucleotide_v3.Model
{
    public abstract class AdjacencyProvider : MatrixProvider
    {
        abstract protected internal bool AreVerticesBothAdjacentAndUncut<E,V>(NodeStateContextMediator<E,V> mediator, int vertexPosition1, int vertexPosition2) 
            where E:EdgeNodeStateContext, new() 
            where V:VertexNodeStateContext, new();
        override protected internal bool IsVertexInMatrix(int vertexPosition)
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
        /// This method includes the source vertex in the result set.
        /// </summary>
        /// <param name="sourceVertexPosition"></param>
        /// <returns></returns>
        virtual protected internal IEnumerable<int> GetAdjacentVertexPositionsInclusive(int sourceVertexPosition)
        {
            lock (Values)
            {
                foreach (var value in Values[sourceVertexPosition])
                {
                    if (value.Value)
                    {
                        yield return value.Key;
                    }

                }
            }
        }  
        [Obsolete("Warning: Poor performance. Use GetAdjacentVertexPositionsInclusive(..) instead!")]
        virtual protected internal List<int> GetAdjacentVertices(int vertexPosition)
        {
            lock (Values)
            {
                var matchingRow = Values[vertexPosition];
                var matchingColumns = matchingRow
                    .Where(t => t.Value && t.Key != vertexPosition)
                    .Select(t => t.Key).ToList();
                return matchingColumns;
            }
        }
        abstract protected internal bool AreVerticesBothAdjacent(int vertexPosition1, int vertexPosition2);
        abstract protected internal void SetVertices(int vertexPosition1, int vertexPosition2);
        abstract protected internal void SetVertices(int vertexPosition1, IEnumerable<int> vertexPositions);
        
    }
}