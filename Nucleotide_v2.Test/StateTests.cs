using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Nucleotide_v2.Diagnostics;
using Nucleotide_v3.Exceptions;
using Nucleotide_v3.Model;
using Nucleotide_v3.States;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Nucleotide_v2.Test
{
    //internal class FakeVertexNodeStateContextFactory : NodeStateContextFactory<FakeVertexNodeStateContext, VertexNode>
    //{
    //    public override FakeVertexNodeStateContext ConstructDefaultNodeContext(int nodePosition)
    //    {
    //        var factory = VertexNodeFactory.GetFactory();
    //        var context = ConstructNodeContext(
    //                        nodePosition: nodePosition,
    //                        nodeState: UnchosenVertexNodeState.Instance,
    //                        nodeFactory: factory);
    //        return context;
            
    //    }

    //    public new FakeVertexNodeStateContext ConstructNodeContext(int nodePosition, NodeState nodeState, NodeFactory<VertexNode> nodeFactory)
    //    {
    //        return base.ConstructNodeContext(nodePosition, nodeState, nodeFactory);
    //    }

    //    protected new VertexNode ConstructNode(int nodePosition, NodeFactory<VertexNode> nodeFactory)
    //    {
    //        return base.ConstructNode(nodePosition, nodeFactory);
    //    }
    //}
    internal class FakeNodeStateContextMediator : NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext>
    {
       
        public FakeNodeStateContextMediator() : base()
        {
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetVertexNodesWithStateChosenMale
        {
            get { return base.GetVertexNodesWithStateChosenMale; }
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetVertexNodesWithStateChosenFemale
        {
            get { return base.GetVertexNodesWithStateChosenFemale; }
        }

        public override NodeStateContextContainerFacade<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> NodeStateContextContainerFacade { get; set; }


        public override FakeVertexNodeStateContext GetVertexNodeStateContextByPosition(int vertexPosition)
        {
            return base.GetVertexNodeStateContextByPosition(vertexPosition);
        }

        public override FakeEdgeNodeStateContext GetEdgeNodeStateContextByPosition(int edgePosition)
        {
            return base.GetEdgeNodeStateContextByPosition(edgePosition);
        }

        public override void AddVertex(int vertexPosition, VertexNodeStateContextFactory<FakeVertexNodeStateContext> factory)
        {
            base.AddVertex(vertexPosition, factory);
        }
        public override void AddVertex(int vertexPosition, int vertexValue, int vertexClause, VertexNodeStateContextFactory<FakeVertexNodeStateContext> factory)
        {
            base.AddVertex(vertexPosition, vertexValue, vertexClause, factory);
        }

        public override void AddVertices(int sourceVertexPosition, int[] targetVertexPositions)
        {
            base.AddVertices(sourceVertexPosition, targetVertexPositions);
        }

        public new  void AddVertices(int sourceVertexPosition, int[] targetVertexPositions, EdgeNodeStateContextFactory<FakeEdgeNodeStateContext> edgeFactory,
            VertexNodeStateContextFactory<FakeVertexNodeStateContext> vertexFactory)
        {
            base.AddVertices(sourceVertexPosition, targetVertexPositions, edgeFactory, vertexFactory);
        }

        public new void AddVertices(int sourceVertexPosition, int targetVertexPosition,
            EdgeNodeStateContextFactory<FakeEdgeNodeStateContext> edgeFactory, VertexNodeStateContextFactory<FakeVertexNodeStateContext> vertexFactory)
        {
            base.AddVertices(sourceVertexPosition, targetVertexPosition, edgeFactory, vertexFactory );
        }

        public new void AddEdge(int edgePosition, EdgeNodeStateContextFactory<FakeEdgeNodeStateContext> factory)
        {
            base.AddEdge(edgePosition, factory);
        }

        public override void CutEdge(int vertexPosition1, int vertexPosition2)
        {
            base.CutEdge(vertexPosition1, vertexPosition2);
        }

        public override void DeleteEdge(int vertexPosition1, int vertexPosition2)
        {
            base.DeleteEdge(vertexPosition1, vertexPosition2);
        }

        public override List<int> GetIncidentVertices(int edgePosition)
        {
            return base.GetIncidentVertices(edgePosition);
        }

        public override List<int> GetIncidentEdges(int vertexPosition)
        {
            return base.GetIncidentEdges(vertexPosition);
        }

        public override List<FakeEdgeNodeStateContext> GetIncidentEdgeElements(int vertexPosition)
        {
            return base.GetIncidentEdgeElements(vertexPosition);
        }

        public override IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            return base.GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2);
        }


        public new FakeEdgeNodeStateContext GetEdgeIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            return base.GetEdgeIncidentToBothVertices(vertexPosition1, vertexPosition2);
        }

        public new bool AreVerticesBothAdjacentAndUncut(int vertexPosition1, int vertexPosition2)
        {
            return base.AreVerticesBothAdjacentAndUncut(vertexPosition1, vertexPosition2);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithState(int vertexPosition, NodeState state)
        {
            return base.GetIncidentEdgeNodesWithState(vertexPosition, state);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithoutState(int vertexPosition, NodeState state)
        {
            return base.GetIncidentEdgeNodesWithoutState(vertexPosition, state);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithStateUncut(int vertexPosition)
        {
            return base.GetIncidentEdgeNodesWithStateUncut(vertexPosition);
        }

        public new  int GetIncidentUncutEdgeCount(int vertexPosition)
        {
            return base.GetIncidentUncutEdgeCount(vertexPosition);
        }

        public new  bool IsIncidentUncutEdgeCountAboveTwo(int vertexPosition)
        {
            return base.IsIncidentUncutEdgeCountAboveTwo(vertexPosition);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithStateUnchosen(int vertexPosition)
        {
            return base.GetIncidentEdgeNodesWithStateUnchosen(vertexPosition);
        }
        
        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithStateUnchosen(FakeVertexNodeStateContext sourceVertex)
        {
            return base.GetIncidentEdgeNodesWithStateUnchosen(sourceVertex);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetEdgeNodesWithStateChosenMale
        {
            get { return base.GetEdgeNodesWithStateChosenMale; }
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetEdgeNodesWithStateChosenFemale
        {
            get { return base.GetEdgeNodesWithStateChosenFemale; }
        }
    }
    internal class FakeConcurrentNodeStateContextMediator : NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext>
    {
        protected internal class UndirectedTestIncidenceProvider : IncidenceProvider
        {
            public new Dictionary<int, Dictionary<int, bool>> Values { get; set; }

            public UndirectedTestIncidenceProvider()
            {
                Values = new Dictionary<int,  Dictionary<int, bool>>();
            }

            protected override void AddEdge(int edgePosition)
            {
                AddEdge(edgePosition, ErrorOnDuplicate.No);
            }
            virtual protected internal List<int> GetIncidentVertices1(int edgePosition)
            {
                var vertices = new List<int>(Values.Count);
                lock (Values)
                {
                    //var vertices = new List<int>(Values.Count);
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
            virtual protected internal List<int> GetIncidentVertices2(int edgePosition)
            {
                var vertices = new List<int>(Values.Count);
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i][edgePosition])
                    {
                        vertices.Add(i);
                    }
                }
                return vertices;

            }
            virtual protected internal List<int> GetIncidentVertices3(int edgePosition)
            {
                var vertices = new int[Values.Count];
                //var vertices = new List<int>(Values.Count);
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i][edgePosition])
                    {
                        vertices[i] = i;
                    }
                }
                return vertices.ToList();

            }
            virtual protected internal int[] GetIncidentVertices4(int edgePosition)
            {
                var vertices = new int[Values.Count];
                //var vertices = new List<int>(Values.Count);
                for (int i = 0; i < Values.Count; i++)
                {
                    if (Values[i][edgePosition])
                    {
                        vertices[i] = i;
                    }
                }
                return vertices;

            }
            private void AddEdge(int edgePosition, ErrorOnDuplicate errorOnDuplicate)
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
                            // AddVertex up to the missing edge.
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
            private void AddVertex(int vertexPosition, ErrorOnDuplicate errorOnDuplicate)
            {
                lock (Values)
                {
                    if (!Values.Any())
                    {
                        // AddVertex values up to the specified vertex.
                        for (int i = 0; i <= vertexPosition; i++)
                        {
                            if (!Values.ContainsKey(i)) // if the row is missing, add it.
                            {
                                Values.Add(i, new Dictionary<int, bool>());
                                // Now that we've added a new row, we must create its columns up to the rowcount of the first row.
                                // AddVertex an entry for edge 0.
                                if (!Values[i].ContainsKey(0))
                                {
                                    Values[i].Add(0, false); // i.e. if the cell does not have a ConcurrentDictionary entry (for column 0), then add it. 
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
                                    Values[i].Add(j, false); // i.e. if the cell does not have a ConcurrentDictionary entry (for column), then add it.
                                }
                            }
                        }

                    }
                }
            }
            protected  override void AddVertex(int vertexPosition)
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

            private void SetIncidentVertex(int vertexPosition, int edgePosition)
            {
                Add(vertexPosition, edgePosition);
            }

        }
        public virtual List<int> GetIncidentVertices1(int edgePosition)
        {
            var vertices = this.IncidenceProvider.GetIncidentVertices1(edgePosition);
            return vertices;
        }
        public virtual List<int> GetIncidentVertices2(int edgePosition)
        {
            var vertices = this.IncidenceProvider.GetIncidentVertices2(edgePosition);
            return vertices;
        }
        public virtual List<int> GetIncidentVertices3(int edgePosition)
        {
            var vertices = this.IncidenceProvider.GetIncidentVertices3(edgePosition);
            return vertices;
        }
        public virtual int[] GetIncidentVertices4(int edgePosition)
        {
            var vertices = this.IncidenceProvider.GetIncidentVertices4(edgePosition);
            return vertices;
        }
        protected new UndirectedTestIncidenceProvider IncidenceProvider { get; set; }

        public FakeConcurrentNodeStateContextMediator()
            : base()
        {
            this.IncidenceProvider = new UndirectedTestIncidenceProvider();
            this.GetIncidentEdgeCache = new Dictionary<int, List<int>>();
            this.GetIncidentVertexCache = new Dictionary<int, List<int>>();
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetVertexNodesWithStateChosenMale
        {
            get { return base.GetVertexNodesWithStateChosenMale; }
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetVertexNodesWithStateChosenFemale
        {
            get { return base.GetVertexNodesWithStateChosenFemale; }
        }

        public override NodeStateContextContainerFacade<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> NodeStateContextContainerFacade { get; set; }


        public override FakeVertexNodeStateContext GetVertexNodeStateContextByPosition(int vertexPosition)
        {
            return base.GetVertexNodeStateContextByPosition(vertexPosition);
        }

        public override FakeEdgeNodeStateContext GetEdgeNodeStateContextByPosition(int edgePosition)
        {
            return base.GetEdgeNodeStateContextByPosition(edgePosition);
        }

        public override void AddVertex(int vertexPosition, VertexNodeStateContextFactory<FakeVertexNodeStateContext> factory)
        {
            base.AddVertex(vertexPosition, factory);
        }

        public override void AddVertices(int sourceVertexPosition, int[] targetVertexPositions)
        {
            base.AddVertices(sourceVertexPosition, targetVertexPositions);
        }

        public new void AddVertices(int sourceVertexPosition, int[] targetVertexPositions, EdgeNodeStateContextFactory<FakeEdgeNodeStateContext> edgeFactory,
            VertexNodeStateContextFactory<FakeVertexNodeStateContext> vertexFactory)
        {
            base.AddVertices(sourceVertexPosition, targetVertexPositions, edgeFactory, vertexFactory);
        }

        public new void AddEdge(int edgePosition, EdgeNodeStateContextFactory<FakeEdgeNodeStateContext> factory)
        {
            base.AddEdge(edgePosition, factory);
        }

        public override void CutEdge(int vertexPosition1, int vertexPosition2)
        {
            base.CutEdge(vertexPosition1, vertexPosition2);
        }

        public override void DeleteEdge(int vertexPosition1, int vertexPosition2)
        {
            base.DeleteEdge(vertexPosition1, vertexPosition2);
        }

        public override List<int> GetIncidentVertices(int edgePosition)
        {
            return base.GetIncidentVertices(edgePosition);
        }

        public override List<int> GetIncidentEdges(int vertexPosition)
        {
            return base.GetIncidentEdges(vertexPosition);
        }

        public override List<FakeEdgeNodeStateContext> GetIncidentEdgeElements(int vertexPosition)
        {
            return base.GetIncidentEdgeElements(vertexPosition);
        }

        public override IEnumerable<int> GetEdgesIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            return base.GetEdgesIncidentToBothVertices(vertexPosition1, vertexPosition2);
        }


        public new FakeEdgeNodeStateContext GetEdgeIncidentToBothVertices(int vertexPosition1, int vertexPosition2)
        {
            return base.GetEdgeIncidentToBothVertices(vertexPosition1, vertexPosition2);
        }

        public new bool AreVerticesBothAdjacentAndUncut(int vertexPosition1, int vertexPosition2)
        {
            return base.AreVerticesBothAdjacentAndUncut(vertexPosition1, vertexPosition2);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithState(int vertexPosition, NodeState state)
        {
            return base.GetIncidentEdgeNodesWithState(vertexPosition, state);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithoutState(int vertexPosition, NodeState state)
        {
            return base.GetIncidentEdgeNodesWithoutState(vertexPosition, state);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithStateUncut(int vertexPosition)
        {
            return base.GetIncidentEdgeNodesWithStateUncut(vertexPosition);
        }

        public new int GetIncidentUncutEdgeCount(int vertexPosition)
        {
            return base.GetIncidentUncutEdgeCount(vertexPosition);
        }

        public new bool IsIncidentUncutEdgeCountAboveTwo(int vertexPosition)
        {
            return base.IsIncidentUncutEdgeCountAboveTwo(vertexPosition);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithStateUnchosen(int vertexPosition)
        {
            return base.GetIncidentEdgeNodesWithStateUnchosen(vertexPosition);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentEdgeNodesWithStateUnchosen(FakeVertexNodeStateContext sourceVertex)
        {
            return base.GetIncidentEdgeNodesWithStateUnchosen(sourceVertex);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetEdgeNodesWithStateChosenMale
        {
            get { return base.GetEdgeNodesWithStateChosenMale; }
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetEdgeNodesWithStateChosenFemale
        {
            get { return base.GetEdgeNodesWithStateChosenFemale; }
        }
    }
    internal class FakeVertexNodeStateContext : VertexNodeStateContext
    {
        public FakeVertexNodeStateContext()
        {
        }

        public FakeVertexNodeStateContext(FakeVertexNodeStateContext vertexNodeStateContext)
        {
            this.State = vertexNodeStateContext.State;
            this.Node = vertexNodeStateContext.Node;
        }

        public new  void ChooseAsMale()
        {
            base.ChooseAsMale();
        }

        public new void Reset()
        {
            base.Reset();
        }
        public new  List<FakeEdgeNodeStateContext> GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(nodeStateContextMediator);
        }

        public new void CutRemainingUnchosenEdges(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            base.CutRemainingUnchosenEdges(nodeStateContextMediator);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentUnchosenEdgeNodeStateContexts(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetIncidentUnchosenEdgeNodeStateContexts(nodeStateContextMediator);
        }

        public new int NumberOfEdgesThatCanBeCut(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.NumberOfEdgesThatCanBeCut(nodeStateContextMediator);
        }

        public new bool IsUncutEdgeCountAboveTwo(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.IsUncutEdgeCountAboveTwo(nodeStateContextMediator);
        }

        public new int GetUncutEdgeCount(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetUncutEdgeCount(nodeStateContextMediator);
        }

        public new int GetNumberOfIncidentEdgesThatOrphanTargetVertex(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetNumberOfIncidentEdgesThatOrphanTargetVertex(nodeStateContextMediator);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetUnchosenEdgesThatCauseOrphans(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetUnchosenEdgesThatCauseOrphans(nodeStateContextMediator);
        }

        public new Dictionary<int, bool> WouldCutToIncidentUnchosenEdgesOrphanTargetVertexDictionary(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.WouldCutToIncidentUnchosenEdgesOrphanTargetVertexDictionary(nodeStateContextMediator);
        }

        public new IEnumerable<FakeEdgeNodeStateContext> GetIncidentUncutEdges(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetIncidentUncutEdges(nodeStateContextMediator);
        }

        public new bool WouldCutOrphanVertex(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.WouldCutOrphanVertex(nodeStateContextMediator);
        }

        public new List<FakeEdgeNodeStateContext> GetIncidentEdgeNodeStateContextsWhereStateIsNotCut(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetIncidentEdgeNodeStateContextsWhereStateIsNotCut(nodeStateContextMediator);
        }

        public new List<FakeEdgeNodeStateContext> GetIncidentEdgeNodeStateContextsWithNotMatchingState(FakeNodeStateContextMediator nodeStateContextMediator,
            NodeState state)
        {
            return base.GetIncidentEdgeNodeStateContextsWithNotMatchingState(nodeStateContextMediator, state);
        }

        public new List<FakeEdgeNodeStateContext> GetIncidentEdgeNodeStateContextsWithMatchingState(FakeNodeStateContextMediator nodeStateContextMediator,
            NodeState state)
        {
            return base.GetIncidentEdgeNodeStateContextsWithMatchingState(nodeStateContextMediator, state);
        }

        public new List<FakeEdgeNodeStateContext> GetIncidentEdgeNodeStateContexts(FakeNodeStateContextMediator nodeStateContextMediator)
        {
            return base.GetIncidentEdgeNodeStateContexts(nodeStateContextMediator);
        }

        public new  void ChooseAsOrigin()
        {
            base.ChooseAsOrigin();
        }

        public new  void ChooseAsFemale()
        {
            base.ChooseAsFemale();
        }

        public new  void Choose(NodeState.NodeGender gender)
        {
            base.Choose(gender);
        }
    }
    internal class FakeEdgeNodeStateContext : EdgeNodeStateContext
    {

        public FakeEdgeNodeStateContext()
        {
        }

        public FakeEdgeNodeStateContext(EdgeNodeStateContext context)
        {
            this.Node = context.Node;
            this.State = context.State;
        }

        public new  void Choose(NodeState.NodeGender gender)
        {
            base.Choose(gender);
        }

        public new  void ChooseAsMale()
        {
            base.ChooseAsMale();
        }

        public new  void ChooseAsFemale()
        {
            base.ChooseAsFemale();
        }

        public new  void Cut()
        {
            base.Cut();
        }

        public new  void Reset()
        {
            base.Reset();
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetIncidentVertices(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> mediator)
        {
            return base.GetIncidentVertices(mediator);
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetIncidentVerticesWithSpecifiedState(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> mediator, VertexNodeState state)
        {
            return base.GetIncidentVerticesWithSpecifiedState(mediator, state);
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetIncidentVerticesWithoutSpecifiedState(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> mediator, VertexNodeState state)
        {
            return base.GetIncidentVerticesWithoutSpecifiedState(mediator, state);
        }

        public new Tuple<FakeVertexNodeStateContext, FakeVertexNodeStateContext> GetIncidentVerticesAsTuple(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> mediator)
        {
            return base.GetIncidentVerticesAsTuple(mediator);
        }

        public new bool DoesCutOrphanVertex(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> nodeStateContextMediator)
        {
            return base.DoesCutOrphanVertex(nodeStateContextMediator);
        }

        public new bool DoesCutOrphanTargetVertex(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> nodeStateContextMediator, int sourceVertexPosition)
        {
            return base.DoesCutOrphanTargetVertex(nodeStateContextMediator, sourceVertexPosition);
        }

        public new bool DoesCutOrphanTargetVertex(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> nodeStateContextMediator, FakeVertexNodeStateContext sourceVertex)
        {
            return base.DoesCutOrphanTargetVertex(nodeStateContextMediator, sourceVertex);
        }

        public new IEnumerable<FakeVertexNodeStateContext> GetIncidentUnchosenVertexNodeStateContexts(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> nodeStateContextMediator)
        {
            return base.GetIncidentUnchosenVertexNodeStateContexts(nodeStateContextMediator);
        }

        public new FakeVertexNodeStateContext GetIncidentUnchosenVertexNodeStateContext(NodeStateContextMediator<FakeEdgeNodeStateContext, FakeVertexNodeStateContext> nodeStateContextMediator)
        {
            return base.GetIncidentUnchosenVertexNodeStateContext(nodeStateContextMediator);
        }
    }
    [TestFixture]
    public class StateTests
    {
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void VertexNodeStateContextFactory_TestingConstructionMethods_ReturnSameCollectionValues()
        {
            // Both method calls should use the same data storage.
            // Creating a second factory should 
            var vertexNodeStateContextFactory =
                VertexNodeStateContextFlyweightFactory<FakeVertexNodeStateContext>.GetInstance;
            var time1 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int i = 1; i < 1000; i++)
                {
                    var v1 = vertexNodeStateContextFactory.ConstructDefaultNodeContext(i);
                }
            }); // The second task should perform better because the flyweights are all constructed from the first loop task.
            var time2 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int i = 1; i < 1000; i++)
                {
                    var v1 = vertexNodeStateContextFactory.ConstructDefaultNodeContext(i);
                }
            });
            Console.WriteLine("First time is {0} miliseconds.", time1.TotalMilliseconds);
            Console.WriteLine("Second time is {0} miliseconds.", time2.TotalMilliseconds);
            Assert.Less(time2.TotalMilliseconds, time1.TotalMilliseconds);
            //First time is 16.2975 miliseconds.
            //Second time is 0.3346 miliseconds.

        }
        
        //[Test]
        //public void VertexNodeStateContextContainer_TestingConstructionMethods_ReturnSameCollectionValues()
        //{
        //    var vertexNodeStateContextFactory = new VertexNodeStateContextFactory();
        //    var container = new VertexNodeStateContextContainer();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
                
        //        for (int i = 1; i < 1000; i++)
        //        {
        //            var v1 = vertexNodeStateContextFactory.ConstructDefaultNodeContext(i);
        //            container.Add(v1.Position, v1);
        //        }
        //    });
        //    var time2 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        var container2 = container.Copy(vertexNodeStateContextFactory);
        //    });
        //    var time3 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        var container3 = container.DeepClone();
        //    });
        //    Console.WriteLine("First time is {0} miliseconds.", time1.TotalMilliseconds);
        //    Console.WriteLine("Second time is {0} miliseconds.", time2.TotalMilliseconds);
        //    Console.WriteLine("Third time is {0} miliseconds.", time3.TotalMilliseconds);
        //    Assert.Less(time2.TotalMilliseconds, time1.TotalMilliseconds);
        //    Assert.Less(time2.TotalMilliseconds, time3.TotalMilliseconds);
        //}

        [Test]
        public void NodeStateContextContainer_GetIncidentVertices_ReturnsExpectedList()
        {
            var mediator = new FakeNodeStateContextMediator();
            mediator.AddVertices(1, new int[] { 2, 5, 14 });
            mediator.AddVertices(2, new int[] { 1, 12, 3 });
            mediator.AddVertices(3, new int[] { 2, 9, 4 });
            mediator.AddVertices(4, new int[] { 3, 8, 5 });
            mediator.AddVertices(5, new int[] { 4, 6, 1 });
            mediator.AddVertices(6, new int[] { 7, 15, 5 });
            mediator.AddVertices(7, new int[] { 8, 17, 6 });
            mediator.AddVertices(8, new int[] { 10, 4, 7 });
            mediator.AddVertices(9, new int[] { 11, 3, 10 });
            mediator.AddVertices(10, new int[] { 8, 9, 18 });
            mediator.AddVertices(11, new int[] { 9, 12, 19 });
            mediator.AddVertices(12, new int[] { 2, 11, 13 });
            mediator.AddVertices(13, new int[] { 12, 14, 20 });
            mediator.AddVertices(14, new int[] { 13, 1, 15 });
            mediator.AddVertices(15, new int[] { 6, 14, 16 });
            mediator.AddVertices(16, new int[] { 15, 20, 17 });
            mediator.AddVertices(17, new int[] { 7, 16, 18 });
            mediator.AddVertices(18, new int[] { 17, 19, 10 });
            mediator.AddVertices(19, new int[] { 18, 20, 11 });
            mediator.AddVertices(20, new int[] { 13, 16, 19 });

            var edges = mediator.GetIncidentEdges(1);
            var incidentVertices = edges.SelectMany(t => mediator.GetIncidentVertices(t)).Distinct().ToList();
            var contains2 = incidentVertices.Any(t => t.Equals(2));
            var contains5 = incidentVertices.Any(t => t.Equals(5));
            var contains14 = incidentVertices.Any(t => t.Equals(14));
            var contains1 = incidentVertices.Any(t => t.Equals(1));
            var count = incidentVertices.Count;

            Assert.AreEqual(true, contains2);
            Assert.AreEqual(true, contains5);
            Assert.AreEqual(true, contains14);
            Assert.AreEqual(true, contains1);
            Assert.AreEqual(4, count);
        }

        [Test]
        public void NodeStateContextContainer_AddedVerticesHaveExpectedStateAndPosition_ReturnsExpectedList()
        {
            var mediator = new FakeNodeStateContextMediator();
            mediator.AddVertices(1, new int[] { 2, 5, 14 });
            var vertex2 = mediator.GetVertexNodeStateContextByPosition(2);
            var vertex1 = mediator.GetVertexNodeStateContextByPosition(1);
            Assert.NotNull(vertex2);
            Assert.NotNull(vertex1);
            Assert.AreEqual(1, vertex1.Position);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, vertex1.State);
        }
        [Test]
        public void VertexNodeStateContext_StateChangesWorkAsExpected_ReturnsExpectedStates()
        {
            var fakeMediator = new FakeNodeStateContextMediator();
            fakeMediator.AddVertices(1, new int[] { 2, 5, 14 });
            var vertex2 = fakeMediator.GetVertexNodeStateContextByPosition(2);
            var vertex1 = fakeMediator.GetVertexNodeStateContextByPosition(1);
            Assert.NotNull(vertex2);
            Assert.NotNull(vertex1);
            Assert.AreEqual(1, vertex1.Position);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, vertex1.State);
            var fakeVertex1 = new FakeVertexNodeStateContext(vertex1);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State);
            fakeVertex1.ChooseAsMale();
            Assert.AreEqual(MaleChosenVertexNodeState.Instance, fakeVertex1.State);
            fakeVertex1.Reset();
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State);
            fakeVertex1.ChooseAsFemale();
            Assert.AreEqual(FemaleChosenVertexNodeState.Instance, fakeVertex1.State);
            fakeVertex1.Reset();
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State);
            fakeVertex1.ChooseAsOrigin();
            Assert.AreEqual(OriginChosenVertexNodeState.Instance, fakeVertex1.State);
            fakeVertex1.Reset();
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State);
            //var incidentUnchosenEdges = fakeVertex1.GetIncidentEdgeNodeStateContexts(fakeMediator);


        }
        [Test]
        public void VertexNodeStateContext_StateChangesToIncidentEdgesWorkAsExpected_ReturnsExpectedStates()
        {
            var fakeMediator = new FakeNodeStateContextMediator();
            fakeMediator.AddVertices(1, new int[] { 2, 5, 14 });
            var vertex2 = fakeMediator.GetVertexNodeStateContextByPosition(2);
            var vertex1 = fakeMediator.GetVertexNodeStateContextByPosition(1);
            Assert.NotNull(vertex2);
            Assert.NotNull(vertex1);
            Assert.AreEqual(1, vertex1.Position);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, vertex1.State);
            var fakeVertex1 = new FakeVertexNodeStateContext(vertex1);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State);
            
            var incidentUnchosenEdges = fakeVertex1.GetIncidentEdgeNodeStateContexts(fakeMediator).Select(t => new FakeEdgeNodeStateContext(t)).ToList();
            incidentUnchosenEdges.ForEach(t => Assert.AreEqual(UnchosenEdgeNodeState.Instance, t.State));

            var edgeBetweenVertices1And2 = fakeMediator.GetEdgeIncidentToBothVertices(1, 2);
            var fakeEdgeBetweenVertices1And2 = new FakeEdgeNodeStateContext(edgeBetweenVertices1And2);
            // Check vertices to be diligent
                var shouldBeVertices1And2 = fakeEdgeBetweenVertices1And2.GetIncidentVertices(fakeMediator);
                var fakeVertices1And2 = shouldBeVertices1And2.Select(t => new FakeVertexNodeStateContext(t)).ToList();
                var containsVertex1 = fakeVertices1And2.Any(t => t.Position.Equals(1));
                var containsVertex2 = fakeVertices1And2.Any(t => t.Position.Equals(2));
                var countEquals2 = fakeVertices1And2.Count.Equals(2); // These should be the only vertices returned by the edgeNodeStateContext.
                Assert.AreEqual(true, containsVertex1);
                Assert.AreEqual(true, containsVertex2);
                Assert.AreEqual(true, countEquals2);
            var fakeVertex1Again = fakeVertices1And2.FirstOrDefault(t => t.Position.Equals(1));
            Assert.NotNull(fakeVertex1Again);
            
            fakeVertex1Again.ChooseAsOrigin(); // The issue is that changing the fake vertex node is not updating the mediator. 
            vertex1.ChooseAsOrigin(); // State changes must occur on the actual object!
            var incidentVertices = fakeEdgeBetweenVertices1And2.GetIncidentVertices(fakeMediator);
            var fakeOriginVertices = fakeEdgeBetweenVertices1And2.GetIncidentVerticesWithSpecifiedState(fakeMediator,
                OriginChosenVertexNodeState.Instance).ToList();
            var containsOrigin = fakeOriginVertices.Any(t => t.State.Equals(OriginChosenVertexNodeState.Instance));
            Assert.AreEqual(1, fakeOriginVertices.Count);
            Assert.AreEqual(true, containsOrigin);
            var originVertex = fakeOriginVertices.FirstOrDefault();
            Assert.NotNull(originVertex);
            
        }
        [Test]
        public void EdgeNodeStateContext_StateChangesToIncidentEdgesWorkAsExpected_ReturnsExpectedStates()
        {
            var fakeMediator = new FakeNodeStateContextMediator();
            fakeMediator.AddVertices(1, new int[] { 2, 5, 14 });
            var edgesList1 = fakeMediator.EdgeNodeStateContexts; // There should be 3 edges here: <1,2>, <1,5>, <1,14>
            Assert.AreEqual(3, edgesList1.Count, "edgesList1 should have 3 vertices");
            var verticesList1 = fakeMediator.VertexNodeStateContexts; // There should be 4 vertices here: 1,2,5,14
            var vertex2 = fakeMediator.GetVertexNodeStateContextByPosition(2);
            var vertex1 = fakeMediator.GetVertexNodeStateContextByPosition(1);
            var isVertex1InMatrix = fakeMediator.IsVertexInMatrix(1);
            Assert.AreEqual(true, isVertex1InMatrix, "isVertex1InMatrix");
            Assert.NotNull(vertex2, "vertex2 != null");
            Assert.NotNull(vertex1, "vertex1 != null");
            Assert.AreEqual(1, vertex1.Position, "vertex1.Position == 1");
            Assert.AreEqual(UnchosenVertexNodeState.Instance, vertex1.State);
            var fakeVertex1 = new FakeVertexNodeStateContext(vertex1);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State, "fakeVertex1.State");

            var incidentUnchosenEdges = fakeVertex1.GetIncidentEdgeNodeStateContexts(fakeMediator).Select(t => new FakeEdgeNodeStateContext(t)).ToList();
            incidentUnchosenEdges.ForEach(t => Assert.AreEqual(UnchosenEdgeNodeState.Instance, t.State));

            var edgeBetweenVertices1And2 = fakeMediator.GetEdgeIncidentToBothVertices(1, 2);
            var fakeEdgeBetweenVertices1And2 = new FakeEdgeNodeStateContext(edgeBetweenVertices1And2);
            // Check vertices to be diligent
            var shouldBeVertices1And2 = fakeEdgeBetweenVertices1And2.GetIncidentVertices(fakeMediator);
            var fakeVertices1And2 = shouldBeVertices1And2.Select(t => new FakeVertexNodeStateContext(t)).ToList();
            var containsVertex1 = fakeVertices1And2.Any(t => t.Position.Equals(1));
            var containsVertex2 = fakeVertices1And2.Any(t => t.Position.Equals(2));
            var countEquals2 = fakeVertices1And2.Count.Equals(2); // These should be the only vertices returned by the edgeNodeStateContext.
            Assert.AreEqual(true, containsVertex1, "containsVertex1");
            Assert.AreEqual(true, containsVertex2, "containsVertex2");
            Assert.AreEqual(true, countEquals2, "countEquals2");
            var fakeVertex1Again = fakeVertices1And2.FirstOrDefault(t => t.Position.Equals(1));
            Assert.NotNull(fakeVertex1Again, "fakeVertex1Again");

            fakeVertex1Again.ChooseAsOrigin(); // The issue is that changing the fake vertex node is not updating the mediator. 
            vertex1.ChooseAsOrigin(); // State changes must occur on the actual object!
            var incidentVertices = fakeEdgeBetweenVertices1And2.GetIncidentVertices(fakeMediator);
            var fakeOriginVertices = fakeEdgeBetweenVertices1And2.GetIncidentVerticesWithSpecifiedState(fakeMediator,
                OriginChosenVertexNodeState.Instance).ToList();
            var containsOrigin = fakeOriginVertices.Any(t => t.State.Equals(OriginChosenVertexNodeState.Instance));
            Assert.AreEqual(1, fakeOriginVertices.Count, "fakeOriginVertices.Count == 1");
            Assert.AreEqual(true, containsOrigin, "containsOrigin");
            var originVertex = fakeOriginVertices.FirstOrDefault();
            Assert.NotNull(originVertex, "originVertex != null");
            var fakeOriginVertex = new FakeVertexNodeStateContext(originVertex);
            //fakeMediator.AddVertices(1, new int[] { 2, 5, 14 });
            fakeMediator.AddVertices(2, new int[] { 1, 12, 3 });
            var edgesList2 = fakeMediator.EdgeNodeStateContexts; // There should be 5 edges here: : <1,2>, <1,5>, <1,14>; <2,12>, <2,3>. (<1,2> = <2,1>).
            Assert.AreEqual(5, edgesList2.Count, "edgesList2 should have 5 edges.");
            var verticesList2 = fakeMediator.VertexNodeStateContexts; // There should be 6 vertices here: 1,2,5,14,3,12
            fakeMediator.AddVertices(5, new int[] { 4, 6, 1 });
            fakeMediator.AddVertices(14, new int[] { 13, 1, 15 });

            // It appears that the edge in edgesList2 IS getting its state updated.
            
            var incidentEdgeContexts = fakeOriginVertex.GetIncidentEdgeNodeStateContexts(fakeMediator); // fakeOriginVertex.GetIncidentEdgeNodeStateContexts(fakeMediator);
            Assert.AreEqual(3, incidentEdgeContexts.Count, "incidentEdgeContexts.Count == 3"); // One vertex cannot be incident to three of the same edge!
            var distinctContexts = incidentEdgeContexts.Distinct().ToList();
            Assert.AreEqual(3, distinctContexts.Count, "distinctContexts.Count == 3"); 
            var unchosenEdges = fakeOriginVertex.GetIncidentUnchosenEdgeNodeStateContexts(fakeMediator).ToList();
            Assert.AreEqual(3, unchosenEdges.Count, "unchosenEdges.Count == 3");
            var actualEdge = fakeMediator.GetEdgeNodeStateContextByPosition(fakeEdgeBetweenVertices1And2.Position);
            Assert.NotNull(actualEdge, "actualEdge != null");
            actualEdge.ChooseAsMale(); // state change must affect actual object. But why does this not work?
            edgeBetweenVertices1And2.ChooseAsMale(); // hopefully this will work.
            fakeEdgeBetweenVertices1And2.ChooseAsMale(); // also doesn't update
            var edges = fakeMediator.EdgeNodeStateContexts;
            var vertices = fakeMediator.VertexNodeStateContexts;
            var test1 = fakeVertex1.GetIncidentUnchosenEdgeNodeStateContexts(fakeMediator).ToList(); // Does the fakeVertex make a difference?
            unchosenEdges = fakeOriginVertex.GetIncidentUnchosenEdgeNodeStateContexts(fakeMediator).ToList(); // Are we constructing new contexts here?
            //var actualUnchosenEdges = fakeOriginVertex.Get(m)
            Assert.AreEqual(2, unchosenEdges.Count, "unchosenEdges.Count == 2");

            fakeOriginVertex.CutRemainingUnchosenEdges(fakeMediator); // Will this method still work?
            var cutEdges = fakeOriginVertex.GetIncidentEdgeNodeStateContextsWithMatchingState(fakeMediator, CutEdgeNodeState.Instance);
            Assert.AreEqual(2, cutEdges.Count, "cutEdges.Count == 2");
            var remainingUncutEdges = fakeOriginVertex.GetIncidentEdgeNodeStateContextsWhereStateIsNotCut(fakeMediator);
            Assert.AreEqual(1, remainingUncutEdges.Count, "remainingUncutEdges.Count == 1");

        }
        [Test]
        public void EdgeNodeStateContext_StateChangesToIncidentEdgesAndVerticesWorkAsExpected_ReturnsExpectedStates()
        {
            var fakeMediator = new FakeNodeStateContextMediator();
            fakeMediator.AddVertices(1, new int[] { 2, 5, 14 });
            var edgesList1 = fakeMediator.EdgeNodeStateContexts; // There should be 3 edges here: <1,2>, <1,5>, <1,14>
            Assert.AreEqual(3, edgesList1.Count, "edgesList1 should have 3 vertices");
            var verticesList1 = fakeMediator.VertexNodeStateContexts; // There should be 4 vertices here: 1,2,5,14
            var vertex2 = fakeMediator.GetVertexNodeStateContextByPosition(2);
            var vertex1 = fakeMediator.GetVertexNodeStateContextByPosition(1);
            var isVertex1InMatrix = fakeMediator.IsVertexInMatrix(1);
            Assert.AreEqual(true, isVertex1InMatrix, "isVertex1InMatrix");
            Assert.NotNull(vertex2, "vertex2 != null");
            Assert.NotNull(vertex1, "vertex1 != null");
            Assert.AreEqual(1, vertex1.Position, "vertex1.Position == 1");
            Assert.AreEqual(UnchosenVertexNodeState.Instance, vertex1.State);
            var fakeVertex1 = new FakeVertexNodeStateContext(vertex1);
            Assert.AreEqual(UnchosenVertexNodeState.Instance, fakeVertex1.State, "fakeVertex1.State");

            var incidentUnchosenEdges = fakeVertex1.GetIncidentEdgeNodeStateContexts(fakeMediator).Select(t => new FakeEdgeNodeStateContext(t)).ToList();
            incidentUnchosenEdges.ForEach(t => Assert.AreEqual(UnchosenEdgeNodeState.Instance, t.State));

            var edgeBetweenVertices1And2 = fakeMediator.GetEdgeIncidentToBothVertices(1, 2);
            var fakeEdgeBetweenVertices1And2 = new FakeEdgeNodeStateContext(edgeBetweenVertices1And2);
            // Check vertices to be diligent
            var shouldBeVertices1And2 = fakeEdgeBetweenVertices1And2.GetIncidentVertices(fakeMediator);
            var fakeVertices1And2 = shouldBeVertices1And2.Select(t => new FakeVertexNodeStateContext(t)).ToList();
            var containsVertex1 = fakeVertices1And2.Any(t => t.Position.Equals(1));
            var containsVertex2 = fakeVertices1And2.Any(t => t.Position.Equals(2));
            var countEquals2 = fakeVertices1And2.Count.Equals(2); // These should be the only vertices returned by the edgeNodeStateContext.
            Assert.AreEqual(true, containsVertex1, "containsVertex1");
            Assert.AreEqual(true, containsVertex2, "containsVertex2");
            Assert.AreEqual(true, countEquals2, "countEquals2");
            var fakeVertex1Again = fakeVertices1And2.FirstOrDefault(t => t.Position.Equals(1));
            Assert.NotNull(fakeVertex1Again, "fakeVertex1Again");

            fakeVertex1Again.ChooseAsOrigin(); // The issue is that changing the fake vertex node is not updating the mediator. 
            vertex1.ChooseAsOrigin(); // State changes must occur on the actual object!
            var incidentVertices = fakeEdgeBetweenVertices1And2.GetIncidentVertices(fakeMediator);
            var fakeOriginVertices = fakeEdgeBetweenVertices1And2.GetIncidentVerticesWithSpecifiedState(fakeMediator,
                OriginChosenVertexNodeState.Instance).ToList();
            var containsOrigin = fakeOriginVertices.Any(t => t.State.Equals(OriginChosenVertexNodeState.Instance));
            Assert.AreEqual(1, fakeOriginVertices.Count, "fakeOriginVertices.Count == 1");
            Assert.AreEqual(true, containsOrigin, "containsOrigin");
            var originVertex = fakeOriginVertices.FirstOrDefault();
            Assert.NotNull(originVertex, "originVertex != null");
            var fakeOriginVertex = new FakeVertexNodeStateContext(originVertex);
            //fakeMediator.AddVertices(1, new int[] { 2, 5, 14 });
            fakeMediator.AddVertices(2, new int[] { 1, 12, 3 });
            var edgesList2 = fakeMediator.EdgeNodeStateContexts; // There should be 5 edges here: : <1,2>, <1,5>, <1,14>; <2,12>, <2,3>. (<1,2> = <2,1>).
            Assert.AreEqual(5, edgesList2.Count, "edgesList2 should have 5 edges.");
            var verticesList2 = fakeMediator.VertexNodeStateContexts; // There should be 6 vertices here: 1,2,5,14,3,12
            fakeMediator.AddVertices(5, new int[] { 4, 6, 1 });
            fakeMediator.AddVertices(14, new int[] { 13, 1, 15 });

            // It appears that the edge in edgesList2 IS getting its state updated.

            var incidentEdgeContexts = fakeOriginVertex.GetIncidentEdgeNodeStateContexts(fakeMediator); // fakeOriginVertex.GetIncidentEdgeNodeStateContexts(fakeMediator);
            Assert.AreEqual(3, incidentEdgeContexts.Count, "incidentEdgeContexts.Count == 3"); // One vertex cannot be incident to three of the same edge!
            var distinctContexts = incidentEdgeContexts.Distinct().ToList();
            Assert.AreEqual(3, distinctContexts.Count, "distinctContexts.Count == 3");
            var unchosenEdges = fakeOriginVertex.GetIncidentUnchosenEdgeNodeStateContexts(fakeMediator).ToList();
            Assert.AreEqual(3, unchosenEdges.Count, "unchosenEdges.Count == 3");
            var actualEdge = fakeMediator.GetEdgeNodeStateContextByPosition(fakeEdgeBetweenVertices1And2.Position);
            Assert.NotNull(actualEdge, "actualEdge != null");
            actualEdge.ChooseAsMale(); // state change must affect actual object. But why does this not work?
            edgeBetweenVertices1And2.ChooseAsMale(); // hopefully this will work.
            fakeEdgeBetweenVertices1And2.ChooseAsMale(); // also doesn't update
            var maleEdges = fakeMediator.GetEdgeNodesWithStateChosenMale;
            Assert.AreEqual(1, maleEdges.Count(), "maleEdges.Count() == 1");
            
            var edges = fakeMediator.EdgeNodeStateContexts;
            var vertices = fakeMediator.VertexNodeStateContexts;
            var test1 = fakeVertex1.GetIncidentUnchosenEdgeNodeStateContexts(fakeMediator).ToList(); // Does the fakeVertex make a difference?
            unchosenEdges = fakeOriginVertex.GetIncidentUnchosenEdgeNodeStateContexts(fakeMediator).ToList(); // Are we constructing new contexts here?
            //var actualUnchosenEdges = fakeOriginVertex.Get(m)
            Assert.AreEqual(2, unchosenEdges.Count, "unchosenEdges.Count == 2");

            fakeOriginVertex.CutRemainingUnchosenEdges(fakeMediator); // Will this method still work?
            var cutEdges = fakeOriginVertex.GetIncidentEdgeNodeStateContextsWithMatchingState(fakeMediator, CutEdgeNodeState.Instance);
            Assert.AreEqual(2, cutEdges.Count, "cutEdges.Count == 2");
            var remainingUncutEdges = fakeOriginVertex.GetIncidentEdgeNodeStateContextsWhereStateIsNotCut(fakeMediator);
            Assert.AreEqual(1, remainingUncutEdges.Count, "remainingUncutEdges.Count == 1");
            
            vertex2.ChooseAsFemale();
            
            var femaleVertices = fakeMediator.GetVertexNodesWithStateChosenFemale;
            Assert.AreEqual(1, femaleVertices.Count(), "femaleVertices.Count() == 1");

        }
        [Test]
        public void VertexNodeStateContext_GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone_ReturnsExpectedList()
        {
            var mediator = new FakeNodeStateContextMediator();
            mediator.AddVertices(1, new int[] { 2, 5, 14 });
            mediator.AddVertices(2, new int[] { 1, 12, 3 });
            mediator.AddVertices(3, new int[] { 2, 9, 4 });
            mediator.AddVertices(4, new int[] { 3, 8, 5 });
            mediator.AddVertices(5, new int[] { 4, 6, 1 });
            mediator.AddVertices(6, new int[] { 7, 15, 5 });
            mediator.AddVertices(7, new int[] { 8, 17, 6 });
            mediator.AddVertices(8, new int[] { 10, 4, 7 });
            mediator.AddVertices(9, new int[] { 11, 3, 10 });
            mediator.AddVertices(10, new int[] { 8, 9, 18 });
            mediator.AddVertices(11, new int[] { 9, 12, 19 });
            mediator.AddVertices(12, new int[] { 2, 11, 13 });
            mediator.AddVertices(13, new int[] { 12, 14, 20 });
            mediator.AddVertices(14, new int[] { 13, 1, 15 });
            mediator.AddVertices(15, new int[] { 6, 14, 16 });
            mediator.AddVertices(16, new int[] { 15, 20, 17 });
            mediator.AddVertices(17, new int[] { 7, 16, 18 });
            mediator.AddVertices(18, new int[] { 17, 19, 10 });
            mediator.AddVertices(19, new int[] { 18, 20, 11 });
            mediator.AddVertices(20, new int[] { 13, 16, 19 });

            // Let's say I start by choosing vertex 5 (as origin) and the edge from 5-1 (as male). (Then I have chosen vertex 1 as male.)
            // If I cut the edge from 6-7, then choosing the edge from 5-4 (as female) would induce a cut to edge 5-6, which would orphan vertex 6. 
            //      (6 would then only have edge 6-15.) 
            var vertex5 = mediator.GetVertexNodeStateContextByPosition(5);
            vertex5.ChooseAsOrigin();
            var fakeVertex5 = new FakeVertexNodeStateContext(vertex5);
            var edgeIncidentTo5 = fakeVertex5.GetIncidentEdgeNodeStateContexts(mediator).ToList();
            Assert.AreEqual(3, edgeIncidentTo5.Count, "edgeIncidentTo5.Count == 3");
            var edge51 = mediator.GetEdgeIncidentToBothVertices(5, 1);
            Assert.NotNull(edge51, "edge51 != null");
            edge51.ChooseAsMale();
            Assert.AreEqual(MaleChosenEdgeNodeState.Instance, edge51.State, "edge51.State.Equals(MaleChosenEdgeNodeState.Instance)");
            var vertex1 = mediator.GetVertexNodeStateContextByPosition(1);
            Assert.NotNull(vertex1, "vertex1 != null");
            vertex1.ChooseAsMale();
            Assert.AreEqual(MaleChosenVertexNodeState.Instance, vertex1.State, "vertex1.State.Equals(MaleChosenVertexNodeState.Instance)");
            var edge67 = mediator.GetEdgeIncidentToBothVertices(6, 7);
            Assert.NotNull(edge67, "edge67 != null");
            edge67.Cut();
            Assert.AreEqual(CutEdgeNodeState.Instance, edge67.State, "edge67.State.Equals(CutEdgeNodeState.Instance)");
            var edge54 = mediator.GetEdgeIncidentToBothVertices(5, 4);
            Assert.NotNull(edge54, "edge54 != null");
            edge54.ChooseAsFemale();
            Assert.AreEqual(FemaleChosenEdgeNodeState.Instance, edge54.State, "edge54.State.Equals(FemaleChosenEdgeNodeState.Instance)");
            var edge56 = mediator.GetEdgeIncidentToBothVertices(5, 6);
            
            var vertex6 = mediator.GetVertexNodeStateContextByPosition(6);
            var vertex6IncidentUncutEdges = vertex6.GetIncidentUncutEdges(mediator);
            Assert.Contains(edge56, vertex6IncidentUncutEdges.ToList(), "vertex6IncidentUncutEdges.ToList() contains edge56");

            var edgesThatCutWouldOrphan =
                vertex5.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(mediator);
            Assert.Contains(edge56, edgesThatCutWouldOrphan.ToList(), "vertex5.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(mediator).ToList() contains edge56");
            var wouldCutOrphanVertex1 = vertex6.WouldCutOrphanVertex(mediator);
            Assert.AreEqual(true, wouldCutOrphanVertex1, "wouldCutOrphanVertex1 == true");
            fakeVertex5.CutRemainingUnchosenEdges(mediator);
            
            Assert.NotNull(edge56, "edge56 != null");
            Assert.AreEqual(CutEdgeNodeState.Instance, edge56.State, "edge56.State.Equals(CutEdgeNodeState.Instance)");

            Assert.AreEqual(MaleChosenEdgeNodeState.Instance, edge51.State, "edge51.State.Equals(MaleChosenEdgeNodeState.Instance)"); // Should still be same.
            Assert.AreEqual(FemaleChosenEdgeNodeState.Instance, edge54.State, "edge54.State.Equals(FemaleChosenEdgeNodeState.Instance)"); // Should still be same.

            
            

            //var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
            //visitor.Visit(mediator, 5);

        }

        [Test]
        public void NodeStateContextMediator_Copy_MethodReturnsExpectedObject()
        {
            var mediator = new FakeNodeStateContextMediator();
            mediator.AddVertices(1, new int[] { 2, 5, 14 });
            mediator.AddVertices(2, new int[] { 1, 12, 3 });
            mediator.AddVertices(3, new int[] { 2, 9, 4 });
            mediator.AddVertices(4, new int[] { 3, 8, 5 });
            mediator.AddVertices(5, new int[] { 4, 6, 1 });
            mediator.AddVertices(6, new int[] { 7, 15, 5 });
            mediator.AddVertices(7, new int[] { 8, 17, 6 });
            mediator.AddVertices(8, new int[] { 10, 4, 7 });
            mediator.AddVertices(9, new int[] { 11, 3, 10 });
            mediator.AddVertices(10, new int[] { 8, 9, 18 });
            mediator.AddVertices(11, new int[] { 9, 12, 19 });
            mediator.AddVertices(12, new int[] { 2, 11, 13 });
            mediator.AddVertices(13, new int[] { 12, 14, 20 });
            mediator.AddVertices(14, new int[] { 13, 1, 15 });
            mediator.AddVertices(15, new int[] { 6, 14, 16 });
            mediator.AddVertices(16, new int[] { 15, 20, 17 });
            mediator.AddVertices(17, new int[] { 7, 16, 18 });
            mediator.AddVertices(18, new int[] { 17, 19, 10 });
            mediator.AddVertices(19, new int[] { 18, 20, 11 });
            mediator.AddVertices(20, new int[] { 13, 16, 19 });
            var edgeNodeStateFactory = EdgeNodeStateContextFlyweightFactory<FakeEdgeNodeStateContext>.GetInstance;
            var vertexNodeStateFactory =
                VertexNodeStateContextFlyweightFactory<FakeVertexNodeStateContext>.GetInstance;
                var facadeFactory = new NodeStateContextContainerFacadeFlyweightFactory<FakeEdgeNodeStateContext,FakeVertexNodeStateContext>(edgeNodeStateFactory, vertexNodeStateFactory);
            var mediatorCopy = mediator.Copy(facadeFactory);

            var fakeEdge1 = mediatorCopy.GetEdgeNodeStateContextByPosition(1);
            var fakeEdge2 = mediatorCopy.GetEdgeNodeStateContextByPosition(2);
            var fakeEdge3 = mediatorCopy.GetEdgeNodeStateContextByPosition(3);
            var fakeEdge4 = mediatorCopy.GetEdgeNodeStateContextByPosition(4);
            var fakeEdge5 = mediatorCopy.GetEdgeNodeStateContextByPosition(5);
            var fakeEdge6 = mediatorCopy.GetEdgeNodeStateContextByPosition(6);
            var fakeEdge7 = mediatorCopy.GetEdgeNodeStateContextByPosition(7);
            var fakeEdge8 = mediatorCopy.GetEdgeNodeStateContextByPosition(8);
            var fakeEdge9 = mediatorCopy.GetEdgeNodeStateContextByPosition(9);
            var fakeEdge10 = mediatorCopy.GetEdgeNodeStateContextByPosition(10);
            var fakeEdge11 = mediatorCopy.GetEdgeNodeStateContextByPosition(11);
            var fakeEdge12 = mediatorCopy.GetEdgeNodeStateContextByPosition(12);
            var fakeEdge13 = mediatorCopy.GetEdgeNodeStateContextByPosition(13);
            var fakeEdge14 = mediatorCopy.GetEdgeNodeStateContextByPosition(14);
            var fakeEdge15 = mediatorCopy.GetEdgeNodeStateContextByPosition(15);
            var fakeEdge16 = mediatorCopy.GetEdgeNodeStateContextByPosition(16);
            var fakeEdge17 = mediatorCopy.GetEdgeNodeStateContextByPosition(17);
            var fakeEdge18 = mediatorCopy.GetEdgeNodeStateContextByPosition(18);
            var fakeEdge19 = mediatorCopy.GetEdgeNodeStateContextByPosition(19);
            var fakeEdge20 = mediatorCopy.GetEdgeNodeStateContextByPosition(20);
            var fakeEdge21 = mediatorCopy.GetEdgeNodeStateContextByPosition(21);
            var fakeEdge22 = mediatorCopy.GetEdgeNodeStateContextByPosition(22);
            var fakeEdge23 = mediatorCopy.GetEdgeNodeStateContextByPosition(23);
            var fakeEdge24 = mediatorCopy.GetEdgeNodeStateContextByPosition(24);
            var fakeEdge25 = mediatorCopy.GetEdgeNodeStateContextByPosition(25);
            var fakeEdge26 = mediatorCopy.GetEdgeNodeStateContextByPosition(26);
            var fakeEdge27 = mediatorCopy.GetEdgeNodeStateContextByPosition(27);
            var fakeEdge28 = mediatorCopy.GetEdgeNodeStateContextByPosition(28);
            var fakeEdge29 = mediatorCopy.GetEdgeNodeStateContextByPosition(29);
            var fakeEdge30 = mediatorCopy.GetEdgeNodeStateContextByPosition(30);
            var firstFakeEdge1IncidentVertex =
                fakeEdge1.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstFakeEdge3IncidentVertex =
                fakeEdge3.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstFakeEdge7IncidentVertex =
                fakeEdge7.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstFakeEdge11IncidentVertex =
                fakeEdge11.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstFakeEdge14IncidentVertex =
                fakeEdge14.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstFakeEdge19IncidentVertex =
                fakeEdge19.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstFakeEdge19IncidentSecondVertex =
                fakeEdge19.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).Skip(1).FirstOrDefault(); 

            var edge1 = mediator.GetEdgeNodeStateContextByPosition(1);
            var edge2 = mediator.GetEdgeNodeStateContextByPosition(2);
            var edge3 = mediator.GetEdgeNodeStateContextByPosition(3);
            var edge4 = mediator.GetEdgeNodeStateContextByPosition(4);
            var edge5 = mediator.GetEdgeNodeStateContextByPosition(5);
            var edge6 = mediator.GetEdgeNodeStateContextByPosition(6);
            var edge7 = mediator.GetEdgeNodeStateContextByPosition(7);
            var edge8 = mediator.GetEdgeNodeStateContextByPosition(8);
            var edge9 = mediator.GetEdgeNodeStateContextByPosition(9);
            var edge10 = mediator.GetEdgeNodeStateContextByPosition(10);
            var edge11 = mediator.GetEdgeNodeStateContextByPosition(11);
            var edge12 = mediator.GetEdgeNodeStateContextByPosition(12);
            var edge13 = mediator.GetEdgeNodeStateContextByPosition(13);
            var edge14 = mediator.GetEdgeNodeStateContextByPosition(14);
            var edge15 = mediator.GetEdgeNodeStateContextByPosition(15);
            var edge16 = mediator.GetEdgeNodeStateContextByPosition(16);
            var edge17 = mediator.GetEdgeNodeStateContextByPosition(17);
            var edge18 = mediator.GetEdgeNodeStateContextByPosition(18);
            var edge19 = mediator.GetEdgeNodeStateContextByPosition(19);
            var edge20 = mediator.GetEdgeNodeStateContextByPosition(20);
            var edge21 = mediator.GetEdgeNodeStateContextByPosition(21);
            var edge22 = mediator.GetEdgeNodeStateContextByPosition(22);
            var edge23 = mediator.GetEdgeNodeStateContextByPosition(23);
            var edge24 = mediator.GetEdgeNodeStateContextByPosition(24);
            var edge25 = mediator.GetEdgeNodeStateContextByPosition(25);
            var edge26 = mediator.GetEdgeNodeStateContextByPosition(26);
            var edge27 = mediator.GetEdgeNodeStateContextByPosition(27);
            var edge28 = mediator.GetEdgeNodeStateContextByPosition(28);
            var edge29 = mediator.GetEdgeNodeStateContextByPosition(29);
            var edge30 = mediator.GetEdgeNodeStateContextByPosition(30);
            var firstEdge1IncidentVertex =
                edge1.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstEdge3IncidentVertex =
                edge3.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstEdge7IncidentVertex =
                edge7.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstEdge11IncidentVertex =
                edge11.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstEdge14IncidentVertex =
                edge14.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();
            var firstEdge19IncidentVertex =
                edge19.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).FirstOrDefault();

            var firstEdge19IncidentSecondVertex = edge19.GetIncidentVertices(mediatorCopy).OrderBy(t => t.Position).Skip(1).FirstOrDefault(); 


            Assert.AreEqual(firstFakeEdge1IncidentVertex.Position, firstEdge1IncidentVertex.Position);
            Assert.AreEqual(firstFakeEdge3IncidentVertex.Position, firstEdge3IncidentVertex.Position);
            Assert.AreEqual(firstFakeEdge7IncidentVertex.Position, firstEdge7IncidentVertex.Position);
            Assert.AreEqual(firstFakeEdge11IncidentVertex.Position, firstEdge11IncidentVertex.Position);
            Assert.AreEqual(firstFakeEdge14IncidentVertex.Position, firstEdge14IncidentVertex.Position);
            Assert.AreEqual(firstFakeEdge19IncidentVertex.Position, firstEdge19IncidentVertex.Position);
            Assert.AreEqual(firstEdge19IncidentSecondVertex.Position, firstFakeEdge19IncidentSecondVertex.Position);
        }
        [Test]
        public void IncidenceProvider_FastestGetIncidentVertices_ReturnsFastestMethod()
        {
            var mediator1 = new FakeNodeStateContextMediator();
            var mediator2 = new FakeConcurrentNodeStateContextMediator();
            mediator1.AddVertices(1, new int[] { 2, 5, 14 });
            mediator1.AddVertices(2, new int[] { 1, 12, 3 });
            mediator1.AddVertices(3, new int[] { 2, 9, 4 });
            mediator1.AddVertices(4, new int[] { 3, 8, 5 });
            mediator1.AddVertices(5, new int[] { 4, 6, 1 });
            mediator1.AddVertices(6, new int[] { 7, 15, 5 });
            mediator1.AddVertices(7, new int[] { 8, 17, 6 });
            mediator1.AddVertices(8, new int[] { 10, 4, 7 });
            mediator1.AddVertices(9, new int[] { 11, 3, 10 });
            mediator1.AddVertices(10, new int[] { 8, 9, 18 });
            mediator1.AddVertices(11, new int[] { 9, 12, 19 });
            mediator1.AddVertices(12, new int[] { 2, 11, 13 });
            mediator1.AddVertices(13, new int[] { 12, 14, 20 });
            mediator1.AddVertices(14, new int[] { 13, 1, 15 });
            mediator1.AddVertices(15, new int[] { 6, 14, 16 });
            mediator1.AddVertices(16, new int[] { 15, 20, 17 });
            mediator1.AddVertices(17, new int[] { 7, 16, 18 });
            mediator1.AddVertices(18, new int[] { 17, 19, 10 });
            mediator1.AddVertices(19, new int[] { 18, 20, 11 });
            mediator1.AddVertices(20, new int[] { 13, 16, 19 });

            mediator2.AddVertices(1, new int[] { 2, 5, 14 });
            mediator2.AddVertices(2, new int[] { 1, 12, 3 });
            mediator2.AddVertices(3, new int[] { 2, 9, 4 });
            mediator2.AddVertices(4, new int[] { 3, 8, 5 });
            mediator2.AddVertices(5, new int[] { 4, 6, 1 });
            mediator2.AddVertices(6, new int[] { 7, 15, 5 });
            mediator2.AddVertices(7, new int[] { 8, 17, 6 });
            mediator2.AddVertices(8, new int[] { 10, 4, 7 });
            mediator2.AddVertices(9, new int[] { 11, 3, 10 });
            mediator2.AddVertices(10, new int[] { 8, 9, 18 });
            mediator2.AddVertices(11, new int[] { 9, 12, 19 });
            mediator2.AddVertices(12, new int[] { 2, 11, 13 });
            mediator2.AddVertices(13, new int[] { 12, 14, 20 });
            mediator2.AddVertices(14, new int[] { 13, 1, 15 });
            mediator2.AddVertices(15, new int[] { 6, 14, 16 });
            mediator2.AddVertices(16, new int[] { 15, 20, 17 });
            mediator2.AddVertices(17, new int[] { 7, 16, 18 });
            mediator2.AddVertices(18, new int[] { 17, 19, 10 });
            mediator2.AddVertices(19, new int[] { 18, 20, 11 });
            mediator2.AddVertices(20, new int[] { 13, 16, 19 });


            var time1 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int j = 0; j < 10000; j++)
                {
                    Parallel.For(0, 20, i =>
                    {

                        var incidentVertices = mediator1.GetIncidentVertices(i);

                    });
                }

            });
            var time2 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int j = 0; j < 10000; j++)
                {
                    Parallel.For(0, 20, i =>
                    {

                        var incidentVertices = mediator2.GetIncidentVertices1(i);
                    });
                }
            });
            var time3 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int j = 0; j < 10000; j++)
                {
                    Parallel.For(0, 20, i =>
                    {
                        var incidentVertices = mediator2.GetIncidentVertices2(i);
                    });

                }
            });
            var time4 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int j = 0; j < 10000; j++)
                {
                    
                    Parallel.For(0, 20, i =>
                    {
                        var incidentVertices = mediator2.GetIncidentVertices3(i);
                    });
                }
            });
            var time5 = PerformanceAnalysisUtility.Time(() =>
            {
                for (int j = 0; j < 10000; j++)
                {

                    Parallel.For(0, 20, i =>
                    {
                        var incidentVertices = mediator2.GetIncidentVertices4(i);
                    });
                }
            });
            
            //visitor.Visit(mediator, 5);
            Console.WriteLine("Total miliseconds of time1: " + time1.TotalMilliseconds);
            Console.WriteLine("Total miliseconds of time2: " + time2.TotalMilliseconds);
            Console.WriteLine("Total miliseconds of time3: " + time3.TotalMilliseconds);
            Console.WriteLine("Total miliseconds of time4: " + time4.TotalMilliseconds);
            Console.WriteLine("Total miliseconds of time5: " + time5.TotalMilliseconds);
            //Total miliseconds of time1: 232.3971
            //Total miliseconds of time2: 365.1717
            //Total miliseconds of time3: 184.4352

            //Total miliseconds of time1: 240.5372
            //Total miliseconds of time2: 240.9687
            //Total miliseconds of time3: 206.8911
            //Total miliseconds of time4: 219.8956

            // Total miliseconds of time1: 71.0799 // This time is with the new GetIncidentVertexCache and GetIncidentEdgeCache.
            //Total miliseconds of time1: 70.5414
            //Total miliseconds of time2: 79.5508
            //Total miliseconds of time3: 75.3464
            //Total miliseconds of time4: 96.2253
            //Total miliseconds of time5: 54.939

        }

        [Test]
        public void VertexNodeStateContextFlyweightFactory_FactoriesAreLegitimateSingletons_ReturnsSameObjects()
        {
            var factory1 = VertexNodeStateContextFlyweightFactory<VertexNodeStateContext>.GetInstance;
            var factory2 = VertexNodeStateContextFlyweightFactory<VertexNodeStateContext>.GetInstance;
            Assert.AreSame(factory1,factory2);
        }
        [Test]
        public void VertexNodeVisitor_DoesVisitMethodWork_ReturnsTrue()
        {
            var mediator = new FakeNodeStateContextMediator();
            mediator.AddVertices(1, new int[] { 2, 5, 14 });
            mediator.AddVertices(2, new int[] { 1, 12, 3 });
            mediator.AddVertices(3, new int[] { 2, 9, 4 });
            mediator.AddVertices(4, new int[] { 3, 8, 5 });
            mediator.AddVertices(5, new int[] { 4, 6, 1 });
            mediator.AddVertices(6, new int[] { 7, 15, 5 });
            mediator.AddVertices(7, new int[] { 8, 17, 6 });
            mediator.AddVertices(8, new int[] { 10, 4, 7 });
            mediator.AddVertices(9, new int[] { 11, 3, 10 });
            mediator.AddVertices(10, new int[] { 8, 9, 18 });
            mediator.AddVertices(11, new int[] { 9, 12, 19 });
            mediator.AddVertices(12, new int[] { 2, 11, 13 });
            mediator.AddVertices(13, new int[] { 12, 14, 20 });
            mediator.AddVertices(14, new int[] { 13, 1, 15 });
            mediator.AddVertices(15, new int[] { 6, 14, 16 });
            mediator.AddVertices(16, new int[] { 15, 20, 17 });
            mediator.AddVertices(17, new int[] { 7, 16, 18 });
            mediator.AddVertices(18, new int[] { 17, 19, 10 });
            mediator.AddVertices(19, new int[] { 18, 20, 11 });
            mediator.AddVertices(20, new int[] { 13, 16, 19 });

            var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
            var time1 = PerformanceAnalysisUtility.Time(() =>
            {
                visitor.Visit(mediator, 5);
            });
            //visitor.Visit(mediator, 5);
            Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
            Console.WriteLine("Total seconds: " + time1.TotalSeconds);
            // Total miliseconds: 196.4314
            // Total miliseconds: 179.3093
            // Total miliseconds: 159.4048
            // Total miliseconds: 154.6347
            // Total miliseconds: 152.4727
        }
        

        [Test]
        public void SatVertexNodeFactory_DoesSatNodeValuePersistInStorage_ReturnsSatVertexNodeWithExpectedPropertyValues()
        {
            var factory = SatVertexNodeFactory.GetFactory();
            var position = 4;
            var value = 3;
            var clause = 2;
            var vertex = factory.ConstructNode(nodePosition: position, nodeValue: value, nodeClause: clause);

            Assert.AreEqual(position, vertex.Position);
            Assert.AreEqual(value, vertex.Value);
            Assert.AreEqual(clause, vertex.Clause);

            var retrievedNode = factory.Values[position];

            Assert.AreEqual(position, retrievedNode.Position);
            Assert.AreEqual(value, retrievedNode.Value);
            Assert.AreEqual(clause, retrievedNode.Clause);
        }

        [Test]
        public void
            SatVertexNodeStateContextFactory_DoesSatNodeStateContextValuePersistInStorage_ReturnsSatVertexNodeStateContextWithExpectedPropertyValues
            ()
        {
            var factory = SatVertexNodeFactory.GetFactory();
            var position = 4;
            var value = 3;
            var clause = 2;
            var vertex = factory.ConstructNode(nodePosition: position, nodeValue: value, nodeClause: clause);

            var contextFactory = new VertexNodeStateContextFactory<SatVertexNodeStateContext>();
            var nodeContext = contextFactory.ConstructNodeContext(nodePosition: position, nodeState: UnchosenVertexNodeState.Instance,
                nodeFactory: factory);
            //nodeContext.;
        }

        [Test]
        public void Hashset_DoesIntersectionWorkAsExpected_ReturnsExpectedValuesAsIntegers()
        {
            var set1 = new HashSet<int>() {1, 2, 3, 4, 5, 6, 7};
            var set2 = new HashSet<int>() {3, 4, 5, 6, 7, 8, 9};
            var set3 = set1.Intersect(set2).ToList();
            Assert.Contains(3, set3);
            Assert.Contains(4, set3);
            Assert.Contains(5, set3);
            Assert.Contains(6, set3);
            Assert.Contains(7, set3);
            Assert.AreEqual(5, set3.Count);
        }

        [Test]
        public void ComputingEdgeHashsets_DoesEdgeIntersectionMethodReturnCorrectValues_ReturnsExpectedHashset()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5 });
            mediator.AddVertices(2, new int[] { 41, 3 });
            mediator.AddVertices(3, new int[] { 2, 49 });
            mediator.AddVertices(4, new int[] { 8, 5 });
            mediator.AddVertices(5, new int[] { 44, 6 });
            mediator.AddVertices(6, new int[] { 7, 15 });
            mediator.AddVertices(7, new int[] { 8, 17 });
            mediator.AddVertices(8, new int[] { 10, 4 });
            mediator.AddVertices(9, new int[] { 11, 10 });
            mediator.AddVertices(10, new int[] { 8, 9 });
            mediator.AddVertices(11, new int[] { 9, 12 });
            mediator.AddVertices(12, new int[] { 2, 13 });
            mediator.AddVertices(13, new int[] { 20, 25 });
            mediator.AddVertices(14, new int[] { 1, 24 });
            mediator.AddVertices(15, new int[] { 14, 32 });
            mediator.AddVertices(16, new int[] { 17, 39 });
            mediator.AddVertices(17, new int[] { 7, 18 });
            mediator.AddVertices(18, new int[] { 17, 10 });
            mediator.AddVertices(19, new int[] { 18, 20 });
            mediator.AddVertices(20, new int[] { 13, 19 });
            mediator.AddVertices(21, new int[] { 42, 14 });
            mediator.AddVertices(22, new int[] { 36, 19 });
            mediator.AddVertices(23, new int[] { 37, 32 });
            mediator.AddVertices(24, new int[] { 1, 19 });
            mediator.AddVertices(25, new int[] { 28, 22 });
            mediator.AddVertices(26, new int[] { 3, 35 });
            mediator.AddVertices(27, new int[] { 12, 41 });
            mediator.AddVertices(28, new int[] { 38, 22 });
            mediator.AddVertices(29, new int[] { 19, 27 });
            mediator.AddVertices(30, new int[] { 12, 4 });
            mediator.AddVertices(31, new int[] { 19, 29 });
            mediator.AddVertices(32, new int[] { 5 });
            mediator.AddVertices(33, new int[] { 7 });
            mediator.AddVertices(34, new int[] { 26, 17 });
            mediator.AddVertices(35, new int[] { 9 });
            mediator.AddVertices(36, new int[] { 26, 24 });
            mediator.AddVertices(37, new int[] { 33, 21 });
            mediator.AddVertices(38, new int[] { 12, 15 });
            mediator.AddVertices(39, new int[] { 31, 35 });
            mediator.AddVertices(40, new int[] { 32, 41 });
            mediator.AddVertices(41, new int[] { 29, 36 });
            mediator.AddVertices(42, new int[] { 46 });
            mediator.AddVertices(43, new int[] { 42, 37 });
            mediator.AddVertices(44, new int[] { 26, 17 });
            mediator.AddVertices(45, new int[] { 15, 49 });
            mediator.AddVertices(46, new int[] { 26, 24 });
            mediator.AddVertices(47, new int[] { 33 });
            mediator.AddVertices(48, new int[] { 42, 15 });
            mediator.AddVertices(49, new int[] { 41 });
