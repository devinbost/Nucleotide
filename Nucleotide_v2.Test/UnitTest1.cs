using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nucleotide_v2.Deprecated;
using Nucleotide_v2.Direct;
using Nucleotide_v2.Exceptions;
using Nucleotide_v2.Factory;
using Nucleotide_v2.Provide;
using Nucleotide_v2.Visit;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using Nucleotide_v2.Diagnostics;

namespace Nucleotide_v2.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
            
        }

        //[TestCase]
        //public void TestMethod1()
        //{
        //    #region createVertices
        //    var v1 = VertexNodeFactory<int>.CreateNode(1);
        //    var v2 = VertexNodeFactory<int>.CreateNode(2);
        //    var v3 = VertexNodeFactory<int>.CreateNode(3);
        //    var v4 = VertexNodeFactory<int>.CreateNode(4);
        //    var v5 = VertexNodeFactory<int>.CreateNode(5);
        //    var v6 = VertexNodeFactory<int>.CreateNode(6);
        //    var v7 = VertexNodeFactory<int>.CreateNode(7);
        //    var v8 = VertexNodeFactory<int>.CreateNode(8);
        //    var v9 = VertexNodeFactory<int>.CreateNode(9);
        //    var v10 = VertexNodeFactory<int>.CreateNode(10);
        //    var v11 = VertexNodeFactory<int>.CreateNode(11);
        //    var v12 = VertexNodeFactory<int>.CreateNode(12);
        //    var v13 = VertexNodeFactory<int>.CreateNode(13);
        //    var v14 = VertexNodeFactory<int>.CreateNode(14);
        //    var v15 = VertexNodeFactory<int>.CreateNode(15);
        //    var v16 = VertexNodeFactory<int>.CreateNode(16);
        //    var v17 = VertexNodeFactory<int>.CreateNode(17);
        //    var v18 = VertexNodeFactory<int>.CreateNode(18);
        //    var v19 = VertexNodeFactory<int>.CreateNode(19);
        //    var v20 = VertexNodeFactory<int>.CreateNode(20);
        //    #endregion

        //    // The problem with using CreateNode(int n, IEnumerable k) is that it will create new nodes when we want to reference existing ones.
        //    // However, if I create the nodes from an adjacency matrix, then I can ensure that the nodes are as they should be.

        //    // Create the adjacency matrix.
        //    // Use the adjacency matrix 

        //}
        
        [Test]
        public void AdjacencyMatrix_AddElementZero_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);
        }
        [Test]
        public void AdjacencyMatrix_AddElementOne_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(1);
            Assert.AreEqual(matrix.Values[0][0], false);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], true);
        }
        [Test]
        public void AdjacencyMatrix_AddElementTwo_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][0], false); 
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[2][0], false);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);

        }
        [Test]
        public void AdjacencyMatrix_AddElementsZeroAndOne_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);
            matrix.Add(1);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], true);

        }
        [Test]
        public void AdjacencyMatrix_AddElementsOneAndZero_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(1);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], true);
            Assert.AreEqual(matrix.Values[0][0], false);
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);
        }
        [Test]
        public void AdjacencyMatrix_AddElementsZeroAndTwo_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[2][0], false);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);

        }
        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_AddElementsZeroAndTwo_ReturnsCollection()
        {
            var matrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[2][0], false);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);

        }
        [Test]
        public void AdjacencyMatrix_AddElementsTwoAndZero_ReturnsCollection()
        {
            var matrix = new UndirectedAdjacencyMatrix();
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[2][0], false);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);

        }
        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_AddElementsTwoAndZero_ReturnsCollection()
        {
            var matrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], false);
            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[2][0], false);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);
            matrix.Add(0);
            Assert.AreEqual(matrix.Values[0][0], true);

        }
        // Next, we need to test: 
            // Getting list of vertices adjacent to a given vertex.
            // Setting two vertices to be adjacent to one another.
            // Setting one vertex to be adjacent to a set of others and vice-versa.
            // Checking if two vertices are adjacent.
            // Checking the number of vertices adjacent to a given vertex (i.e. degree of vertex).
            // Removal of a vertex.
        //[Test]
        //public void UndirectedAdjacencyMatrix_AddVertexAddsToDictionary_ReturnsDictionary()
        //{
        //    var matrix = new Dictionary<int, Dictionary<int, bool>>();
        //    var columnsOfRow1 = new Dictionary<int, bool>()
        //    {
        //        {1,true}, {2,false}, {3,false}
        //    };
        //    var columnsOfRow2 = new Dictionary<int, bool>()
        //    {
        //        {1,false}, {2,true}, {3,false}
        //    };
        //    var columnsOfRow3 = new Dictionary<int, bool>()
        //    {
        //        {1,false}, {2,false}, {3,true}
        //    };
        //    matrix.AddVertex(1, columnsOfRow1);
        //    matrix.AddVertex(2, columnsOfRow2);
        //    matrix.AddVertex(3, columnsOfRow3);
            

        //    Assert.AreEqual(true, false);
        //}
        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_AddElementOne_ReturnsDictionary()
        {

            var newMatrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            newMatrix.Add(1);

            Assert.AreEqual(newMatrix.Values[0][0], false);
            Assert.AreEqual(newMatrix.Values[0][1], false);
            Assert.AreEqual(newMatrix.Values[1][0], false);
            Assert.AreEqual(newMatrix.Values[1][1], true);
        }

        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_SetVertices0And2AsAdjacent_ReturnsList()
        {
            this.UndirectedDictionaryAdjacencyMatrix_AddElementsZeroAndTwo_ReturnsCollection();
            var matrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            matrix.Add(0);

            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][0], true);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], false);

            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);

            Assert.AreEqual(matrix.Values[2][0], false);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);
            matrix.SetAdjacentVertices(0,2);
            Assert.AreEqual(matrix.Values[2][0], true);
            Assert.AreEqual(matrix.Values[0][2], true);
        }

        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_AreVerticesBothAdjacent_ReturnsTrue()
        {
            this.UndirectedDictionaryAdjacencyMatrix_AddElementsZeroAndTwo_ReturnsCollection();
            var matrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            matrix.Add(0);
            matrix.SetAdjacentVertices(0, new List<int>() { 2, 3 });
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][0], true);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], true);
            Assert.AreEqual(matrix.Values[0][3], true);

            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[1][3], false);

            Assert.AreEqual(matrix.Values[2][0], true);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);
            Assert.AreEqual(matrix.Values[2][3], false);

            Assert.AreEqual(matrix.Values[3][0], true);
            Assert.AreEqual(matrix.Values[3][1], false);
            Assert.AreEqual(matrix.Values[3][2], false);
            Assert.AreEqual(matrix.Values[3][3], true);
            Assert.AreEqual(false, matrix.AreVerticesBothAdjacent(0, 1));
            Assert.AreEqual(false, matrix.AreVerticesBothAdjacent(1, 2));
            Assert.AreEqual(false, matrix.AreVerticesBothAdjacent(1, 3));
            Assert.AreEqual(false, matrix.AreVerticesBothAdjacent(2, 3));
            Assert.AreEqual(true, matrix.AreVerticesBothAdjacent(0, 2));
            Assert.AreEqual(true, matrix.AreVerticesBothAdjacent(0, 3));
        }
        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_SetVertex0AndListAsAdjacent_ReturnsList()
        {
            this.UndirectedDictionaryAdjacencyMatrix_AddElementsZeroAndTwo_ReturnsCollection();
            var matrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            matrix.Add(0);
            matrix.SetAdjacentVertices(0, new List<int>(){2,3});
            matrix.Add(2);
            Assert.AreEqual(matrix.Values[0][0], true);
            Assert.AreEqual(matrix.Values[0][1], false);
            Assert.AreEqual(matrix.Values[0][2], true);
            Assert.AreEqual(matrix.Values[0][3], true);

            Assert.AreEqual(matrix.Values[1][0], false);
            Assert.AreEqual(matrix.Values[1][1], false);
            Assert.AreEqual(matrix.Values[1][2], false);
            Assert.AreEqual(matrix.Values[1][3], false);

            Assert.AreEqual(matrix.Values[2][0], true);
            Assert.AreEqual(matrix.Values[2][1], false);
            Assert.AreEqual(matrix.Values[2][2], true);
            Assert.AreEqual(matrix.Values[2][3], false);

            Assert.AreEqual(matrix.Values[3][0], true);
            Assert.AreEqual(matrix.Values[3][1], false);
            Assert.AreEqual(matrix.Values[3][2], false);
            Assert.AreEqual(matrix.Values[3][3], true);
        }
        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_IsVertexInMatrix_ReturnsTrue()
        {
            var newMatrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            newMatrix.Add(1);
            Assert.AreEqual(true, newMatrix.IsVertexInMatrix(1));
            newMatrix.Add(3);
            Assert.AreEqual(true, newMatrix.IsVertexInMatrix(3));
            Assert.AreEqual(false, newMatrix.IsVertexInMatrix(2));
            Assert.AreEqual(false, newMatrix.IsVertexInMatrix(0));
            
        }
        [Test]
        public void UndirectedDictionaryAdjacencyMatrix_GetAdjacentVertices_ReturnsEmptyList()
        {
            var newMatrix = new UndirectedDictionaryMatrixAdjacencyProvider();
            newMatrix.Add(1);
            newMatrix.Add(3);
            var adjacentVertices = newMatrix.GetAdjacentVertices(1);
            var adjacentVerticesHasAny = adjacentVertices.Any();
            Assert.AreEqual(false, adjacentVerticesHasAny);
            adjacentVertices = newMatrix.GetAdjacentVertices(3);
            Assert.AreEqual(false, adjacentVerticesHasAny);
        }
        
        [Test]
        public void AdjacencyMatrixDataMediator_Add_ReturnsUpdatedList()
        {
            #region data
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[]{ 2,5, 14});
            director.SetAdjacentVertices(2, new int[] {1,12,3});
            director.SetAdjacentVertices(3, new int[] { 2,9,4});
            director.SetAdjacentVertices(4, new int[] { 3,8,5});
            director.SetAdjacentVertices(5, new int[] { 4,6,1});
            director.SetAdjacentVertices(6, new int[] { 7,15,5});
            director.SetAdjacentVertices(7, new int[] { 8,17,6});
            director.SetAdjacentVertices(8, new int[] { 10,4,7});
            director.SetAdjacentVertices(9, new int[] { 11,3,10});
            director.SetAdjacentVertices(10, new int[] {8,9,18 });
            director.SetAdjacentVertices(11, new int[] { 9,12,19});
            director.SetAdjacentVertices(12, new int[] {2,11,13 });
            director.SetAdjacentVertices(13, new int[] {12,14,20 });
            director.SetAdjacentVertices(14, new int[] {13,1,15 });
            director.SetAdjacentVertices(15, new int[] {6,14,16 });
            director.SetAdjacentVertices(16, new int[] { 15,20,17});
            director.SetAdjacentVertices(17, new int[] { 7,16,18});
            director.SetAdjacentVertices(18, new int[] { 17,19,10});
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13,16,19});
            #endregion
            var visitor = new VertexNodeVisitor(5);
            visitor.Visit(v16, 2, null);
            Console.WriteLine();
            // For each position in the queue, we need to get the weight from the VertexDataProvider.
            // We can do this is constant runtime.
            var queueList = new List<Queue<Tuple<int, int>>>() {};
            foreach (var positionQueue in visitor._positionQueueList)
            {
                var queue = new Queue<Tuple<int, int>>();
                foreach (var i in positionQueue)
                {
                    var weight = director.VertexDataProvider.Elements[i].Weight;
                    var tuple = new Tuple<int, int>(i, weight);
                    queue.Enqueue(tuple);
                }
                queueList.Add(queue);
            }

            foreach (var positionStack in queueList)
            {
                if (positionStack.Count == 2)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (positionStack.Count == 3)
                {
                    Console.WriteLine();
                }
                var total = 0;
                foreach (var tuple in positionStack)
                {
                    total += tuple.Item2;
                    Console.Write(tuple.Item1 + "->" + tuple.Item2 + "; ");
                }
                //foreach (var tuple in positionStack)
                //{
                //    total += tuple.Item2;
                //    Console.Write(tuple.Item1 + "->" + tuple.Item2 + "; ");
                //}
                Console.Write("Total: {0}", total);
                Console.WriteLine();
            }
            // I need to loop through and visit the ones for the vertices with lowest path weights?

            Assert.AreEqual(true, false);
        }

       

        [Test]
        public void VertexNodeVisitor_GetElementsWithWeights_ReturnsList()
        {
            #region data
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8, 5 });
            director.SetAdjacentVertices(5, new int[] { 4, 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion
            var visitor1 = new VertexNodeVisitor(4);
            var visitor2 = new VertexNodeVisitor(4);
            visitor1.Visit(v5, 2, null);
            visitor2.Visit(v1, 2, null);
            Console.WriteLine();
            // For each position in the queue, we need to get the weight from the VertexDataProvider.
            // We can do this in linear runtime.
            var queueList = new List<Queue<Tuple<int, int>>>() { };
            foreach (var positionQueue in visitor1._positionQueueList)
            {
                var queue = new Queue<Tuple<int, int>>();
                foreach (var i in positionQueue)
                {
                    var weight = director.VertexDataProvider.Elements[i].Weight;
                    var tuple = new Tuple<int, int>(i, weight);
                    queue.Enqueue(tuple);
                }
                queueList.Add(queue);
            }
            Assert.AreEqual(queueList, visitor1.GetElementsWithWeights(director));
        }

        //[Test]
        //public void VertexNodeVisitor_IsFirstStep_ReturnsTrue()
        //{
        //    #region data
        //    // Adding an element should update both the Matrix and the VertexDataProvider
        //    var VertexDataProvider = new VertexDictionaryProvider();
        //    var AdjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
        //    var director = new AdjacencyMatrixDictionaryDirector(VertexDataProvider, AdjacencyProvider);
        //    //var v0 = new VertexNode<string>("v0", 0, director);
        //    var v1 = new VertexNode<string>("v1", 1, director);
        //    var v2 = new VertexNode<string>("v2", 2, director);
        //    var v3 = new VertexNode<string>("v3", 3, director);
        //    var v4 = new VertexNode<string>("v4", 4, director);
        //    var v5 = new VertexNode<string>("v5", 5, director);
        //    var v6 = new VertexNode<string>("v6", 6, director);
        //    var v7 = new VertexNode<string>("v7", 7, director);
        //    var v8 = new VertexNode<string>("v8", 8, director);
        //    var v9 = new VertexNode<string>("v9", 9, director);
        //    var v10 = new VertexNode<string>("v10", 10, director);
        //    var v11 = new VertexNode<string>("v11", 11, director);
        //    var v12 = new VertexNode<string>("v12", 12, director);
        //    var v13 = new VertexNode<string>("v13", 13, director);
        //    var v14 = new VertexNode<string>("v14", 14, director);
        //    var v15 = new VertexNode<string>("v15", 15, director);
        //    var v16 = new VertexNode<string>("v16", 16, director);
        //    var v17 = new VertexNode<string>("v17", 17, director);
        //    var v18 = new VertexNode<string>("v18", 18, director);
        //    var v19 = new VertexNode<string>("v19", 19, director);
        //    var v20 = new VertexNode<string>("v20", 20, director);

        //    director.SetVertices(1, new int[] { 2, 5, 14 });
        //    director.SetVertices(2, new int[] { 1, 12, 3 });
        //    director.SetVertices(3, new int[] { 2, 9, 4 });
        //    director.SetVertices(4, new int[] { 3, 8, 5 });
        //    director.SetVertices(5, new int[] { 4, 6, 1 });
        //    director.SetVertices(6, new int[] { 7, 15, 5 });
        //    director.SetVertices(7, new int[] { 8, 17, 6 });
        //    director.SetVertices(8, new int[] { 10, 4, 7 });
        //    director.SetVertices(9, new int[] { 11, 3, 10 });
        //    director.SetVertices(10, new int[] { 8, 9, 18 });
        //    director.SetVertices(11, new int[] { 9, 12, 19 });
        //    director.SetVertices(12, new int[] { 2, 11, 13 });
        //    director.SetVertices(13, new int[] { 12, 14, 20 });
        //    director.SetVertices(14, new int[] { 13, 1, 15 });
        //    director.SetVertices(15, new int[] { 6, 14, 16 });
        //    director.SetVertices(16, new int[] { 15, 20, 17 });
        //    director.SetVertices(17, new int[] { 7, 16, 18 });
        //    director.SetVertices(18, new int[] { 17, 19, 10 });
        //    director.SetVertices(19, new int[] { 18, 20, 11 });
        //    director.SetVertices(20, new int[] { 13, 16, 19 });
        //    #endregion
        //    var visitor1 = new VertexNodeVisitor(4);
        //    Assert.AreEqual(true, visitor1.IsFirstStep);
        //    visitor1.Visit(v5, 2);
        //    Assert.AreEqual(false, visitor1.IsFirstStep);
        //}
        [Test]
        public void VertexNodeCutVisitor_DoesCutOrphanVertex_ReturnsTrue()
        {
            #region data
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8 });
            director.SetAdjacentVertices(5, new int[] {  6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion
            // 5 and 4 are not adjacent in this data.

            var visitor1 = new VertexNodeVisitor(4);
            var doesCut1OrphanVertex = visitor1.DoesCutOrphanVertex(5, 6, director);
            var doesCut2OrphanVertex = visitor1.DoesCutOrphanVertex(1, 2, director);
            // To cut a vertex, the Director must remove the adjacency for a given pair of vertices, check for orphans,  
            //      put the vertices back, and indicate true or false. (We should lock the matrix during this operation.)
            // The visitor doesn't actually retain the Director, so we will need the method available on the director itself.
            // visitor1.DoesCutOrphanVertex(int Source, int Target, IAdjacencyDirector Director);
            Assert.AreEqual(true, doesCut1OrphanVertex);
            Assert.AreEqual(false, doesCut2OrphanVertex);
        }
        // We need a test for checking thread-safety and locks of methods.

        //[Test]
        //public void VertexNodeCutVisitor_Add_ReturnsUpdatedList()
        //{
        //    #region data
        //    // Adding an element should update both the Matrix and the VertexDataProvider
        //    var VertexDataProvider = new VertexDictionaryProvider();
        //    var AdjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
        //    var director = new AdjacencyMatrixDictionaryDirector(VertexDataProvider, AdjacencyProvider);
        //    //var v0 = new VertexNode<string>("v0", 0, director);
        //    var v1 = new VertexNode<string>("v1", 1, director);
        //    var v2 = new VertexNode<string>("v2", 2, director);
        //    var v3 = new VertexNode<string>("v3", 3, director);
        //    var v4 = new VertexNode<string>("v4", 4, director);
        //    var v5 = new VertexNode<string>("v5", 5, director);
        //    var v6 = new VertexNode<string>("v6", 6, director);
        //    var v7 = new VertexNode<string>("v7", 7, director);
        //    var v8 = new VertexNode<string>("v8", 8, director);
        //    var v9 = new VertexNode<string>("v9", 9, director);
        //    var v10 = new VertexNode<string>("v10", 10, director);
        //    var v11 = new VertexNode<string>("v11", 11, director);
        //    var v12 = new VertexNode<string>("v12", 12, director);
        //    var v13 = new VertexNode<string>("v13", 13, director);
        //    var v14 = new VertexNode<string>("v14", 14, director);
        //    var v15 = new VertexNode<string>("v15", 15, director);
        //    var v16 = new VertexNode<string>("v16", 16, director);
        //    var v17 = new VertexNode<string>("v17", 17, director);
        //    var v18 = new VertexNode<string>("v18", 18, director);
        //    var v19 = new VertexNode<string>("v19", 19, director);
        //    var v20 = new VertexNode<string>("v20", 20, director);

        //    director.SetVertices(1, new int[] { 2, 5, 14 });
        //    director.SetVertices(2, new int[] { 1, 12, 3 });
        //    director.SetVertices(3, new int[] { 2, 9, 4 });
        //    director.SetVertices(4, new int[] { 3, 8, 5 });
        //    director.SetVertices(5, new int[] { 4, 6, 1 });
        //    director.SetVertices(6, new int[] { 7, 15, 5 });
        //    director.SetVertices(7, new int[] { 8, 17, 6 });
        //    director.SetVertices(8, new int[] { 10, 4, 7 });
        //    director.SetVertices(9, new int[] { 11, 3, 10 });
        //    director.SetVertices(10, new int[] { 8, 9, 18 });
        //    director.SetVertices(11, new int[] { 9, 12, 19 });
        //    director.SetVertices(12, new int[] { 2, 11, 13 });
        //    director.SetVertices(13, new int[] { 12, 14, 20 });
        //    director.SetVertices(14, new int[] { 13, 1, 15 });
        //    director.SetVertices(15, new int[] { 6, 14, 16 });
        //    director.SetVertices(16, new int[] { 15, 20, 17 });
        //    director.SetVertices(17, new int[] { 7, 16, 18 });
        //    director.SetVertices(18, new int[] { 17, 19, 10 });
        //    director.SetVertices(19, new int[] { 18, 20, 11 });
        //    director.SetVertices(20, new int[] { 13, 16, 19 });
        //    #endregion
        //    var visitor1 = new VertexNodeVisitor(4);
        //    var visitor2 = new VertexNodeVisitor(4);
        //    visitor1.Visit(v5);
        //    var adjacentElements = v5.DirectableList;
        //    // Filter adjacentElements to only those with equally lowest weight.
        //    var groupedElements = from e in adjacentElements
        //        group e by e.Value.Weight;
        //        //into g
        //        //orderby g.Key ascending

        //    var firstGroup = groupedElements.OrderBy(t => t.Key).FirstOrDefault();
        //    if (firstGroup == null)
        //    {
        //        throw new NullReferenceException("firstGroup cannot be null.");
        //    }
        //    var firstUnvisitedGroupList = firstGroup.Except(visitor1.VisitedVertices).ToList();
        //    //from p in persons
        //    //  group p.car by p.PersonId into g
        //    //  select new { PersonID = g.Key, Cars = g.ToList() };
        //    var orphanedElements = new List<IAdjacencyDirectableVisitable>();
        //    foreach (var adjacentElement in firstUnvisitedGroupList)
        //    {
        //        var doesCutOrphanVertex = visitor1.DoesCutOrphanVertex(v5, adjacentElement.Value, director);
        //        if (doesCutOrphanVertex)
        //        {
        //            orphanedElements.AddVertex(adjacentElement.Value);
        //        }
        //    }
        //    if (orphanedElements.Any()) // i.e. if at least one vertex was orphaned,
        //    {
        //        if (orphanedElements.Count > 1)
        //        {
        //            throw new OrphanedVertexException("Too many orphaned vertices! (Not sure what to do.)");
        //        }
        //        var firstOrphan = orphanedElements.FirstOrDefault();
        //        // If there was one orphan, then we need to take this vertex as the next step.

        //        // We still need to check though if taking this vertex will orphan another. In that case,
        //        // we have an impossible situation.
        //        var doesFirstOrphanCutOrphanAnotherVertex = visitor1.DoesCutOrphanVertex(v5, firstOrphan, director);
        //        if (doesFirstOrphanCutOrphanAnotherVertex)
        //        {
        //            throw new OrphanedVertexException("Impossible situation. Too many orphans! ");
        //        }
        //        else
        //        {
        //            visitor1.Visit(firstOrphan); // Otherwise, visit that orphan.
        //        }
                
        //    }
        //    else // i.e. otherwise, no orphans exist
        //    {
        //        // so just get the first one that has not been visited.
        //        var firstUnvisitedVertex = firstUnvisitedGroupList.FirstOrDefault();
        //        // What happens if firstUnvisitedVertex is null?
        //        if (firstUnvisitedVertex.Value == null)
        //        {
        //            Console.WriteLine("We reached the end.");
        //        }
        //        else // So we just choose to visit the first one that exists.
        //        {
        //            visitor1.Visit(firstUnvisitedVertex.Value);
        //        }

        //    }
        //    // If the vertex isn't a subsequent step, then it is the first step.
        //    visitor1.Visit(v1); // NEXT STEP: PERFORM CUTS after checking them via visitor1.DoesCutOrphanVertex(director).
        //    visitor1.Visit(v4);
        //    visitor1.Visit(v2);
        //    visitor1.Visit(v3);
        //    visitor1.Visit(v12);
        //    visitor1.Visit(v9);
            

        //    // All I need is the information on the cut vertices and I will be able to leverage the weighting system.
        //    // So, I must detect a step. Once I can detect a step from a Source to a Target, then I'll be able to cut
        //    // adjacent vertices from the Source. 
        //    /* To perform a cut, I must:
        //     *      Get the adjacent vertices of the Source, subtract the target, and check the weights.
        //     *          For each with equally lowest weight, I must check if cutting one will orphan a vertex.
        //     *          
        //     * 
        //     * 
        //     *          
        //     * 
        //     * */
            
        //    //visitor2.Visit(v1, 2, null);
        //    Console.WriteLine();
        //    // For each position in the queue, we need to get the weight from the VertexDataProvider.
        //    // We can do this in linear runtime.
        //    var queueList = new List<Queue<Tuple<int, int>>>();
        //    queueList = visitor1.GetElementsWithWeights(director);

        //    // I need the functionality for taking steps.

        //    foreach (var positionStack in queueList)
        //    {
        //        if (positionStack.Count == 2)
        //        {
        //            Console.WriteLine();
        //            Console.WriteLine();
        //        }
        //        if (positionStack.Count == 3)
        //        {
        //            Console.WriteLine();
        //        }
        //        var total = 0;
        //        foreach (var tuple in positionStack)
        //        {
        //            total += tuple.Item2;
        //            Console.Write(tuple.Item1 + "->" + tuple.Item2 + "; ");
        //        }
        //        //foreach (var tuple in positionStack)
        //        //{
        //        //    total += tuple.Item2;
        //        //    Console.Write(tuple.Item1 + "->" + tuple.Item2 + "; ");
        //        //}
        //        Console.Write("Total: {0}", total);
        //        Console.WriteLine();
        //    }
        //    // I need to loop through and visit the ones for the vertices with lowest path weights?

        //    Assert.AreEqual(true, false);

        //    /* Here's what I need to do: 
        //     *      1. I need to start two VertexNodeCutVisitor objects on a pair of adjacent vertices.
        //     *      2. I need to get the adjacent elements of the first. 
        //     *      3. Remove the second vertex from the first's list.
        //     *      4. I need to get the adjacent elements of the second.
        //     *      5. Remove the first vertex from the second's list.
        //     *      6. For each remaining element in the first's list,
        //     *          6.1. DeleteEdge it. 
        //     *          6.2. Does the (adjacent) element that was cut now only have one element that it is adjacent to?
        //     *          6.3. If so, we have created an orphan. This means that this edge cannot be cut. So, we must take this path.
        //     *          6.4. If not, check the others.
        //     *      7. Check with the second: (check the elements in the second's list),
        //     *          7.1. If an orphan in the first list was detected
        //     *              
        //     *          7.2. If an orphan in the first list was not detected,
        //     *          DeleteEdge an element from the first's list.
        //     *          DeleteEdge an element from the second's list.
        //     *          
        //     * */



        //}
        //[Test]
        //public void VertexNode_AdjacentChosenElements_ReturnsExpectedChosenElements()
        //{
        //    #region data
        //    // Adding an element should update both the Matrix and the VertexDataProvider
        //    var dataProvider = new VertexDictionaryProvider();
        //    var AdjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
        //    var IncidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
        //    var edgeDataProvider = new EdgeNodeDictionaryProvider();
        //    var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, AdjacencyProvider, IncidenceProvider, edgeDataProvider);
        //    //var v0 = new VertexNode<string>("v0", 0, director);
        //    var v1 = new VertexNode<string>("v1", 1, director);
        //    var v2 = new VertexNode<string>("v2", 2, director);
        //    var v3 = new VertexNode<string>("v3", 3, director);
        //    var v4 = new VertexNode<string>("v4", 4, director);
        //    var v5 = new VertexNode<string>("v5", 5, director);
        //    var v6 = new VertexNode<string>("v6", 6, director);
        //    var v7 = new VertexNode<string>("v7", 7, director);
        //    var v8 = new VertexNode<string>("v8", 8, director);
        //    var v9 = new VertexNode<string>("v9", 9, director);
        //    var v10 = new VertexNode<string>("v10", 10, director);
        //    var v11 = new VertexNode<string>("v11", 11, director);
        //    var v12 = new VertexNode<string>("v12", 12, director);
        //    var v13 = new VertexNode<string>("v13", 13, director);
        //    var v14 = new VertexNode<string>("v14", 14, director);
        //    var v15 = new VertexNode<string>("v15", 15, director);
        //    var v16 = new VertexNode<string>("v16", 16, director);
        //    var v17 = new VertexNode<string>("v17", 17, director);
        //    var v18 = new VertexNode<string>("v18", 18, director);
        //    var v19 = new VertexNode<string>("v19", 19, director);
        //    var v20 = new VertexNode<string>("v20", 20, director);

        //    director.SetVertices(1, new int[] { 2, 5, 14 });
        //    director.SetVertices(2, new int[] { 1, 12, 3 });
        //    director.SetVertices(3, new int[] { 2, 9, 4 });
        //    director.SetVertices(4, new int[] { 3, 8, 5 });
        //    director.SetVertices(5, new int[] { 4, 6, 1 });
        //    director.SetVertices(6, new int[] { 7, 15, 5 });
        //    director.SetVertices(7, new int[] { 8, 17, 6 });
        //    director.SetVertices(8, new int[] { 10, 4, 7 });
        //    director.SetVertices(9, new int[] { 11, 3, 10 });
        //    director.SetVertices(10, new int[] { 8, 9, 18 });
        //    director.SetVertices(11, new int[] { 9, 12, 19 });
        //    director.SetVertices(12, new int[] { 2, 11, 13 });
        //    director.SetVertices(13, new int[] { 12, 14, 20 });
        //    director.SetVertices(14, new int[] { 13, 1, 15 });
        //    director.SetVertices(15, new int[] { 6, 14, 16 });
        //    director.SetVertices(16, new int[] { 15, 20, 17 });
        //    director.SetVertices(17, new int[] { 7, 16, 18 });
        //    director.SetVertices(18, new int[] { 17, 19, 10 });
        //    director.SetVertices(19, new int[] { 18, 20, 11 });
        //    director.SetVertices(20, new int[] { 13, 16, 19 });
        //    #endregion

        //    var visitor1 = new VertexNodeVisitor(4);
        //    visitor1.AlternateProcessing(v5, v1);
        //    visitor1.Visit(v5);
        //    visitor1.Visit(v1);
        //    var containsV1 = v5.AdjacentChosenElements.ContainsKey(v1.Position);
        //    var containsV3 = v5.AdjacentChosenElements.ContainsKey(v3.Position);
        //    var containsV4 = v5.AdjacentChosenElements.ContainsKey(v4.Position);
        //    Assert.AreEqual(true, containsV1);
        //    Assert.AreEqual(false, containsV3);
        //    visitor1.Visit(v3); // Note: 5 and 3 are not adjacent.
        //    Assert.AreEqual(false, containsV3);
        //    Assert.AreEqual(false, containsV4);
        //    containsV3 = v5.AdjacentChosenElements.ContainsKey(v3.Position);
        //    containsV4 = v5.AdjacentChosenElements.ContainsKey(v4.Position);
        //        // The problem is that we are setting vertices as Chosen when they are inspected by the visitor, rather than when they are
        //        // chosen. (Many are called but few are chosen.)
        //        // To determine if this is the initial visitation, we can simply inspect the positionQueue for null or empty. 
        //    visitor1.Visit(v4);
        //    // I wish there was a way for the vertex to track when it is visited, rather than the visitor.
        //    //      There's a difference between when a vertex is visited and when a vertex is chosen.
        //    containsV4 = v5.AdjacentChosenElements.ContainsKey(v4.Position);
        //    Assert.AreEqual(true, containsV4);
        //}

        [Test]
        public void VertexNode_AdjacentUnchosenElements_ReturnsExpectedUnchosenElements()
        {
            #region data
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8, 5 });
            director.SetAdjacentVertices(5, new int[] { 4, 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion

            var visitor1 = new VertexNodeVisitor(4);
            visitor1.Visit(v5);
            visitor1.Visit(v1);
            var containsV1 = v5.AdjacentUnchosenElements.ContainsKey(v1.Position);
            var containsV3 = v5.AdjacentUnchosenElements.ContainsKey(v3.Position);
            var containsV4 = v5.AdjacentUnchosenElements.ContainsKey(v4.Position);
            Assert.AreEqual(false, containsV1);
            Assert.AreEqual(false, containsV3);
            Assert.AreEqual(true, containsV4);
            visitor1.Visit(v3); // Note: 5 and 3 are not adjacent.
            containsV3 = v5.AdjacentUnchosenElements.ContainsKey(v3.Position);
            Assert.AreEqual(false, containsV3);
            // The problem is that we are setting vertices as Chosen when they are inspected by the visitor, rather than when they are
            // chosen. (Many are called but few are chosen.)
            // To determine if this is the initial visitation, we can simply inspect the positionQueue for null or empty. 
            visitor1.Visit(v4);
            // I wish there was a way for the vertex to track when it is visited, rather than the visitor.
            //      There's a difference between when a vertex is visited and when a vertex is chosen.
            containsV4 = v5.AdjacentUnchosenElements.ContainsKey(v4.Position);
            Assert.AreEqual(false, containsV4);
        }
        //[Test]
        //public void VertexNodeVisitor_ProcessVisitations_ProcessesListOfVertices()
        //{
        //    #region data
        //    // Adding an element should update both the Matrix and the VertexDataProvider
        //    var VertexDataProvider = new VertexDictionaryProvider();
        //    var AdjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
        //    var director = new AdjacencyMatrixDictionaryDirector(VertexDataProvider, AdjacencyProvider);
        //    //var v0 = new VertexNode<string>("v0", 0, director);
        //    var v1 = new VertexNode<string>("v1", 1, director);
        //    var v2 = new VertexNode<string>("v2", 2, director);
        //    var v3 = new VertexNode<string>("v3", 3, director);
        //    var v4 = new VertexNode<string>("v4", 4, director);
        //    var v5 = new VertexNode<string>("v5", 5, director);
        //    var v6 = new VertexNode<string>("v6", 6, director);
        //    var v7 = new VertexNode<string>("v7", 7, director);
        //    var v8 = new VertexNode<string>("v8", 8, director);
        //    var v9 = new VertexNode<string>("v9", 9, director);
        //    var v10 = new VertexNode<string>("v10", 10, director);
        //    var v11 = new VertexNode<string>("v11", 11, director);
        //    var v12 = new VertexNode<string>("v12", 12, director);
        //    var v13 = new VertexNode<string>("v13", 13, director);
        //    var v14 = new VertexNode<string>("v14", 14, director);
        //    var v15 = new VertexNode<string>("v15", 15, director);
        //    var v16 = new VertexNode<string>("v16", 16, director);
        //    var v17 = new VertexNode<string>("v17", 17, director);
        //    var v18 = new VertexNode<string>("v18", 18, director);
        //    var v19 = new VertexNode<string>("v19", 19, director);
        //    var v20 = new VertexNode<string>("v20", 20, director);

        //    director.SetVertices(1, new int[] { 2, 5, 14 });
        //    director.SetVertices(2, new int[] { 1, 12, 3 });
        //    director.SetVertices(3, new int[] { 2, 9, 4 });
        //    director.SetVertices(4, new int[] { 3, 8, 5 });
        //    director.SetVertices(5, new int[] { 4, 6, 1 });
        //    director.SetVertices(6, new int[] { 7, 15, 5 });
        //    director.SetVertices(7, new int[] { 8, 17, 6 });
        //    director.SetVertices(8, new int[] { 10, 4, 7 });
        //    director.SetVertices(9, new int[] { 11, 3, 10 });
        //    director.SetVertices(10, new int[] { 8, 9, 18 });
        //    director.SetVertices(11, new int[] { 9, 12, 19 });
        //    director.SetVertices(12, new int[] { 2, 11, 13 });
        //    director.SetVertices(13, new int[] { 12, 14, 20 });
        //    director.SetVertices(14, new int[] { 13, 1, 15 });
        //    director.SetVertices(15, new int[] { 6, 14, 16 });
        //    director.SetVertices(16, new int[] { 15, 20, 17 });
        //    director.SetVertices(17, new int[] { 7, 16, 18 });
        //    director.SetVertices(18, new int[] { 17, 19, 10 });
        //    director.SetVertices(19, new int[] { 18, 20, 11 });
        //    director.SetVertices(20, new int[] { 13, 16, 19 });
        //    #endregion
        //    var visitor1 = new VertexNodeVisitor(4);
        //    //var visitor2 = new VertexNodeVisitor(4);
        //    // We may need to update DetermineWhichVertexToChoose to alternate between directions of the path that we traverse.

        //    visitor1.Visit(v5);
        //    var nodes = visitor1.DetermineWhichVertexToChoose(v5);
        //    // We need to split up the process.
        //    var firstNode = nodes.FirstOrDefault();
        //    var lastNode = nodes.LastOrDefault();
        //    var dict = new Dictionary<int, IAdjacencyDirectableVisitable>();
        //    dict.AddVertex(v5.Position, v5);
        //    visitor1.AlternateProcessing(firstNode, lastNode, dict, 0);
        //    if (firstNode == null || lastNode == null || firstNode == lastNode)
        //    {
        //        Console.WriteLine("Now what?");
        //    }
        //    visitor1.Visit(firstNode);
        //    var firstNodeProcessed = visitor1.DetermineWhichVertexToChoose(firstNode);

        //    visitor1.Visit(lastNode);
        //    var lastNodeProcessed = visitor1.DetermineWhichVertexToChoose(lastNode);
        //    // We need to process each orphan or each vertex.
        //}
        //[Test]
        //public void VertexNodeVisitor_ProcessVisitations_ProcessesListOfVertices()
        //{
        //    #region data
        //    // Adding an element should update both the Matrix and the VertexDataProvider
        //    var dataProvider = new VertexDictionaryProvider();
        //    var AdjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
        //    var IncidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
        //    var edgeDataProvider = new EdgeNodeDictionaryProvider();
        //    var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, AdjacencyProvider, IncidenceProvider, edgeDataProvider);
        //    //var v0 = new VertexNode<string>("v0", 0, director);
        //    var v1 = new VertexNode<string>("v1", 1, director);
        //    var v2 = new VertexNode<string>("v2", 2, director);
        //    var v3 = new VertexNode<string>("v3", 3, director);
        //    var v4 = new VertexNode<string>("v4", 4, director);
        //    var v5 = new VertexNode<string>("v5", 5, director);
        //    var v6 = new VertexNode<string>("v6", 6, director);
        //    var v7 = new VertexNode<string>("v7", 7, director);
        //    var v8 = new VertexNode<string>("v8", 8, director);
        //    var v9 = new VertexNode<string>("v9", 9, director);
        //    var v10 = new VertexNode<string>("v10", 10, director);
        //    var v11 = new VertexNode<string>("v11", 11, director);
        //    var v12 = new VertexNode<string>("v12", 12, director);
        //    var v13 = new VertexNode<string>("v13", 13, director);
        //    var v14 = new VertexNode<string>("v14", 14, director);
        //    var v15 = new VertexNode<string>("v15", 15, director);
        //    var v16 = new VertexNode<string>("v16", 16, director);
        //    var v17 = new VertexNode<string>("v17", 17, director);
        //    var v18 = new VertexNode<string>("v18", 18, director);
        //    var v19 = new VertexNode<string>("v19", 19, director);
        //    var v20 = new VertexNode<string>("v20", 20, director);

        //    director.SetVertices(1, new int[] { 2, 5, 14 });
        //    director.SetVertices(2, new int[] { 1, 12, 3 });
        //    director.SetVertices(3, new int[] { 2, 9, 4 });
        //    director.SetVertices(4, new int[] { 3, 8, 5 });
        //    director.SetVertices(5, new int[] { 4, 6, 1 });
        //    director.SetVertices(6, new int[] { 7, 15, 5 });
        //    director.SetVertices(7, new int[] { 8, 17, 6 });
        //    director.SetVertices(8, new int[] { 10, 4, 7 });
        //    director.SetVertices(9, new int[] { 11, 3, 10 });
        //    director.SetVertices(10, new int[] { 8, 9, 18 });
        //    director.SetVertices(11, new int[] { 9, 12, 19 });
        //    director.SetVertices(12, new int[] { 2, 11, 13 });
        //    director.SetVertices(13, new int[] { 12, 14, 20 });
        //    director.SetVertices(14, new int[] { 13, 1, 15 });
        //    director.SetVertices(15, new int[] { 6, 14, 16 });
        //    director.SetVertices(16, new int[] { 15, 20, 17 });
        //    director.SetVertices(17, new int[] { 7, 16, 18 });
        //    director.SetVertices(18, new int[] { 17, 19, 10 });
        //    director.SetVertices(19, new int[] { 18, 20, 11 });
        //    director.SetVertices(20, new int[] { 13, 16, 19 });
        //    #endregion
        //    var visitor1 = new VertexNodeVisitor(4);
        //    //var visitor2 = new VertexNodeVisitor(4);
        //    // We may need to update DetermineWhichVertexToChoose to alternate between directions of the path that we traverse.

        //    visitor1.Visit(v5);
        //    var nodes = v5.DecideNext.Values;
        //    // We need to split up the process.
        //    var firstNode = nodes.FirstOrDefault();
        //    var secondNode = nodes.ElementAtOrDefault(1);
        //    var dict = new Dictionary<int, IAdjacencyDirectableVisitable>();
        //    dict.AddVertex(v5.Position, v5);
        //    visitor1.AlternateProcessing(firstNode, secondNode, dict, 0);
        //    //if (firstNode == null || secondNode == null || firstNode == secondNode)
        //    //{
        //    //    Console.WriteLine("Now what?");
        //    //}
        //    //visitor1.Visit(firstNode);
        //    //var firstNodeProcessed = visitor1.DetermineWhichVertexToChoose(firstNode);

        //    //visitor1.Visit(secondNode);
        //    //var lastNodeProcessed = visitor1.DetermineWhichVertexToChoose(secondNode);
        //    // We need to process each orphan or each vertex.
        //}

        [Test]
        public void VertexNode_AdjacentUnchosenElementsThatOrphanTarget_ReturnsExpectedList()
        {
            #region data
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8 });
            director.SetAdjacentVertices(5, new int[] { 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion
            // 5 and 4 are not adjacent in this data.

            var visitor1 = new VertexNodeVisitor(4);
            this.VertexNodeCutVisitor_DoesCutOrphanVertex_ReturnsTrue();

            // Any cut to 5 or from 5 should create an orphan.
            var adjacentUnchosenElementsThatOrphanTarget = v5.AdjacentUnchosenElementsThatOrphanTarget;
            var containsOne = adjacentUnchosenElementsThatOrphanTarget.ContainsKey(1);
            var containsSix = adjacentUnchosenElementsThatOrphanTarget.ContainsKey(6);
            Assert.AreEqual(true, containsOne);
            Assert.AreEqual(true, containsSix);
            Assert.AreEqual(2, adjacentUnchosenElementsThatOrphanTarget.Count);

            var adjacentUnchosenElementsThatDont = v14.AdjacentUnchosenElementsThatOrphanTarget;
            Assert.AreEqual(0, adjacentUnchosenElementsThatDont.Count);


        }
        [Test]
        public void VertexNode_AdjacentUnchosenElementsThatDoNotOrphanTarget_ReturnsExpectedList()
        {
            #region data
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8 });
            director.SetAdjacentVertices(5, new int[] { 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion
            // 5 and 4 are not adjacent in this data.

            var visitor1 = new VertexNodeVisitor(4);
            this.VertexNodeCutVisitor_DoesCutOrphanVertex_ReturnsTrue();

            // Any cut to 5 or from 5 should create an orphan.
            var adjacentUnchosenElementsThatDoNotOrphanTarget = v1.AdjacentUnchosenElementsThatDoNotOrphanTarget;
            var containsOne = adjacentUnchosenElementsThatDoNotOrphanTarget.ContainsKey(1);
            var containsSix = adjacentUnchosenElementsThatDoNotOrphanTarget.ContainsKey(6);
            var containsTwo = adjacentUnchosenElementsThatDoNotOrphanTarget.ContainsKey(2);
            var containsFive = adjacentUnchosenElementsThatDoNotOrphanTarget.ContainsKey(5);
            var containsFourteen = adjacentUnchosenElementsThatDoNotOrphanTarget.ContainsKey(14);

            Assert.AreEqual(false, containsOne);
            Assert.AreEqual(false, containsSix);
            Assert.AreEqual(true, containsTwo);
            Assert.AreEqual(false, containsFive);
            Assert.AreEqual(false, containsSix);
            Assert.AreEqual(true, containsFourteen);
            Assert.AreEqual(2, adjacentUnchosenElementsThatDoNotOrphanTarget.Count);

            var adjacentUnchosenElementsThatDont = v5.AdjacentUnchosenElementsThatDoNotOrphanTarget;
            Assert.AreEqual(0, adjacentUnchosenElementsThatDont.Count);
        }

        [Test]
        public void VertexNode_CutAllAdjacentUnchosenElementsThatDoNotOrphanTarget_ReturnsExpected()
        {
            Assert.AreEqual(true, false);
        }
        
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_AddVertex_ReturnsMatrix()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(2));
            newMatrix.AddVertex(1);
            // We can't add much of a vertex without any columns.
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values[0].ContainsKey(1));
            newMatrix.AddVertex(2);

            Assert.AreEqual(true, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(2));

            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values[1].ContainsKey(1));

            Assert.AreEqual(true, newMatrix.Values[2].ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values[2].ContainsKey(1));
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_AddEdge_ReturnsMatrix()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(2));
            newMatrix.AddVertex(1);
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(1));

            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values[0].ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values[1].ContainsKey(1));
            newMatrix.AddEdge(1);
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values[0].ContainsKey(2));
            Assert.AreEqual(false, newMatrix.Values[1].ContainsKey(2));
            newMatrix.AddEdge(2);

            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(2));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(2));
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_Add_ReturnsTrue()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(2));
            newMatrix.Add(vertexPosition: 1, edgePosition:2);
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(2));

            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(2));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(2));

            Assert.AreEqual(true, newMatrix.Values[0][0] == false);
            Assert.AreEqual(true, newMatrix.Values[1][0] == false);
            Assert.AreEqual(true, newMatrix.Values[0][1] == false);
            Assert.AreEqual(true, newMatrix.Values[1][1] == false);
            Assert.AreEqual(true, newMatrix.Values[0][2] == false);
            Assert.AreEqual(true, newMatrix.Values[1][2] == true);

            newMatrix.Add(vertexPosition: 1, edgePosition: 2); // add again to ensure duplicates are handled appropriately
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values.ContainsKey(1));
            Assert.AreEqual(false, newMatrix.Values.ContainsKey(2));

            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(0));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(1));
            Assert.AreEqual(true, newMatrix.Values[0].ContainsKey(2));
            Assert.AreEqual(true, newMatrix.Values[1].ContainsKey(2));

            Assert.AreEqual(true, newMatrix.Values[0][0] == false);
            Assert.AreEqual(true, newMatrix.Values[1][0] == false);
            Assert.AreEqual(true, newMatrix.Values[0][1] == false);
            Assert.AreEqual(true, newMatrix.Values[1][1] == false);
            Assert.AreEqual(true, newMatrix.Values[0][2] == false);
            Assert.AreEqual(true, newMatrix.Values[1][2] == true);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_GetIncidentVertices_ReturnsListOfIntegers()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 1, edgePosition: 2);
            newMatrix.Add(vertexPosition: 3, edgePosition: 2);
            var vertices = newMatrix.GetIncidentVertices(2);
            var contains1 = vertices.Contains(1);
            var contains3 = vertices.Contains(3);
            Assert.AreEqual(true, contains1);
            Assert.AreEqual(true, contains3);
            Assert.AreEqual(2, vertices.Count);

        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_GetIncidentEdges_ReturnsListOfIntegers()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 2, edgePosition: 1);
            newMatrix.Add(vertexPosition: 2, edgePosition: 3);
            var edges = newMatrix.GetIncidentEdges(2);
            var contains1 = edges.Contains(1);
            var contains3 = edges.Contains(3);
            Assert.AreEqual(true, contains1);
            Assert.AreEqual(true, contains3);
            Assert.AreEqual(2, edges.Count);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_NextAvailableEdge_ReturnsTrue()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 1, edgePosition: 4);
            newMatrix.Add(2, 3);
            newMatrix.Add(3, 4);
            var nextEdge = newMatrix.NextAvailableEdge;
            Assert.AreEqual(5, nextEdge);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_NextAvailableVertex_ReturnsTrue()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 1, edgePosition: 4);
            newMatrix.Add(2, 3);
            newMatrix.Add(3, 4);
            var nextVertex = newMatrix.NextAvailableVertex;
            Assert.AreEqual(4, nextVertex);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_IsVertexInMatrix_ReturnsTrue()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_SetIncidentVertices_ReturnsInt()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 1, edgePosition: 4);
            var edge = newMatrix.SetIncidentVertices(2, 3);
            Assert.AreEqual(5, edge);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_SetIncidentVertices_ReturnsListOfInt()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 1, edgePosition: 4);
            var vertices = new List<int>() {2,3,5};
            var edges = newMatrix.SetIncidentVertices(2, vertices);

            Assert.AreEqual(true, edges.Contains(5));
            Assert.AreEqual(true, edges.Contains(6));
            Assert.AreEqual(true, edges.Contains(7));

            Assert.AreEqual(true, edges.Count == 3);
        }
        [Test]
        public void UndirectedDictionaryMatrixIncidenceProvider_UnsetIncidentVertices_ReturnsMatrix()
        {
            var newMatrix = new UndirectedDictionaryMatrixIncidenceProvider();
            newMatrix.Add(vertexPosition: 1, edgePosition: 4);
            var vertices = new List<int>() { 2, 3, 5 };
            var edges = newMatrix.SetIncidentVertices(1, vertices);

            Assert.AreEqual(true, edges.Contains(5));
            Assert.AreEqual(true, edges.Contains(6));
            Assert.AreEqual(true, edges.Contains(7));

            Assert.AreEqual(true, edges.Count == 3);
            var incidentEdge = newMatrix.GetEdgesIncidentToBothVertices(1, 2).FirstOrDefault();
            var areIncident = newMatrix.AreVerticesBothIncident(1, 2);
            Assert.AreEqual(5, incidentEdge);
            Assert.AreEqual(true, areIncident);

            newMatrix.UnsetIncidentVertices(1,2);
            areIncident = newMatrix.AreVerticesBothIncident(1, 2);
            Assert.AreEqual(false, areIncident);


        }

        [Test]
        public void AdjacencyMatrixDictionaryDirector_SetAdjacentVertices_SetsIncidentEdgeCorrectly()
        {
           
            // Adding an element should update both the Matrix and the VertexDataProvider
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            #region data
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8, 5 });
            director.SetAdjacentVertices(5, new int[] { 4, 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion
            // Perhaps I need a method on the Director to explicitly add edge information.

            var incidentEdge = director.GetEdgesIncidentToBothVertices(1, 2).FirstOrDefault();
            var areIncident = director.AreVerticesBothIncident(1, 2);
            Assert.AreEqual(1, incidentEdge);
            Assert.AreEqual(true, areIncident);

            director.Cut(1, 2);
            areIncident = director.AreVerticesBothIncident(1, 2);
            Assert.AreEqual(false, areIncident);
        }
        [Test]
        public void AdjacencyMatrixDictionaryDirector_UnsetAdjacentVertices_UnsetsIncidentEdgeCorrectly()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void AdjacencyMatrixDictionaryDirector_GetEdgeIncidentToBothVertices_ReturnsExpectedEdgeNode()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void VertexNode_DeepClone_ProvidersDoNotShareData()
        {
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            #region data
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8, 5 });
            director.SetAdjacentVertices(5, new int[] { 4, 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion

            var v1Clone = v1.DeepClone();
            v1Clone.Choose();
            var chosenContainsV1 = v2.AdjacentChosenElements.ContainsKey(1);
            var unchosenContainsV1 = v2.AdjacentUnchosenElements.ContainsKey(1);
            Assert.AreEqual(false, chosenContainsV1);
            Assert.AreEqual(true, unchosenContainsV1);

            v1.Choose(); // The fact that v1 was chosen should not appear for v2 until we operate on the actual object, rather than a clone.
            chosenContainsV1 = v2.AdjacentChosenElements.ContainsKey(1);
            unchosenContainsV1 = v2.AdjacentUnchosenElements.ContainsKey(1);
            Assert.AreEqual(true, chosenContainsV1);
            Assert.AreEqual(false, unchosenContainsV1);
        }
        [Test]
        public void VertexNodeVisitor_Walk_ReachesFirstStep()
        {
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            #region data
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8, 5 });
            director.SetAdjacentVertices(5, new int[] { 4, 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion

            var visitor = new VertexNodeVisitor();
            visitor.Walk(v5);
        }
        [Test]
        public void VertexNode_DeepClone_PerformanceTest()
        {
            var dataProvider = new VertexDictionaryProvider();
            var adjacencyProvider = new UndirectedDictionaryMatrixAdjacencyProvider();
            var incidenceProvider = new UndirectedDictionaryMatrixIncidenceProvider();
            var edgeDataProvider = new EdgeNodeDictionaryProvider();
            var director = new AdjacencyMatrixDictionaryDirector<string>(dataProvider, adjacencyProvider, incidenceProvider, edgeDataProvider);
            #region data
            //var v0 = new VertexNode<string>("v0", 0, director);
            var v1 = new VertexNode<string>("v1", 1, director);
            var v2 = new VertexNode<string>("v2", 2, director);
            var v3 = new VertexNode<string>("v3", 3, director);
            var v4 = new VertexNode<string>("v4", 4, director);
            var v5 = new VertexNode<string>("v5", 5, director);
            var v6 = new VertexNode<string>("v6", 6, director);
            var v7 = new VertexNode<string>("v7", 7, director);
            var v8 = new VertexNode<string>("v8", 8, director);
            var v9 = new VertexNode<string>("v9", 9, director);
            var v10 = new VertexNode<string>("v10", 10, director);
            var v11 = new VertexNode<string>("v11", 11, director);
            var v12 = new VertexNode<string>("v12", 12, director);
            var v13 = new VertexNode<string>("v13", 13, director);
            var v14 = new VertexNode<string>("v14", 14, director);
            var v15 = new VertexNode<string>("v15", 15, director);
            var v16 = new VertexNode<string>("v16", 16, director);
            var v17 = new VertexNode<string>("v17", 17, director);
            var v18 = new VertexNode<string>("v18", 18, director);
            var v19 = new VertexNode<string>("v19", 19, director);
            var v20 = new VertexNode<string>("v20", 20, director);

            director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
            director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
            director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
            director.SetAdjacentVertices(4, new int[] { 3, 8, 5 });
            director.SetAdjacentVertices(5, new int[] { 4, 6, 1 });
            director.SetAdjacentVertices(6, new int[] { 7, 15, 5 });
            director.SetAdjacentVertices(7, new int[] { 8, 17, 6 });
            director.SetAdjacentVertices(8, new int[] { 10, 4, 7 });
            director.SetAdjacentVertices(9, new int[] { 11, 3, 10 });
            director.SetAdjacentVertices(10, new int[] { 8, 9, 18 });
            director.SetAdjacentVertices(11, new int[] { 9, 12, 19 });
            director.SetAdjacentVertices(12, new int[] { 2, 11, 13 });
            director.SetAdjacentVertices(13, new int[] { 12, 14, 20 });
            director.SetAdjacentVertices(14, new int[] { 13, 1, 15 });
            director.SetAdjacentVertices(15, new int[] { 6, 14, 16 });
            director.SetAdjacentVertices(16, new int[] { 15, 20, 17 });
            director.SetAdjacentVertices(17, new int[] { 7, 16, 18 });
            director.SetAdjacentVertices(18, new int[] { 17, 19, 10 });
            director.SetAdjacentVertices(19, new int[] { 18, 20, 11 });
            director.SetAdjacentVertices(20, new int[] { 13, 16, 19 });
            #endregion

            var visitor = new VertexNodeVisitor();
            //visitor.Walk(v5);
            var time1 = PerformanceAnalysisUtility.Time(() =>
            {
                v1.DeepClone();
            });
            var time2 = PerformanceAnalysisUtility.Time(() =>
            {
                v2 = new VertexNode<string>("v2", 2, director);
                director.SetAdjacentVertices(1, new int[] { 2, 5, 14 });
                director.SetAdjacentVertices(2, new int[] { 1, 12, 3 });
                director.SetAdjacentVertices(3, new int[] { 2, 9, 4 });
                
            });

            Console.WriteLine("DeepClone() Elapsed={0} TotalMilliseconds", time1.TotalMilliseconds);
            Console.WriteLine("new VertexNode construction and setting vertices Elapsed={0} TotalMilliseconds", time2.TotalMilliseconds);
            Assert.Less(time2.TotalMilliseconds, time1.TotalMilliseconds);
        }

        [Test]
        public void EdgeNodeFlyweightFactory_Construct_ReturnsNode()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void NodeStateMediation_Construct_ChangesToNodeStateShouldOnlyAffectMediation()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void VertexNodeFlyweightFactory_Construct_ReturnsNode()
        {
            Assert.AreEqual(true, false);
        }

    }
}
