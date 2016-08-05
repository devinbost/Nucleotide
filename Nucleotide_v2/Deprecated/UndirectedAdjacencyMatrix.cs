using System.Collections.Generic;
using System.Data;

namespace Nucleotide_v2.Deprecated
{
    /// <summary>
    /// This is for an UndirectedAdjacencyMatrix.
    /// </summary>
    public class UndirectedAdjacencyMatrix
    {
        private SynchronizedCollection<SynchronizedCollection<bool>> _values;

        public SynchronizedCollection<SynchronizedCollection<bool>> Values
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
        public UndirectedAdjacencyMatrix()
        {
            Values = new SynchronizedCollection<SynchronizedCollection<bool>>();
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
        public void Add(int vertexPosition)
        {
            // first we must check if the vertexPosition is larger than size of array.
            var size = Values.Count;
            if (vertexPosition < size)
            {// then we must check if the identity element is true. If so, the array is already occupied there, so throw an exception.
                if (Values[vertexPosition][vertexPosition] == true)
                {
                    throw new DuplicateNameException("Error: Element already exists at specified position in UndirectedAdjacencyMatrix.");
                }
                else
                {// Else, we can set the identity for that position to true.
                    Values[vertexPosition][vertexPosition] = true;
                }
            }
            else
            {
                var difference = vertexPosition - size; // 2 = 10 - 8.
                for (int i = 0; i <= difference; i++)
                {
                    // for each place in the gap, we must construct a row with size equal to our new position.
                    var newRow = new SynchronizedCollection<bool>(vertexPosition);
                    // we need to first initialize the values of the new row.
                    for (int j = 0; j <= vertexPosition; j++) // the number of column values we must add increases with the number of rows.
                    {
                        newRow.Add(false); // initialize to default as false.
                    }
                    
                    Values.Add(newRow); // If any rows have fewer elements (i.e. columns) than newRow, we must add elements (false) to them.
                    // Get rows that have fewer elements than newRow.
                    var newRowColumns = newRow.Count;
                    for (int j = 0; j < Values.Count; j++)
                    {
                        int currentRowCount = Values[j].Count;
                        if (currentRowCount < newRow.Count)
                        {
                            var elementCountDiff = newRowColumns - currentRowCount;
                            for (int k = 0; k < elementCountDiff; k++)
                            {
                                Values[j].Add(false); // Add default elements to the row until the number of elements matches newRow.
                            }
                        }
                    }
                   
                    // At this point, all of the rows should have equal numbers of columns.
                    
                    for (int j = 0; j < vertexPosition; j++)
                    {
                        // all of the new row values should be false except for the row value at our vertexPosition.
                        var pos = size + i;
                        var row = Values[pos];
                        Values[size + i][j] = false;
                    }
                }
                Values[vertexPosition][vertexPosition] = true;
            }

        }

        //public List<int> AdjacentVertexPositions(int sourceVertexPosition)
        //{
        //    // first we must ensure that the adjacencyMatrix actually contains the sourceVertexPosition.
        //    // Otherwise, we will get an ArgumentOutOfRange or similar exception.
        //    if (this.Values.Count <= sourceVertexPosition)
        //    {
        //        throw new ArgumentOutOfRangeException("sourceVertexPosition", "The requested vertex does not exist in this matrix when calling AdjacentVertexPositions(..)!");
        //    }
        //    // I need to get the row positions for the column values matching the given vertex where the column value is true.
            
        //    // In order to filter those values as described and still preserve the positions, I must need to use dictionaries to store the values.

        //    var matches = this.Values.w
        //} 
        //public UndirectedAdjacencyMatrix(int size)
        //{
        //    for (int i = 0; i <= size; i++)
        //    {
        //        Values.Add(new SynchronizedCollection<bool>(size));
        //    }
        //}

        //// public GetRow(int rowPosition){..}
        //// public GetColumn(int rowPosition){..}

        ///// <summary>
        ///// 0-indexed! When we add a new vertex, we set its 0-indexed position to true for both the row and column.
        ///// </summary>
        ///// <param name="vertexPosition"></param>
        //public void Add(int vertexPosition)
        //{
        //    var lastRowPosition = Values.Count;
        //    var lastColumnPosition = Values[lastRowPosition].Count;
        //    if (vertexPosition > lastRowPosition)
        //    {
        //        var difference = vertexPosition - lastRowPosition;
        //        for (int i = 0; i <= difference; i++)
        //        {
        //            Values.Add(new SynchronizedCollection<bool>());
        //        }
        //    }
        //    // These values should match?
        //    Values.Add(new SynchronizedCollection<bool>(0));
            
        //    Values[vertexPosition][vertexPosition] = true;



        //}
        ///// <summary>
        ///// This method adds the next available item to the array and returns the position for the new element.
        ///// </summary>
        ///// <returns></returns>
        //public int AddNext()
        //{
        //    var lastRowPosition = Values.Count;
        //    var lastColumnPosition = Values[lastRowPosition].Count;

            
        //}
        
        

    }
}