#endregion

            var desiredEdge1 = mediator.GetEdgeIncidentToBothVertices(6, 7);
            var verticesAsTuple = desiredEdge1.GetIncidentVerticesAsTuple(mediator);
           // var vertex1AdjacencyList = verticesAsTuple.Item1.Get

           Assert.AreEqual(true,false);
        }
        [Test]
        public void UndirectedAdjacencyProvider_TestPerformanceOfGetAdjacentVertexPositions_ReturnsCorrectValues()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5 });
            mediator.AddVertices(2, new int[] { 41, 3 });
            mediator.AddVertices(3, new int[] { 2, 49 });
            mediator.AddVertices(4, new int[] { 8, 5 });
            mediator.AddVertices(5, new int[] { 44, 6 });
            mediator.AddVertices(6, new int[] { 7, 15 });
            mediator.AddVertices(7, new int[] { 8, 17 });
            mediator.AddVertices(8, new int[] { 10, 4 });
            mediator.AddVertices(9, new int[] { 11, 10 });
            mediator.AddVertices(10, new int[] { 8, 9 });
            mediator.AddVertices(11, new int[] { 9, 12 });
            mediator.AddVertices(12, new int[] { 2, 13 });
            mediator.AddVertices(13, new int[] { 20, 25 });
            mediator.AddVertices(14, new int[] { 1, 24 });
            mediator.AddVertices(15, new int[] { 14, 32 });
            mediator.AddVertices(16, new int[] { 17, 39 });
            mediator.AddVertices(17, new int[] { 7, 18 });
            mediator.AddVertices(18, new int[] { 17, 10 });
            mediator.AddVertices(19, new int[] { 18, 20 });
            mediator.AddVertices(20, new int[] { 13, 19 });
            mediator.AddVertices(21, new int[] { 42, 14 });
            mediator.AddVertices(22, new int[] { 36, 19 });
            mediator.AddVertices(23, new int[] { 37, 32 });
            mediator.AddVertices(24, new int[] { 1, 19 });
            mediator.AddVertices(25, new int[] { 28, 22 });
            mediator.AddVertices(26, new int[] { 3, 35 });
            mediator.AddVertices(27, new int[] { 12, 41 });
            mediator.AddVertices(28, new int[] { 38, 22 });
            mediator.AddVertices(29, new int[] { 19, 27 });
            mediator.AddVertices(30, new int[] { 12, 4 });
            mediator.AddVertices(31, new int[] { 19, 29 });
            mediator.AddVertices(32, new int[] { 5 });
            mediator.AddVertices(33, new int[] { 7 });
            mediator.AddVertices(34, new int[] { 26, 17 });
            mediator.AddVertices(35, new int[] { 9 });
            mediator.AddVertices(36, new int[] { 26, 24 });
            mediator.AddVertices(37, new int[] { 33, 21 });
            mediator.AddVertices(38, new int[] { 12, 15 });
            mediator.AddVertices(39, new int[] { 31, 35 });
            mediator.AddVertices(40, new int[] { 32, 41 });
            mediator.AddVertices(41, new int[] { 29, 36 });
            mediator.AddVertices(42, new int[] { 46 });
            mediator.AddVertices(43, new int[] { 42, 37 });
            mediator.AddVertices(44, new int[] { 26, 17 });
            mediator.AddVertices(45, new int[] { 15, 49 });
            mediator.AddVertices(46, new int[] { 26, 24 });
            mediator.AddVertices(47, new int[] { 33 });
            mediator.AddVertices(48, new int[] { 42, 15 });
            mediator.AddVertices(49, new int[] { 41 });
            #endregion
            var time1 = PerformanceAnalysisUtility.Time(() =>
            {
                var vertexPositions1 = mediator.GetAdjacentVertexPositionsInclusive(5);
            });
            var time2 = PerformanceAnalysisUtility.Time(() =>
            {
                var vertexPositions2 = mediator.GetAdjacentVertices(5);
            });
            Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
            Console.WriteLine("Total seconds: " + time1.TotalSeconds);
            Console.WriteLine("Total miliseconds: " + time2.TotalMilliseconds);
            Console.WriteLine("Total seconds: " + time2.TotalSeconds);
            Assert.Less(time1.TotalMilliseconds,time2.TotalMilliseconds);
        }
        [Test]
        public void UndirectedIncidenceProvider_TestPerformanceOfGetIncidenceVertexPositions_ReturnsCorrectValues()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5 });
            mediator.AddVertices(2, new int[] { 41, 3 });
            mediator.AddVertices(3, new int[] { 2, 49 });
            mediator.AddVertices(4, new int[] { 8, 5 });
            mediator.AddVertices(5, new int[] { 44, 6 });
            mediator.AddVertices(6, new int[] { 7, 15 });
            mediator.AddVertices(7, new int[] { 8, 17 });
            mediator.AddVertices(8, new int[] { 10, 4 });
            mediator.AddVertices(9, new int[] { 11, 10 });
            mediator.AddVertices(10, new int[] { 8, 9 });
            mediator.AddVertices(11, new int[] { 9, 12 });
            mediator.AddVertices(12, new int[] { 2, 13 });
            mediator.AddVertices(13, new int[] { 20, 25 });
            mediator.AddVertices(14, new int[] { 1, 24 });
            mediator.AddVertices(15, new int[] { 14, 32 });
            mediator.AddVertices(16, new int[] { 17, 39 });
            mediator.AddVertices(17, new int[] { 7, 18 });
            mediator.AddVertices(18, new int[] { 17, 10 });
            mediator.AddVertices(19, new int[] { 18, 20 });
            mediator.AddVertices(20, new int[] { 13, 19 });
            mediator.AddVertices(21, new int[] { 42, 14 });
            mediator.AddVertices(22, new int[] { 36, 19 });
            mediator.AddVertices(23, new int[] { 37, 32 });
            mediator.AddVertices(24, new int[] { 1, 19 });
            mediator.AddVertices(25, new int[] { 28, 22 });
            mediator.AddVertices(26, new int[] { 3, 35 });
            mediator.AddVertices(27, new int[] { 12, 41 });
            mediator.AddVertices(28, new int[] { 38, 22 });
            mediator.AddVertices(29, new int[] { 19, 27 });
            mediator.AddVertices(30, new int[] { 12, 4 });
            mediator.AddVertices(31, new int[] { 19, 29 });
            mediator.AddVertices(32, new int[] { 5 });
            mediator.AddVertices(33, new int[] { 7 });
            mediator.AddVertices(34, new int[] { 26, 17 });
            mediator.AddVertices(35, new int[] { 9 });
            mediator.AddVertices(36, new int[] { 26, 24 });
            mediator.AddVertices(37, new int[] { 33, 21 });
            mediator.AddVertices(38, new int[] { 12, 15 });
            mediator.AddVertices(39, new int[] { 31, 35 });
            mediator.AddVertices(40, new int[] { 32, 41 });
            mediator.AddVertices(41, new int[] { 29, 36 });
            mediator.AddVertices(42, new int[] { 46 });
            mediator.AddVertices(43, new int[] { 42, 37 });
            mediator.AddVertices(44, new int[] { 26, 17 });
            mediator.AddVertices(45, new int[] { 15, 49 });
            mediator.AddVertices(46, new int[] { 26, 24 });
            mediator.AddVertices(47, new int[] { 33 });
            mediator.AddVertices(48, new int[] { 42, 15 });
            mediator.AddVertices(49, new int[] { 41 });
            #endregion
            var time1 = PerformanceAnalysisUtility.Time(() =>
            {
                var vertexPositions1 = mediator.GetIncidentVertexPositions(5);
            });
            var time2 = PerformanceAnalysisUtility.Time(() =>
            {
                var vertexPositions2 = mediator.GetIncidentVertices(5);
            });
            Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
            Console.WriteLine("Total seconds: " + time1.TotalSeconds);
            Console.WriteLine("Total miliseconds: " + time2.TotalMilliseconds);
            Console.WriteLine("Total seconds: " + time2.TotalSeconds);
            Assert.Less(time1.TotalMilliseconds, time2.TotalMilliseconds);
        }
        [Test]
        public void UndirectedAdjacencyProvider_GetAdjacentVertexPositions_ReturnsCorrectValues()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5 });
            mediator.AddVertices(2, new int[] { 41, 3 });
            mediator.AddVertices(3, new int[] { 2, 49 });
            mediator.AddVertices(4, new int[] { 8, 5 });
            mediator.AddVertices(5, new int[] { 44, 6 });
            mediator.AddVertices(6, new int[] { 7, 15 });
            mediator.AddVertices(7, new int[] { 8, 17 });
            mediator.AddVertices(8, new int[] { 10, 4 });
            mediator.AddVertices(9, new int[] { 11, 10 });
            mediator.AddVertices(10, new int[] { 8, 9 });
            mediator.AddVertices(11, new int[] { 9, 12 });
            mediator.AddVertices(12, new int[] { 2, 13 });
            mediator.AddVertices(13, new int[] { 20, 25 });
            mediator.AddVertices(14, new int[] { 1, 24 });
            mediator.AddVertices(15, new int[] { 14, 32 });
            mediator.AddVertices(16, new int[] { 17, 39 });
            mediator.AddVertices(17, new int[] { 7, 18 });
            mediator.AddVertices(18, new int[] { 17, 10 });
            mediator.AddVertices(19, new int[] { 18, 20 });
            mediator.AddVertices(20, new int[] { 13, 19 });
            mediator.AddVertices(21, new int[] { 42, 14 });
            mediator.AddVertices(22, new int[] { 36, 19 });
            mediator.AddVertices(23, new int[] { 37, 32 });
            mediator.AddVertices(24, new int[] { 1, 19 });
            mediator.AddVertices(25, new int[] { 28, 22 });
            mediator.AddVertices(26, new int[] { 3, 35 });
            mediator.AddVertices(27, new int[] { 12, 41 });
            mediator.AddVertices(28, new int[] { 38, 22 });
            mediator.AddVertices(29, new int[] { 19, 27 });
            mediator.AddVertices(30, new int[] { 12, 4 });
            mediator.AddVertices(31, new int[] { 19, 29 });
            mediator.AddVertices(32, new int[] { 5 });
            mediator.AddVertices(33, new int[] { 7 });
            mediator.AddVertices(34, new int[] { 26, 17 });
            mediator.AddVertices(35, new int[] { 9 });
            mediator.AddVertices(36, new int[] { 26, 24 });
            mediator.AddVertices(37, new int[] { 33, 21 });
            mediator.AddVertices(38, new int[] { 12, 15 });
            mediator.AddVertices(39, new int[] { 31, 35 });
            mediator.AddVertices(40, new int[] { 32, 41 });
            mediator.AddVertices(41, new int[] { 29, 36 });
            mediator.AddVertices(42, new int[] { 46 });
            mediator.AddVertices(43, new int[] { 42, 37 });
            mediator.AddVertices(44, new int[] { 26, 17 });
            mediator.AddVertices(45, new int[] { 15, 49 });
            mediator.AddVertices(46, new int[] { 26, 24 });
            mediator.AddVertices(47, new int[] { 33 });
            mediator.AddVertices(48, new int[] { 42, 15 });
            mediator.AddVertices(49, new int[] { 41 });
            #endregion

            var vertexPositions1 = mediator.GetAdjacentVertexPositionsInclusive(5);
            var vertexPositionsList1 = vertexPositions1.ToList();
            var vertexPositions2 = mediator.GetAdjacentVertexPositionsInclusive(1);
            var vertexPositionsList2 = vertexPositions2.ToList();
            Assert.Contains(1,vertexPositionsList1);
            Assert.Contains(5, vertexPositionsList1);
            Assert.Contains(4, vertexPositionsList1);
            Assert.Contains(6, vertexPositionsList1);
            Assert.Contains(2, vertexPositionsList2);
            Assert.Contains(5, vertexPositionsList2);
            Assert.Contains(14, vertexPositionsList2);
            Assert.Contains(1, vertexPositionsList2);

            //var vertexPositions2 = mediator.GetAdjacentVertices(5);
        }
        [Test]
        public void UndirectedAdjacencyProvider_GetAdjacentVertexPositionsIntersection_ReturnsCorrectValues()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5 });
            mediator.AddVertices(2, new int[] { 41, 3 });
            mediator.AddVertices(3, new int[] { 2, 49 });
            mediator.AddVertices(4, new int[] { 8, 5 });
            mediator.AddVertices(5, new int[] { 44, 6 });
            mediator.AddVertices(6, new int[] { 7, 15 });
            mediator.AddVertices(7, new int[] { 8, 17 });
            mediator.AddVertices(8, new int[] { 10, 4 });
            mediator.AddVertices(9, new int[] { 11, 10 });
            mediator.AddVertices(10, new int[] { 8, 9 });
            mediator.AddVertices(11, new int[] { 9, 12 });
            mediator.AddVertices(12, new int[] { 2, 13 });
            mediator.AddVertices(13, new int[] { 20, 25 });
            mediator.AddVertices(14, new int[] { 1, 24 });
            mediator.AddVertices(15, new int[] { 14, 32 });
            mediator.AddVertices(16, new int[] { 17, 39 });
            mediator.AddVertices(17, new int[] { 7, 18 });
            mediator.AddVertices(18, new int[] { 17, 10 });
            mediator.AddVertices(19, new int[] { 18, 20 });
            mediator.AddVertices(20, new int[] { 13, 19 });
            mediator.AddVertices(21, new int[] { 42, 14 });
            mediator.AddVertices(22, new int[] { 36, 19 });
            mediator.AddVertices(23, new int[] { 37, 32 });
            mediator.AddVertices(24, new int[] { 1, 19 });
            mediator.AddVertices(25, new int[] { 28, 22 });
            mediator.AddVertices(26, new int[] { 3, 35 });
            mediator.AddVertices(27, new int[] { 12, 41 });
            mediator.AddVertices(28, new int[] { 38, 22 });
            mediator.AddVertices(29, new int[] { 19, 27 });
            mediator.AddVertices(30, new int[] { 12, 4 });
            mediator.AddVertices(31, new int[] { 19, 29 });
            mediator.AddVertices(32, new int[] { 5 });
            mediator.AddVertices(33, new int[] { 7 });
            mediator.AddVertices(34, new int[] { 26, 17 });
            mediator.AddVertices(35, new int[] { 9 });
            mediator.AddVertices(36, new int[] { 26, 24 });
            mediator.AddVertices(37, new int[] { 33, 21 });
            mediator.AddVertices(38, new int[] { 12, 15 });
            mediator.AddVertices(39, new int[] { 31, 35 });
            mediator.AddVertices(40, new int[] { 32, 41 });
            mediator.AddVertices(41, new int[] { 29, 36 });
            mediator.AddVertices(42, new int[] { 46 });
            mediator.AddVertices(43, new int[] { 42, 37 });
            mediator.AddVertices(44, new int[] { 26, 17 });
            mediator.AddVertices(45, new int[] { 15, 49 });
            mediator.AddVertices(46, new int[] { 26, 24 });
            mediator.AddVertices(47, new int[] { 33 });
            mediator.AddVertices(48, new int[] { 42, 15 });
            mediator.AddVertices(49, new int[] { 41 });
            #endregion

            var vertexPositions1 = mediator.GetAdjacentVertexPositionsInclusive(5);
            var vertexPositionsList1 = vertexPositions1.ToList();
            var vertexPositions2 = mediator.GetAdjacentVertexPositionsInclusive(1);
            var vertexPositionsList2 = vertexPositions2.ToList();
            Assert.Contains(1, vertexPositionsList1);
            Assert.Contains(5, vertexPositionsList1);
            Assert.Contains(4, vertexPositionsList1);
            Assert.Contains(6, vertexPositionsList1);
            Assert.Contains(44, vertexPositionsList1);
            Assert.Contains(32, vertexPositionsList1);
            Assert.AreEqual(6, vertexPositionsList1.Count);

            Assert.Contains(2, vertexPositionsList2);
            Assert.Contains(5, vertexPositionsList2);
            Assert.Contains(14, vertexPositionsList2);
            Assert.Contains(1, vertexPositionsList2);
            Assert.Contains(24, vertexPositionsList2);
            Assert.AreEqual(5, vertexPositionsList2.Count);

            var vertexPositions1Hashset = vertexPositionsList1.ToHashSet();
            var vertexPositions2Hashset = vertexPositionsList2.ToHashSet();
            var intersection = vertexPositions1Hashset.Intersect(vertexPositions2Hashset).ToList();
            Assert.Contains(1, intersection);
            Assert.Contains(5, intersection);
            Assert.AreEqual(2, intersection.Count);

            // We need method that takes edge position, gets its two vertex positions, gets their hashsets, and returns the intersection.

            //var vertexPositions2 = mediator.GetAdjacentVertices(5);
        }

        [Test]
        public void NodeStateContextMediator_GetEdgeAdjacencyIntersection_ReturnsExpectedValues()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5 });
            mediator.AddVertices(2, new int[] { 41, 3 });
            mediator.AddVertices(3, new int[] { 2, 49 });
            mediator.AddVertices(4, new int[] { 8, 5 });
            mediator.AddVertices(5, new int[] { 44, 6 });
            mediator.AddVertices(6, new int[] { 7, 15 });
            mediator.AddVertices(7, new int[] { 8, 17 });
            mediator.AddVertices(8, new int[] { 10, 4 });
            mediator.AddVertices(9, new int[] { 11, 10 });
            mediator.AddVertices(10, new int[] { 8, 9 });
            mediator.AddVertices(11, new int[] { 9, 12 });
            mediator.AddVertices(12, new int[] { 2, 13 });
            mediator.AddVertices(13, new int[] { 20, 25 });
            mediator.AddVertices(14, new int[] { 1, 24 });
            mediator.AddVertices(15, new int[] { 14, 32 });
            mediator.AddVertices(16, new int[] { 17, 39 });
            mediator.AddVertices(17, new int[] { 7, 18 });
            mediator.AddVertices(18, new int[] { 17, 10 });
            mediator.AddVertices(19, new int[] { 18, 20 });
            mediator.AddVertices(20, new int[] { 13, 19 });
            mediator.AddVertices(21, new int[] { 42, 14 });
            mediator.AddVertices(22, new int[] { 36, 19 });
            mediator.AddVertices(23, new int[] { 37, 32 });
            mediator.AddVertices(24, new int[] { 1, 19 });
            mediator.AddVertices(25, new int[] { 28, 22 });
            mediator.AddVertices(26, new int[] { 3, 35 });
            mediator.AddVertices(27, new int[] { 12, 41 });
            mediator.AddVertices(28, new int[] { 38, 22 });
            mediator.AddVertices(29, new int[] { 19, 27 });
            mediator.AddVertices(30, new int[] { 12, 4 });
            mediator.AddVertices(31, new int[] { 19, 29 });
            mediator.AddVertices(32, new int[] { 5 });
            mediator.AddVertices(33, new int[] { 7 });
            mediator.AddVertices(34, new int[] { 26, 17 });
            mediator.AddVertices(35, new int[] { 9 });
            mediator.AddVertices(36, new int[] { 26, 24 });
            mediator.AddVertices(37, new int[] { 33, 21 });
            mediator.AddVertices(38, new int[] { 12, 15 });
            mediator.AddVertices(39, new int[] { 31, 35 });
            mediator.AddVertices(40, new int[] { 32, 41 });
            mediator.AddVertices(41, new int[] { 29, 36 });
            mediator.AddVertices(42, new int[] { 46 });
            mediator.AddVertices(43, new int[] { 42, 37 });
            mediator.AddVertices(44, new int[] { 26, 17 });
            mediator.AddVertices(45, new int[] { 15, 49 });
            mediator.AddVertices(46, new int[] { 26, 24 });
            mediator.AddVertices(47, new int[] { 33 });
            mediator.AddVertices(48, new int[] { 42, 15 });
            mediator.AddVertices(49, new int[] { 41 });
            #endregion

            UndirectedAdjacencyProvider_GetAdjacentVertexPositionsIntersection_ReturnsCorrectValues();

            var vertexPositions1 = mediator.GetAdjacentVertexPositionsInclusive(5);
            var vertexPositionsList1 = vertexPositions1.ToList();
            var vertexPositions2 = mediator.GetAdjacentVertexPositionsInclusive(1);
            var vertexPositionsList2 = vertexPositions2.ToList();
            
            var vertexPositions1Hashset = vertexPositionsList1.ToHashSet();
            var vertexPositions2Hashset = vertexPositionsList2.ToHashSet();
            var intersection = vertexPositions1Hashset.Intersect(vertexPositions2Hashset).ToList();
            Assert.Contains(1, intersection);
            Assert.Contains(5, intersection);
            Assert.AreEqual(2, intersection.Count);
            var desiredEdge1 = mediator.GetEdgeIncidentToBothVertices(5, 1);
            var intersection2 = mediator.GetEdgeAdjacencyIntersection(desiredEdge1.Position).ToList();
            Assert.AreEqual(intersection, intersection2);
        }

        [Test]
        public void
            NodeStateContextMediator_ApplyAdjacencyIntersectionValuesToAllEdgesInGraph_ReturnsVoidButGraphWithExpectedEdgeProperties
            ()
        {
            var mediator = new FakeNodeStateContextMediator();
            #region data
            mediator.AddVertices(1, new int[] { 2, 5, 14 });
            mediator.AddVertices(2, new int[] { 1, 12, 3 });
            mediator.AddVertices(3, new int[] { 2, 9, 4 });
            mediator.AddVertices(4, new int[] { 3, 8, 5 });
            mediator.AddVertices(5, new int[] { 4, 6, 1 });
            mediator.AddVertices(6, new int[] { 7, 15, 5 });
            mediator.AddVertices(7, new int[] { 8, 17, 6 });
            mediator.AddVertices(8, new int[] { 10, 4, 7 });
            mediator.AddVertices(9, new int[] { 11, 3, 10 });
            mediator.AddVertices(10, new int[] { 8, 9, 18 });
            mediator.AddVertices(11, new int[] { 9, 12, 19 });
            mediator.AddVertices(12, new int[] { 2, 11, 13 });
            mediator.AddVertices(13, new int[] { 12, 14, 20 });
            mediator.AddVertices(14, new int[] { 13, 1, 15 });
            mediator.AddVertices(15, new int[] { 6, 14, 16 });
            mediator.AddVertices(16, new int[] { 15, 20, 17 });
            mediator.AddVertices(17, new int[] { 7, 16, 18 });
            mediator.AddVertices(18, new int[] { 17, 19, 10 });
            mediator.AddVertices(19, new int[] { 18, 20, 11 });
            mediator.AddVertices(20, new int[] { 13, 16, 19 });
            #endregion

            mediator.ApplyAdjacencyIntersectionValuesToAllEdgesInGraph();
            var edge15 = mediator.GetEdgeIncidentToBothVertices(1, 5);
            var edgeIntersectionSet = edge15.Node.ValueSet.ToList();
            Assert.Contains(5, edgeIntersectionSet);
            Assert.Contains(1, edgeIntersectionSet);
            Assert.AreEqual(2,edgeIntersectionSet.Count);
        }
        [Test]
        public void NodeStateContextMediator_GetAdjacentVertexPositions_ReturnsCorrectValuesWithCaching()
        {

        }
        //[Test]
        //public void NodeStateContextContainerFacade_GetNodesWithState_ReturnsExpectedList()
        //{
        //    // Perform a performance test to check performance difference between GetEdgeNodeStateContexts(..)
        //    var vertexNodeStateContextFactory = new VertexNodeStateContextFactory();
        //    var edgeNodeStateContextFactory = new EdgeNodeStateContextFactory();
        //    var vertexContainer = new VertexNodeStateContextContainer();
        //    var edgeContainer = new EdgeNodeStateContextContainer();
        //    var vertexNodeFactory = VertexNodeFactory.GetFactory();
        //    var edgeNodeFactory = EdgeNodeFactory.GetFactory();
        //    for (int i = 1; i < 1000; i++)
        //    {
        //        var v1 = vertexNodeStateContextFactory.ConstructDefaultNodeContext(i);
        //        var e1 = edgeNodeStateContextFactory.ConstructDefaultNodeContext(i);
        //        vertexContainer.Add(v1.Position, v1);
        //        edgeContainer.Add(e1.Position, e1);
        //    }
        //    for (int i = 1001; i < 2000; i++)
        //    {
        //        var v1 = vertexNodeStateContextFactory.ConstructNodeContext(i, MaleChosenVertexNodeState.State);
        //        var e1 = edgeNodeStateContextFactory.ConstructNodeContext(i, MaleChosenEdgeNodeState.State);
        //        vertexContainer.Add(v1.Position, v1);
        //        edgeContainer.Add(e1.Position, e1);
        //    }
        //    for (int i = 2001; i < 3000; i++)
        //    {
        //        var v1 = vertexNodeStateContextFactory.ConstructNodeContext(i, FemaleChosenVertexNodeState.State);
        //        var e1 = edgeNodeStateContextFactory.ConstructNodeContext(i, FemaleChosenEdgeNodeState.State);
        //        vertexContainer.Add(v1.Position, v1);
        //        edgeContainer.Add(e1.Position, e1);
        //    }
        //    var facade = new NodeStateContextContainerFacade(edgeContainer, vertexContainer);
        //    var timeWithCast = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        var maleChosenEdges = facade.GetEdgeNodeStateContexts(MaleChosenEdgeNodeState.State);

        //    });
        //    var timeWithoutCast = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        var maleChosenEdges = facade.GetIncidentEdgeNodesWithState(MaleChosenEdgeNodeState.State);

        //    });
        //    Console.WriteLine("First time is {0} miliseconds.", timeWithCast.TotalMilliseconds);
        //    Console.WriteLine("Second time is {0} miliseconds.", timeWithoutCast.TotalMilliseconds);
        //    Assert.Less(timeWithoutCast, timeWithCast);
        //    /* Results were:
        //     *      First time is 7.8686 miliseconds.
        //     *      Second time is 0.7221 miliseconds.
        //     * 
        //     * */


        //}
        [Test]
        public void NodeStateContextMediator_GetEdgeIncidentToBothVertices_ReturnsExpectedEdge()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void NodeStateContextMediator_DoesCutOrphanVertex_ReturnsExpectedEdge()
        {
            /*
            // This method needs to check not only the adjacency matrix,
            // but it also must check the contextContainer for objects with the 
            // state in question.
            // The best way to structure the logic is like this:
               1. We start with a source vertex
             * 2. We get its incident edges
             * 3. 
            

            */
            Assert.AreEqual(true, false);
        }
        [Test]
        public void NodeStateContextMediator_GetIncidentEdgeNodeStateContexts_ReturnsExpectedEdge()
        {
            
            Assert.AreEqual(true, false);
        }
        [Test]
        public void NodeStateContextMediator_AreVerticesBothAdjacentAndUncut_ReturnsExpectedEdge()
        {
            
            Assert.AreEqual(true, false);
        }
        
        [Test]
        public void EdgeNodeStateContext_GetIncidentVerticesAsTuple_ReturnsExpectedTuple()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void EdgeNodeStateContext_DoesCutOrphanVertex_ReturnsTrueWhenExpected()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void VertexNodeStateContext_GetUncutEdges_ReturnsExpectedEdges()
        {
            Assert.AreEqual(true, false);
        }
        [Test]
        public void VertexNodeStateContext_GetUncutEdgeCount_ReturnsExpectedEdges()
        {
            Assert.AreEqual(true, false);
        }

        [Test]
        public void DIMACSReader_DoesDIMACSFileBecomeGraph_ReturnsTrue()
        {
            try
            {
                var mediator = new FakeNodeStateContextMediator();
                var vertexContextFactory = new VertexNodeStateContextFactory<FakeVertexNodeStateContext>();
                var edgeContextFactory = new EdgeNodeStateContextFactory<FakeEdgeNodeStateContext>();
                var vertexPosition = 0;
                var clauseNumber = 0;
                using (StreamReader sr = new StreamReader(@"C:\Users\devinbost\Documents\Visual Studio 2013\Projects\Nucleotide_v2\Nucleotide_v2.Test\Data\minesweeper_basic3.fzn.dimacs"))
                {
                    //String line = await sr.ReadToEndAsync();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var valuesInLine = line.Split(' ');
                        clauseNumber++;
                        
                        if (valuesInLine.Length >= 1)
                        {
                            if (valuesInLine[0] != "p")
                            {
                                int[] myInts = Array.ConvertAll(valuesInLine, s => int.Parse(s));
                                foreach (var vertexValue in myInts)
                                {
                                    if (vertexValue != 0) // 0 should always be at the end of the line, and it should never be anywhere else in the file.
                                    {
                                        vertexPosition++;
                                        mediator.AddVertex(vertexPosition: vertexPosition, vertexValue: vertexValue, vertexClause: clauseNumber, factory: vertexContextFactory);
                                        // we need a method that adds a vertex and also sets its clause and value.
                                    }
                                }
                            }
                        }
                    }
                }
                // Then once all of the vertices have been added, we can create edges.
                // for each vertex a,
                    // for each vertex b,
                        // if a.Clause != b.Clause
                            // if a.Value != -b.Value
                                // create edge between a and b.
                var edgeTracker = EdgeTracker.GetTracker();
                // I would need a singleton method to keep track of my edge number to perform this task in parallel.
                Stopwatch sw = new Stopwatch();

                sw.Start();

                
                //foreach (var fakeVertexNodeStateContextA in mediator.VertexNodeStateContexts)
                //{
                Parallel.ForEach(mediator.VertexNodeStateContexts, (fakeVertexNodeStateContextA) =>
                {
                    foreach (var fakeVertexNodeStateContextB in mediator.VertexNodeStateContexts)
                    {
                        var a = fakeVertexNodeStateContextA.Value.Node;
                        var b = fakeVertexNodeStateContextB.Value.Node;
                        if (a.Position != b.Position)
                        {
                            if (a.Clause != b.Clause)
                            {
                                if (a.Value != -b.Value)
                                {
                                    
                                    // create edge between a and b.
                                    //var edge = edgeContextFactory.ConstructDefaultNodeContext(edgeNumber);
                                    mediator.AddVertices(a.Position, b.Position, edgeContextFactory, vertexContextFactory);
                                }
                            }
                        }
                        
                    }
                });
                /* Next steps: 
                 *      Determine if we can find algorithm/software for log-support encoding.
                 *      Use unit propagation to eliminate literals and clauses.
                 *      Determine if we can use SMT.
                 *      
                 * 
                 * */


                sw.Stop();
                //}
                Console.WriteLine(sw.Elapsed.TotalMinutes + " are number of minutes.");
                Console.WriteLine(sw.Elapsed.TotalSeconds + " are number of seconds.");

                mediator.ApplyAdjacencyIntersectionValuesToAllEdgesInGraph();
                // Next, we need to generate the adjacency intersection matrix.
                var edge15 = mediator.GetEdgeIncidentToBothVertices(1, 5);
                var edgeIntersectionSet = edge15.Node.ValueSet.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file couldn't be read. What happened?");
                Console.WriteLine(ex.Message);
            }
            
        }
        #region largeGraphs
        //[Test]
        //public void VertexNodeVisitor_DoesVisitMethodWorkOnCompleteGraph_ReturnsTrue()
        //{
        //    var mediator = new FakeNodeStateContextMediator();
        //    mediator.AddVertices(1, new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        //    mediator.AddVertices(2, new int[] { 1, 3, 4, 5, 6, 7, 8, 9, 10 });
        //    mediator.AddVertices(3, new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10 });
        //    mediator.AddVertices(4, new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10 });
        //    mediator.AddVertices(5, new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10 });
        //    mediator.AddVertices(6, new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 });
        //    mediator.AddVertices(7, new int[] { 1, 2, 3, 4, 5, 6, 8, 9, 10 });
        //    mediator.AddVertices(8, new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 10 });
        //    mediator.AddVertices(9, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10 });
        //    mediator.AddVertices(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        //    //mediator.AddVertices(1, new int[] { 2, 3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20 });
        //    //mediator.AddVertices(2, new int[] { 1,  3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(3, new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(4, new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(5, new int[] { 1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(6, new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(7, new int[] { 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(8, new int[] { 1, 2, 3, 4, 5, 6, 7,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(9, new int[] { 1, 2, 3, 4, 5, 6, 7, 8,  10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(11, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,  12, 13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,  13, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(13, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 14, 15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(14, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13,  15, 16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(15, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,  16, 17, 18, 19, 20 });
        //    //mediator.AddVertices(16, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,  17, 18, 19, 20 });
        //    //mediator.AddVertices(17, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,  18, 19, 20 });
        //    //mediator.AddVertices(18, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17,  19, 20 });
        //    //mediator.AddVertices(19, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18,  20 });
        //    //mediator.AddVertices(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19});

        //    var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        visitor.Visit(mediator, 5);
        //    });
        //    //visitor.Visit(mediator, 5);
        //    Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
        //    Console.WriteLine("Total seconds: " + time1.TotalSeconds);
        //    // Total miliseconds: 196.4314
        //    // Total miliseconds: 179.3093
        //    // Total miliseconds: 159.4048
        //    // Total miliseconds: 154.6347
        //    // Total miliseconds: 152.4727
        //}
        //[Test]
        //public void VertexNodeVisitor_DoesVisitMethodWorkOnCompleteGraphOf5Vertices_ReturnsTrue()
        //{
        //    var test = Convert.ToDecimal("2.5");
        //    var mediator = new FakeNodeStateContextMediator();
        //    mediator.AddVertices(1, new int[] { 2, 3, 4, 5 });
        //    mediator.AddVertices(2, new int[] { 1, 3, 4, 5 });
        //    mediator.AddVertices(3, new int[] { 1, 2, 4, 5 });
        //    mediator.AddVertices(4, new int[] { 1, 2, 3, 5 });
        //    mediator.AddVertices(5, new int[] { 1, 2, 3, 4 });

        //    var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        visitor.Visit(mediator, 5);
        //    });
        //    //visitor.Visit(mediator, 5);
        //    Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
        //    Console.WriteLine("Total seconds: " + time1.TotalSeconds);
        //    // We need an assert on the count. This visit should contain 12 cycles with greater than or equal to 5 vertices.

        //    // Total miliseconds: 196.4314
        //    // Total miliseconds: 179.3093
        //    // Total miliseconds: 159.4048
        //    // Total miliseconds: 154.6347
        //    // Total miliseconds: 152.4727
        //}
        //[Test]
        //public void VertexNodeVisitor_DoesVisitMethodWorkOnLargerGraph_ReturnsTrue()
        //{
        //    var mediator = new FakeNodeStateContextMediator();
        //    mediator.AddVertices(1, new int[] { 2, 5, 14 });
        //    mediator.AddVertices(2, new int[] { 1, 3, 32 });
        //    mediator.AddVertices(3, new int[] { 2, 9, 37 });
        //    mediator.AddVertices(4, new int[] { 8, 5, 14 });
        //    mediator.AddVertices(5, new int[] { 4, 6, 22 });
        //    mediator.AddVertices(6, new int[] { 7, 15, 5 });
        //    mediator.AddVertices(7, new int[] { 8, 17, 6, 12 });
        //    mediator.AddVertices(8, new int[] { 10, 4, 7 });
        //    mediator.AddVertices(9, new int[] { 11, 10, 28 });
        //    mediator.AddVertices(10, new int[] { 8, 9 });
        //    mediator.AddVertices(11, new int[] { 9, 12 });
        //    mediator.AddVertices(12, new int[] { 2, 13 });
        //    mediator.AddVertices(13, new int[] { 20, 25 });
        //    mediator.AddVertices(14, new int[] { 1, 24 });
        //    mediator.AddVertices(15, new int[] { 14, 32 });
        //    mediator.AddVertices(16, new int[] { 17, 39 });
        //    mediator.AddVertices(17, new int[] { 7, 18 });
        //    mediator.AddVertices(18, new int[] { 17, 10 });
        //    mediator.AddVertices(19, new int[] { 18, 20 });
        //    mediator.AddVertices(20, new int[] { 13, 19 });
        //    mediator.AddVertices(21, new int[] { 2, 14 });
        //    mediator.AddVertices(22, new int[] { 36, 19 });
        //    mediator.AddVertices(23, new int[] { 37, 32 });
        //    mediator.AddVertices(24, new int[] { 1, 19 });
        //    mediator.AddVertices(25, new int[] { 28, 22 });
        //    mediator.AddVertices(26, new int[] { 3, 35 });
        //    mediator.AddVertices(27, new int[] { 12, 1 });
        //    mediator.AddVertices(28, new int[] { 38, 22 });
        //    mediator.AddVertices(29, new int[] { 19, 27 });
        //    mediator.AddVertices(30, new int[] { 12, 4 });
        //    mediator.AddVertices(31, new int[] { 19, 29 });
        //    mediator.AddVertices(32, new int[] { 2, 5 });
        //    mediator.AddVertices(33, new int[] { 2, 7 });
        //    mediator.AddVertices(34, new int[] { 26, 17 });
        //    mediator.AddVertices(35, new int[] { 5, 9 });
        //    mediator.AddVertices(36, new int[] { 26, 24 });
        //    mediator.AddVertices(37, new int[] { 33, 21 });
        //    mediator.AddVertices(38, new int[] { 12, 15 });
        //    mediator.AddVertices(39, new int[] { 31, 35 });


        //    var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        visitor.Visit(mediator, 5);
        //    });
        //    //visitor.Visit(mediator, 5);
        //    Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
        //    Console.WriteLine("Total seconds: " + time1.TotalSeconds);
        //    Console.WriteLine("Total minutes: " + time1.TotalMinutes);
        //    // Non-parallel case: Total seconds: 875.9485083 = 14.5991 minutes
        //    // Parallel case:     Total seconds: 542.0033296 = 9.03339 minutes

        //    //Total seconds: 716.1841456
        //    //Total minutes: 11.9364024266667
        //    // After adding the GetIncidentEdgeCache and GetIncidentVertexCache.
        //    // Total minutes: 9.56646527166667

        //    // Version 3.2 when filtering to only those with manTrail.Count > 17:
        //    //Total miliseconds: 183087.7134
        //    //Total seconds: 183.0877134
        //    //Total minutes: 3.05146189

        //}
        //[Test]
        //public void VertexNodeVisitor_DoesVisitMethodWorkOnMuchLargerGraph_ReturnsTrue()
        //{
        //    var mediator = new FakeNodeStateContextMediator();
        //    mediator.AddVertices(1, new int[] { 2, 5, 14 });
        //    mediator.AddVertices(2, new int[] { 41, 3, 32 });
        //    mediator.AddVertices(3, new int[] { 2, 49, 37 });
        //    mediator.AddVertices(4, new int[] { 8, 5, 14 });
        //    mediator.AddVertices(5, new int[] { 44, 6, 22 });
        //    mediator.AddVertices(6, new int[] { 7, 15, 5 });
        //    mediator.AddVertices(7, new int[] { 8, 17, 6, 12 });
        //    mediator.AddVertices(8, new int[] { 10, 4, 47 });
        //    mediator.AddVertices(9, new int[] { 11, 10, 28 });
        //    mediator.AddVertices(10, new int[] { 8, 9 });
        //    mediator.AddVertices(11, new int[] { 9, 12 });
        //    mediator.AddVertices(12, new int[] { 2, 13 });
        //    mediator.AddVertices(13, new int[] { 20, 25 });
        //    mediator.AddVertices(14, new int[] { 1, 24 });
        //    mediator.AddVertices(15, new int[] { 14, 32 });
        //    mediator.AddVertices(16, new int[] { 17, 39 });
        //    mediator.AddVertices(17, new int[] { 7, 18 });
        //    mediator.AddVertices(18, new int[] { 17, 10 });
        //    mediator.AddVertices(19, new int[] { 18, 20 });
        //    mediator.AddVertices(20, new int[] { 13, 19 });
        //    mediator.AddVertices(21, new int[] { 42, 14 });
        //    mediator.AddVertices(22, new int[] { 36, 19 });
        //    mediator.AddVertices(23, new int[] { 37, 32 });
        //    mediator.AddVertices(24, new int[] { 1, 19 });
        //    mediator.AddVertices(25, new int[] { 28, 22 });
        //    mediator.AddVertices(26, new int[] { 3, 35 });
        //    mediator.AddVertices(27, new int[] { 12, 41 });
        //    mediator.AddVertices(28, new int[] { 38, 22 });
        //    mediator.AddVertices(29, new int[] { 19, 27 });
        //    mediator.AddVertices(30, new int[] { 12, 4 });
        //    mediator.AddVertices(31, new int[] { 19, 29 });
        //    mediator.AddVertices(32, new int[] { 2, 5 });
        //    mediator.AddVertices(33, new int[] { 2, 7 });
        //    mediator.AddVertices(34, new int[] { 26, 17 });
        //    mediator.AddVertices(35, new int[] { 5, 9 });
        //    mediator.AddVertices(36, new int[] { 26, 24 });
        //    mediator.AddVertices(37, new int[] { 33, 21 });
        //    mediator.AddVertices(38, new int[] { 12, 15 });
        //    mediator.AddVertices(39, new int[] { 31, 35 });
        //    mediator.AddVertices(40, new int[] { 32, 41 });
        //    mediator.AddVertices(41, new int[] { 29, 29 });
        //    mediator.AddVertices(42, new int[] { 42, 5 });
        //    mediator.AddVertices(43, new int[] { 42, 37 });
        //    mediator.AddVertices(44, new int[] { 26, 17 });
        //    mediator.AddVertices(45, new int[] { 15, 49 });
        //    mediator.AddVertices(46, new int[] { 26, 24 });
        //    mediator.AddVertices(47, new int[] { 33, 1 });
        //    mediator.AddVertices(48, new int[] { 42, 15 });
        //    mediator.AddVertices(49, new int[] { 41, 5 });

        //    var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        visitor.Visit(mediator, 5);
        //    });
        //    //visitor.Visit(mediator, 5);
        //    Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
        //    Console.WriteLine("Total seconds: " + time1.TotalSeconds);
        //    Console.WriteLine("Total minutes: " + time1.TotalMinutes);
        //    // Non-parallel case: Total seconds: 875.9485083 = 14.5991 minutes
        //    // Parallel case:     Total seconds: 542.0033296 = 9.03339 minutes

        //    //Total seconds: 716.1841456
        //    //Total minutes: 11.9364024266667
        //    // After adding the GetIncidentEdgeCache and GetIncidentVertexCache.
        //    // Total minutes: 9.56646527166667

        //    // Version 3.2 when filtering to only those with manTrail.Count > 17:
        //    //Total miliseconds: 183087.7134
        //    //Total seconds: 183.0877134
        //    //Total minutes: 3.05146189

        //}
        //[Test]
        //public void VertexNodeVisitor_DoesVisitMethodWork50VertexGraphWithDegreeBetween3And5_ReturnsTrue()
        //{
        //    var mediator = new FakeNodeStateContextMediator();
        //    mediator.AddVertices(1, new int[] { 2, 5 });
        //    mediator.AddVertices(2, new int[] { 41, 3 });
        //    mediator.AddVertices(3, new int[] { 2, 49 });
        //    mediator.AddVertices(4, new int[] { 8, 5 });
        //    mediator.AddVertices(5, new int[] { 44, 6 });
        //    mediator.AddVertices(6, new int[] { 7, 15 });
        //    mediator.AddVertices(7, new int[] { 8, 17 });
        //    mediator.AddVertices(8, new int[] { 10, 4 });
        //    mediator.AddVertices(9, new int[] { 11, 10 });
        //    mediator.AddVertices(10, new int[] { 8, 9 });
        //    mediator.AddVertices(11, new int[] { 9, 12 });
        //    mediator.AddVertices(12, new int[] { 2, 13 });
        //    mediator.AddVertices(13, new int[] { 20, 25 });
        //    mediator.AddVertices(14, new int[] { 1, 24 });
        //    mediator.AddVertices(15, new int[] { 14, 32 });
        //    mediator.AddVertices(16, new int[] { 17, 39 });
        //    mediator.AddVertices(17, new int[] { 7, 18 });
        //    mediator.AddVertices(18, new int[] { 23, 10 });
        //    mediator.AddVertices(19, new int[] { 18, 20 });
        //    mediator.AddVertices(20, new int[] { 28, 13 });
        //    mediator.AddVertices(21, new int[] { 42, 14 });
        //    mediator.AddVertices(22, new int[] { 43, 36 });
        //    mediator.AddVertices(23, new int[] { 45, 37 });
        //    mediator.AddVertices(24, new int[] { 1, 19 });
        //    mediator.AddVertices(25, new int[] { 28, 22 });
        //    mediator.AddVertices(26, new int[] { 3, 35 });
        //    mediator.AddVertices(27, new int[] { 39, 41 });
        //    mediator.AddVertices(28, new int[] { 38, 22 });
        //    mediator.AddVertices(29, new int[] { 38, 27 });
        //    mediator.AddVertices(30, new int[] { 34, 4 });
        //    mediator.AddVertices(31, new int[] { 36, 16 });
        //    mediator.AddVertices(32, new int[] { 46, 5 });
        //    mediator.AddVertices(33, new int[] { 47 });
        //    mediator.AddVertices(34, new int[] { 30, 15 });
        //    mediator.AddVertices(35, new int[] { 12, 9 });
        //    mediator.AddVertices(36, new int[] { 40, 26 });
        //    mediator.AddVertices(37, new int[] { 33, 21 });
        //    mediator.AddVertices(38, new int[] { 31, 11 });
        //    mediator.AddVertices(39, new int[] { 31, 35 });
        //    mediator.AddVertices(40, new int[] { 30, 48 });
        //    mediator.AddVertices(41, new int[] { 34, 29 });
        //    mediator.AddVertices(42, new int[] { 21, 6 });
        //    mediator.AddVertices(43, new int[] { 16, 37 });
        //    mediator.AddVertices(44, new int[] { 23, 27 });
        //    mediator.AddVertices(45, new int[] { 19, 49 });
        //    mediator.AddVertices(46, new int[] { 32, 29 });
        //    mediator.AddVertices(47, new int[] { 24, 33 });
        //    mediator.AddVertices(48, new int[] { 25, 6 });
        //    mediator.AddVertices(49, new int[] { 26 });

        //    var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        visitor.Visit(mediator, 5);
        //    });
        //    //visitor.Visit(mediator, 5);
        //    Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
        //    Console.WriteLine("Total seconds: " + time1.TotalSeconds);
        //    Console.WriteLine("Total minutes: " + time1.TotalMinutes);
        //    // Non-parallel case: Total seconds: 875.9485083 = 14.5991 minutes
        //    // Parallel case:     Total seconds: 542.0033296 = 9.03339 minutes

        //    //Total seconds: 716.1841456
        //    //Total minutes: 11.9364024266667
        //    // After adding the GetIncidentEdgeCache and GetIncidentVertexCache.
        //    // Total minutes: 9.56646527166667

        //    // Version 3.2 when filtering to only those with manTrail.Count > 17:
        //    //Total miliseconds: 183087.7134
        //    //Total seconds: 183.0877134
        //    //Total minutes: 3.05146189

        //}
        //[Test]
        //public void VertexNodeVisitor_DoesVisitMethodWorkOnMuchLargerGraphWithLimitedDegree_ReturnsTrue()
        //{
        //    var mediator = new FakeNodeStateContextMediator();
        //    mediator.AddVertices(1, new int[] { 2, 5 });
        //    mediator.AddVertices(2, new int[] { 41, 3 });
        //    mediator.AddVertices(3, new int[] { 2, 49 });
        //    mediator.AddVertices(4, new int[] { 8, 5 });
        //    mediator.AddVertices(5, new int[] { 44, 6 });
        //    mediator.AddVertices(6, new int[] { 7, 15 });
        //    mediator.AddVertices(7, new int[] { 8, 17 });
        //    mediator.AddVertices(8, new int[] { 10, 4 });
        //    mediator.AddVertices(9, new int[] { 11, 10 });
        //    mediator.AddVertices(10, new int[] { 8, 9 });
        //    mediator.AddVertices(11, new int[] { 9, 12 });
        //    mediator.AddVertices(12, new int[] { 2, 13 });
        //    mediator.AddVertices(13, new int[] { 20, 25 });
        //    mediator.AddVertices(14, new int[] { 1, 24 });
        //    mediator.AddVertices(15, new int[] { 14, 32 });
        //    mediator.AddVertices(16, new int[] { 17, 39 });
        //    mediator.AddVertices(17, new int[] { 7, 18 });
        //    mediator.AddVertices(18, new int[] { 17, 10 });
        //    mediator.AddVertices(19, new int[] { 18, 20 });
        //    mediator.AddVertices(20, new int[] { 13, 19 });
        //    mediator.AddVertices(21, new int[] { 42, 14 });
        //    mediator.AddVertices(22, new int[] { 36, 19 });
        //    mediator.AddVertices(23, new int[] { 37, 32 });
        //    mediator.AddVertices(24, new int[] { 1, 19 });
        //    mediator.AddVertices(25, new int[] { 28, 22 });
        //    mediator.AddVertices(26, new int[] { 3, 35 });
        //    mediator.AddVertices(27, new int[] { 12, 41 });
        //    mediator.AddVertices(28, new int[] { 38, 22 });
        //    mediator.AddVertices(29, new int[] { 19, 27 });
        //    mediator.AddVertices(30, new int[] { 12, 4 });
        //    mediator.AddVertices(31, new int[] { 19, 29 });
        //    mediator.AddVertices(32, new int[] { 5 });
        //    mediator.AddVertices(33, new int[] { 7 });
        //    mediator.AddVertices(34, new int[] { 26, 17 });
        //    mediator.AddVertices(35, new int[] { 9 });
        //    mediator.AddVertices(36, new int[] { 26, 24 });
        //    mediator.AddVertices(37, new int[] { 33, 21 });
        //    mediator.AddVertices(38, new int[] { 12, 15 });
        //    mediator.AddVertices(39, new int[] { 31, 35 });
        //    mediator.AddVertices(40, new int[] { 32, 41 });
        //    mediator.AddVertices(41, new int[] { 29, 36 });
        //    mediator.AddVertices(42, new int[] { 46 });
        //    mediator.AddVertices(43, new int[] { 42, 37 });
        //    mediator.AddVertices(44, new int[] { 26, 17 });
        //    mediator.AddVertices(45, new int[] { 15, 49 });
        //    mediator.AddVertices(46, new int[] { 26, 24 });
        //    mediator.AddVertices(47, new int[] { 33 });
        //    mediator.AddVertices(48, new int[] { 42, 15 });
        //    mediator.AddVertices(49, new int[] { 41 });

        //    var visitor = new VertexNodeVisitor<FakeEdgeNodeStateContext, FakeVertexNodeStateContext, FakeNodeStateContextMediator>();
        //    var time1 = PerformanceAnalysisUtility.Time(() =>
        //    {
        //        visitor.Visit(mediator, 42);
        //    });
        //    //visitor.Visit(mediator, 5);
        //    Console.WriteLine("Total miliseconds: " + time1.TotalMilliseconds);
        //    Console.WriteLine("Total seconds: " + time1.TotalSeconds);
        //    Console.WriteLine("Total minutes: " + time1.TotalMinutes);
        //    // Total minutes: 1.06665683833333 when starting from vertex 5 !?!?!

        //}

#endregion
    }

    public class EdgeTracker
    {
        private static EdgeTracker _edgeTracker = null;
        private static int _edgeId = 0;
        private EdgeTracker() // defeats instantiation
        {
            
        }

        public static EdgeTracker GetTracker()
        {
            return _edgeTracker ?? (_edgeTracker = new EdgeTracker());
        }

        static int GetEdgeId
        {
            get
            {
                return Interlocked.Increment(ref _edgeId);
            }
        }
    }
}
