using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Nucleotide_v2.Direct;
using Nucleotide_v2.Exceptions;

namespace Nucleotide_v2.Visit
{
    public class VertexNodeVisitor : IVertexNodeVisitor 
    {
        // We need a visitor for constructing a VertexNode<T> tree (given degree of inference and initial vertex).
        // We need a visitor for computing the weight of the tree elements.
        // We need a visitor for computing applying the weight of the tree elements to their corresponding VertexNode<T> objects.
        private int _counter = 0;
        // So, we need a method that takes an Action involving a VertexNode<T>. 
        // (How would we track levels of inference?) Do we need a VertexTreeNode<T>?

        public VertexNodeVisitor() : this(5)
        {
            //this.VisitedVertices = new Dictionary<int, IAdjacencyDirectableVisitable>();
        }
        public VertexNodeVisitor(int counter)
        {
            if (counter < 0)
            {
                throw new ArgumentOutOfRangeException("counter", "Error: counter must be >= 0. We cannot visit negative levels of nodes.");
            }
            _counter = counter;
            //this.VisitedVertices = new Dictionary<int, IAdjacencyDirectableVisitable>();
        }

        private int _weight = 0;
        public List<Queue<int>> _positionQueueList = new List<Queue<int>>();
       

        //public Dictionary<int, IAdjacencyDirectableVisitable> VisitedVertices { get; set; }

        //public bool IsFirstStep
        //{
        //    get
        //    {
        //        if (this.VisitedVertices.Any())
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            return true;
        //        }
        //    }
        //}
        public bool IsFirstStep(IDictionary<int, IAdjacencyDirectableVisitable> visitedVertices)
        {
            if (visitedVertices.Any())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool WasVertexVisited(int vertexPosition, IDictionary<int, IAdjacencyDirectableVisitable> visitedVertices)
        {
            return visitedVertices.ContainsKey(vertexPosition);
        }
        public bool WasVertexVisited(IAdjacencyDirectableVisitable vertex, IDictionary<int, IAdjacencyDirectableVisitable> visitedVertices)
        {
            return visitedVertices.ContainsKey(vertex.Position);
        }
        /// <summary>
        /// Use this one.
        /// </summary>
        /// <param name="visitable"></param>
        public void Visit(IAdjacencyDirectableVisitable visitable)
        {
            Visit(visitable, 2, null);
        }
        /// <summary>
        /// Use the other overload.
        /// </summary>
        /// <param name="visitable"></param>
        /// <param name="depth"></param>
        public void Visit(IAdjacencyDirectableVisitable visitable, int depth)
        {
            // This overload will not be called recursively, so it should have an accurate list of visited vertices.
            Visit(visitable, depth, null);
        }
        // public abstract void Visit(Node<T> node, Action<T> action);
        // Should we have an actionableNodeVisitor and a functionalNodeVisitor as subtypes? Or will they all be actionable?
        /// <summary>
        /// Use the other overload. This visits the nodes to compute the weight.
        /// </summary>
        /// <param name="visitable">This is the node we wish to visit.</param>
        /// <param name="depth">The depth is intended to prevent infinite recursion.</param>
        /// <param name="positionQueue"></param>
        public void Visit(IAdjacencyDirectableVisitable visitable, int depth, Queue<int> positionQueue) 
        {
            if (positionQueue == null || !positionQueue.Any()) // Indicates if this is the first visitation in the stack.
            {
                if (positionQueue == null)
                {
                    positionQueue = new Queue<int>();
                }
                visitable.Choose();
                PerformCuts(visitable);
            }
            
            if (depth < 0)
            {
                throw new ArgumentOutOfRangeException("depth", "Visitor recursion depth cannot be negative!");
            }
            // How do we check if this is the first execution?
            positionQueue.Enqueue(visitable.Position);
            //positionQueue.Enqueue(new Tuple<int, int>(visitable.Position, visitable.Weight));
            // compute weights and get adjacent children.
            // for number of steps of counter, recursively get sum of childrens' weights.
            //_weight += visitable.Weight;
            //visitable.Weight = _counter - depth;
            depth++;
            //Console.WriteLine("Depth = {0}", depth);
            // Get current weight
            if (depth <= this._counter) // When depth > _counter, we have completed processing the adjacency tree for a given vertex.
            {
                var visitableItem = visitable.DecideNext;
                //var visitableItem = visitable.AdjacentDirectables
                //    .Where(t => t.Key != visitable.Position); // This filter prevents containing the identity elements.
                foreach (var adjacentVertex in visitableItem)
                {
                    //visitable.AdjacencyDirector.VertexDataProvider.Elements[adjacentVertex.Key].Weight += _counter - depth;
                    var weight = _counter - depth;
                    if (weight > 0) // i.e. There's no point to adding weight unless the weight is above 0
                    {
                        adjacentVertex.Value.Weight += weight;
                    }
                    
                    //Console.WriteLine("adjacentVertex.Key = {0}, weight = {1}, depth = {2}, counter = {3}, visitable.Position = {4}",
                    //    adjacentVertex.Key, adjacentVertex.Value.Weight, depth, _counter, visitable.Position);
                    //foreach (var i in positionQueue)
                    //{
                    //    Console.WriteLine("Position: {0}",i);
                    //}
                    var clone = positionQueue.DeepClone();
                    _positionQueueList.Add(clone);
                    adjacentVertex.Value.Accept(this, depth, clone);
                    
                }
            }
            
        }

        private static void PerformCuts(IAdjacencyDirectableVisitable visitable)
        {
            foreach (var adjacencyDirectableVisitable in visitable.AdjacentChosenElements) // These are elements on the trail.
            {
                if (adjacencyDirectableVisitable.Value.ChosenEdges.Count == 2) // if the element has two edges that are on the trail.
                {
                    foreach (var adjacentUnchosenElement in adjacencyDirectableVisitable.Value.UnchosenEdgesThatDontOrphanTargetVertex)
                    {
                        adjacencyDirectableVisitable.Value.Cut(adjacentUnchosenElement.Value); // Then cut any unused vertex.
                    }
                }
            }
        }

        public List<Queue<Tuple<int, int>>> GetElementsWithWeights(IAdjacencyDirector director)
        {
            var queueList = new List<Queue<Tuple<int, int>>>() { };
                    foreach (var positionQueue in this._positionQueueList)
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
            return queueList;
        }
        public bool DoesCutOrphanVertex(IAdjacencyDirectableVisitable vertex1, IAdjacencyDirectableVisitable vertex2)
        {
            return vertex1.AdjacencyDirector.DoesCutOrphanVertex(vertex1.Position, vertex2.Position);
        }
        public bool DoesCutOrphanVertex(int vertexPosition1, int vertexPosition2, IAdjacencyDirector director)
        {
            return director.DoesCutOrphanVertex(vertexPosition1, vertexPosition2);
        }
        ///// <summary>
        ///// This overloaded method determines which path to take. It also determines if there are any orphans.
        ///// </summary>
        ///// <param name="vertexToProcess"></param>
        ///// <returns></returns>
        //public List<IAdjacencyDirectableVisitable> DetermineWhichVertexToChoose(IAdjacencyDirectableVisitable vertexToProcess)
        //{
        //    return DetermineWhichVertexToChoose(vertexToProcess, null);
        //}
        ///// <summary>
        ///// This method determines which path to take. It also determines if there are any orphans.
        ///// This is the weighting system that only should choose an element if it does not orphan any other vertex.
        ///// So, I need a method that checks if choosing a given vertex will orphan any other vertex (due to the cuts involved).
        ///// This task would be best performed from the vertex, not the visitor!
        ///// </summary>
        ///// <param name="vertexToProcess"></param>
        ///// <param name="chosenVertices"></param>
        ///// <returns></returns>
        //[Obsolete("Warning: Needs to be fixed.")]
        //public List<IAdjacencyDirectableVisitable> DetermineWhichVertexToChoose(IAdjacencyDirectableVisitable vertexToProcess, 
        //    IDictionary<int, IAdjacencyDirectableVisitable> chosenVertices)
        //{
        //    if (chosenVertices == null)
        //    {
        //        chosenVertices = new Dictionary<int, IAdjacencyDirectableVisitable>();
        //    }
        //    var groupedElements = GroupElementsByWeight(vertexToProcess);
        //    //into g
        //    //orderby g.Key ascending

        //    var firstGroup = groupedElements.OrderBy(t => t.Key).FirstOrDefault();
        //    if (firstGroup == null)// We should only need to process the first one if our weights are perfect.
        //    { // We need to cut the appropriate elements and update the weights.
        //        throw new NullReferenceException("firstGroup cannot be null.");
        //    }
        //    var firstUnvisitedGroupList = firstGroup.Except(chosenVertices).ToList();
        //    // We need to inspect the chosenVertices. If we take the list of chosenVertices, we can slice it into two lists of consecutive elements.
        //    // Then, it is clear which vertices need to be cut.
        //    //if (chosenVertices.Count > 1)
        //    //{
        //    //    ?
        //    //    ;
        //    //    // We need a method that takes the chosenVertices, checks for sequences, and cuts unneeded adjacencent vertices.
        //    //}

           
        //    //from p in persons
        //    //  group p.car by p.PersonId into g
        //    //  select new { PersonID = g.Key, Cars = g.ToList() };
        //    var orphanedElements = new List<IAdjacencyDirectableVisitable>();
        //    var nonOrphanedElements = new List<IAdjacencyDirectableVisitable>();
        //    foreach (var adjacentElement in firstUnvisitedGroupList)
        //    {
        //        var doesCutOrphanVertex = this.DoesCutOrphanVertex(vertex1: vertexToProcess, vertex2: adjacentElement.Value);
        //        if (doesCutOrphanVertex)
        //        {
        //            orphanedElements.Add(adjacentElement.Value);
        //        }
        //        else
        //        {
        //            nonOrphanedElements.Add(adjacentElement.Value);
        //        }
        //        // If not true, then we can add this pair to the set of items we can cut: vertexToProcess, adjacentElement.Value
        //    }
            
        //    return vertexToProcess.DecideNext.Values.ToList();

        //}

        private static IEnumerable<IGrouping<int, KeyValuePair<int, IAdjacencyDirectableVisitable>>> GroupElementsByWeight(
            IAdjacencyDirectableVisitable vertexToProcess)
        {
            var director = vertexToProcess.AdjacencyDirector;
            var adjacentElements = vertexToProcess.DirectableList;
            // Filter adjacentElements to only those with equally lowest weight.
            var groupedElements = from e in adjacentElements
                group e by e.Value.Weight;
            return groupedElements;
        }
        ///// <summary>
        ///// I think this method is initially where I intended to perform the cuts. 
        ///// However, at this point, it is not really necessary.
        ///// </summary>
        ///// <param name="vertexToProcess"></param>
        ///// <param name="orphanedElements"></param>
        ///// <returns></returns>
        //[Obsolete("Warning: May not be necessary. Use the methods/properties on VertexNode instead.")]
        //private List<IAdjacencyDirectableVisitable> ProcessOrphanedElements(IAdjacencyDirectableVisitable vertexToProcess, 
        //    List<IAdjacencyDirectableVisitable> orphanedElements)
        //{
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
        //        var doesFirstOrphanCutOrphanAnotherVertex = this.DoesCutOrphanVertex(vertex1: vertexToProcess,
        //            vertex2: firstOrphan);
        //        if (doesFirstOrphanCutOrphanAnotherVertex)
        //        {
        //            throw new OrphanedVertexException("Impossible situation. Too many orphans! ");
        //        }
        //        else
        //        {
        //            return orphanedElements;
        //            //this.Visit(firstOrphan); // Otherwise, visit that orphan.
        //            //DetermineWhichVertexToChoose(firstOrphan); // Then process it.
        //        }
        //    }
        //    return orphanedElements;
        //}

        //public void AlternateProcessing(IAdjacencyDirectableVisitable firstVertex,
        //    IAdjacencyDirectableVisitable secondVertex,
        //    int counter)
        //{

        //}
        ///// <summary>
        ///// This is for the first (external) call to this method. (It calls the other overload with default starting values.)
        ///// </summary>
        ///// <param name="firstVertex"></param>
        ///// <param name="secondVertex"></param>
        //public void AlternateProcessing(IAdjacencyDirectableVisitable firstVertex,
        //    IAdjacencyDirectableVisitable secondVertex)
        //{
        //    AlternateProcessing(firstVertex, secondVertex, new Dictionary<int, IAdjacencyDirectableVisitable>(), 0 );
        //}
        //public void AlternateProcessing(IAdjacencyDirectableVisitable firstVertex,  
        //    IAdjacencyDirectableVisitable secondVertex, 
        //    Dictionary<int, IAdjacencyDirectableVisitable> chosenVertices,
        //    int counter)
        //{
        //    if (chosenVertices == null)
        //    {
        //        chosenVertices = new Dictionary<int, IAdjacencyDirectableVisitable>();
        //    }
            
        //    if (firstVertex != null && secondVertex != null)
        //    {
        //        var pendingVerticesToProcess = new List<IAdjacencyDirectableVisitable>();
        //        counter++;
        //        if (counter % 2 == 0)
        //        {
        //            //if (chosenVertices.Count >= 1)
        //            //{
        //            //    var mostRecentVertex = chosenVertices.Last();
        //            //    if (chosenVertices.Count >= 2)
        //            //    {
        //            //        mostRecentVertex = chosenVertices.Reverse().Skip(1).Take(1).FirstOrDefault();
        //            //    }
        //            //    if (chosenVertices.Count >= 3)
        //            //    {
        //            //        mostRecentVertex = chosenVertices.Reverse().Skip(1).Take(1).FirstOrDefault();
        //            //    }
                        
        //            //    // use this position AND the mostRecentVertexPosition to get the corresponding edge. IT SHOULD EXIST.
        //            //    //      (But what if it was cut?)
        //            //    // We must get the edge and choose it.

        //            //    var visitedEdge = firstVertex.AdjacencyDirector.GetEdgeIncidentToBothVertices(firstVertex.Position, mostRecentVertex.Key);
        //            //    visitedEdge.Choose();
        //            //}
        //            if (!chosenVertices.ContainsKey(firstVertex.Position))
        //            {
        //                chosenVertices.Add(firstVertex.Position, firstVertex);
        //            }
        //            var oddChosenVertices = chosenVertices.ToList().Where((c, i) => i % 2 != 0).ToList();
        //            //var evenChosenVertices = chosenVertices.ToList().Where((c, i) => i % 2 == 0);
        //            // firstVertex IS PART OF oddChosenVertices
        //            if (oddChosenVertices.Count > 1)
        //            {
        //                var mostRecentVertex = oddChosenVertices[oddChosenVertices.Count - 2];
                        
        //                // use this position AND the mostRecentVertexPosition to get the corresponding edge. IT SHOULD EXIST.
        //                //      (But what if it was cut?)
        //                // We must get the edge and choose it.
        //                if (mostRecentVertex.Key != firstVertex.Position)
        //                {
        //                    var visitedEdge = firstVertex.AdjacencyDirector.GetEdgeIncidentToBothVertices(firstVertex.Position, mostRecentVertex.Key);
        //                    visitedEdge.Choose();
        //                }
        //            }
        //            this.Visit(firstVertex);
        //            //nodes = this.DetermineWhichVertexToChoose(firstVertex, chosenVertices).Except(chosenVertices.Select(t => t.Value)).ToList();
        //            // The Except doesn't work yet.
        //            var elementsToProcess = firstVertex.DecideNext.Values;
        //            foreach (var adjacencyDirectableVisitable in elementsToProcess)
        //            {
        //                if (!chosenVertices.ContainsKey(adjacencyDirectableVisitable.Position))
        //                {
        //                    pendingVerticesToProcess.Add(adjacencyDirectableVisitable);
        //                }
        //            }
        //            // How would I run this foreach node in nodes? I would need to snapshot the chosenVertices and pass
        //            //      them in a queue to this method.
        //            foreach (var orphan in pendingVerticesToProcess)
        //            {
        //                AlternateProcessing(orphan, secondVertex, chosenVertices.DeepClone(), counter);
        //            }
        //        }
        //        if (counter % 2 == 1)
        //        {

        //            if (!chosenVertices.ContainsKey(secondVertex.Position)) // Could be replaced with LINQ expression.
        //            {
        //                chosenVertices.Add(secondVertex.Position, secondVertex);
        //            }
        //            //var oddChosenVertices = chosenVertices.ToList().Where((c, i) => i % 2 != 0);
        //            var evenChosenVertices = chosenVertices.ToList().Where((c, i) => i % 2 == 0).ToList();
        //            // secondVertex IS PART OF evenChosenVertices.
        //            if (evenChosenVertices.Count > 1)
        //            {
        //                var mostRecentVertex = evenChosenVertices[evenChosenVertices.Count - 2];
        //                // use this position AND the mostRecentVertexPosition to get the corresponding edge. IT SHOULD EXIST.
        //                //      (But what if it was cut?)
        //                // We must get the edge and choose it.
        //                if (mostRecentVertex.Key != secondVertex.Position)
        //                {
        //                    var visitedEdge = secondVertex.AdjacencyDirector.GetEdgeIncidentToBothVertices(secondVertex.Position, mostRecentVertex.Key);
        //                    visitedEdge.Choose();
        //                }
                        
        //            }
        //            this.Visit(secondVertex);
        //            var orphanedElements = secondVertex.DecideNext.Values;
        //            //if (orphanedElements.Any())
        //            //{
        //            //    ProcessOrphanedElements(secondVertex, orphanedElements.ToList());
        //            //}
        //            //else
        //            //{
        //            //    var firstUnvisitedGroupList = GroupElementsByWeight(secondVertex);
        //            //    //vertexList = firstUnvisitedGroupList.Select(t => t.Value).ToList(); 
        //            //}

        //            foreach (var adjacencyDirectableVisitable in orphanedElements) // Could be replaced with LINQ Except expression.
        //            {
        //                if (!chosenVertices.ContainsKey(adjacencyDirectableVisitable.Position))
        //                {
        //                    pendingVerticesToProcess.Add(adjacencyDirectableVisitable);
        //                }
        //            }
        //            foreach (var nextVertex in pendingVerticesToProcess)
        //            {
        //                AlternateProcessing(firstVertex, nextVertex, chosenVertices.DeepClone(), counter);
        //            }
        //        }
        //    }
        //    if (firstVertex != null)
        //    {
        //        if (firstVertex.Position == 3)
        //        {
        //            Console.Write("?");
        //        } 
        //    }
            
        //    foreach (var adjacencyDirectableVisitable in chosenVertices)
        //    {
        //        Console.Write(adjacencyDirectableVisitable.Key + ", ");
        //    }
        //    Console.WriteLine();
        //}

        public void Walk(
            IAdjacencyDirectableVisitable originVertex)
        {
            var manTrail = new List<IAdjacencyDirectableVisitable>();
            var womanTrail = new List<IAdjacencyDirectableVisitable>();

            Walk(originVertex, originVertex, originVertex, manTrail, womanTrail, FirstStepTaken.No, 0);
        }
        public void Walk(
            IAdjacencyDirectableVisitable originVertex,
            IAdjacencyDirectableVisitable manCurrentVertex,
            IAdjacencyDirectableVisitable womanCurrentVertex,
            List<IAdjacencyDirectableVisitable> manTrail,
            List<IAdjacencyDirectableVisitable> womanTrail,
            FirstStepTaken firstStepTaken,
            int depth)
        {
            depth++;
            if (firstStepTaken == FirstStepTaken.No)
            {
                // Then take first step.
                var firstStepVertices = originVertex.DecideNext.ToList();
                var marriageList = new List<Tuple<IAdjacencyDirectableVisitable, IAdjacencyDirectableVisitable>>();
                for (int i = 0; i < firstStepVertices.Count - 1; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        var man = firstStepVertices[i].Value;
                        var woman = firstStepVertices[j].Value;
                        if (man.Position != woman.Position)
                        {
                            var marriage = new Tuple<IAdjacencyDirectableVisitable, 
                                IAdjacencyDirectableVisitable>(
                                    man,
                                    woman);
                            marriageList.Add(marriage);
                        }
                        foreach (var marriage in marriageList)
                        {
                            var manCopy = marriage.Item1.DeepClone();
                            var womanCopy = marriage.Item2.DeepClone();
                            var originVertexCopy = originVertex.DeepClone();
                            manCopy.Deregister(); // will this line screw everything up for the other objects? Not if we use a clone.
                            womanCopy.Deregister();
                            originVertexCopy.AdjacencyDirector.Register(manCopy);
                            originVertexCopy.AdjacencyDirector.Register(womanCopy);
                            manTrail.Add(manCopy);
                            womanTrail.Add(womanCopy);
                            // create a method that allows me to 
                            Visit(originVertexCopy);
                            Visit(manCopy);
                            Visit(womanCopy);

                            var manEdge = originVertexCopy.AdjacencyDirector.GetEdgeIncidentToBothVertices(manCopy.Position,
                                originVertexCopy.Position);
                            manEdge.Choose();

                            var womanEdge = originVertexCopy.AdjacencyDirector.GetEdgeIncidentToBothVertices(womanCopy.Position,
                                originVertexCopy.Position);
                            womanEdge.Choose();

                            Walk( originVertexCopy, manCopy, womanCopy, manTrail, womanTrail, FirstStepTaken.Yes, depth);
                        }
                    }
                }
                // marriageList should contain all unique pairs.

            }
            if (firstStepTaken == FirstStepTaken.Yes)
            {
                if (manTrail.Count >= 9)
                {
                    Console.Write("Check");
                }
                // Here is where we perform any cuts.
                var manAdjacentVertices = manCurrentVertex.UnchosenEdgesThatDontOrphanTargetVertex.ToList();
                var womanAdjacentVertices = womanCurrentVertex.UnchosenEdgesThatDontOrphanTargetVertex.ToList();
                var marriageList = new List<Tuple<IAdjacencyDirectableVisitable, IAdjacencyDirectableVisitable>>();
                marriageList.Clear();
                for (int i = 0; i < manAdjacentVertices.Count; i++)
                {
                    for (int j = 0; j < womanAdjacentVertices.Count; j++)
                    {
                        var man = manAdjacentVertices[i].Value;
                        var woman = womanAdjacentVertices[j].Value;
                        if (man.Position != woman.Position)
                        {
                            var manTrailContainsMan = manTrail.Any(t => t.Position == man.Position);
                            var womanTrailContainsWoman = womanTrail.Any(t => t.Position == woman.Position);
                            var manTrailContainsWoman = manTrail.Any(t => t.Position == woman.Position);
                            var womanTrailContainsMan = womanTrail.Any(t => t.Position == man.Position);
                            if (!manTrailContainsMan && !womanTrailContainsWoman && !manTrailContainsWoman && !womanTrailContainsMan)
                            {
                                var marriage = new Tuple<IAdjacencyDirectableVisitable,
                                    IAdjacencyDirectableVisitable>(
                                    man,
                                    woman);
                                marriageList.Add(marriage);
                            }
                        }
                        else // In this case, because both man and woman have reached the same vertex, we have the closure of a cycle.
                        {
                            Console.WriteLine("Closure on vertex {0}", man.Position); // note: man.Position == woman.Position in this case.
                            // Then we should write the members of the two trails to the console, like this:
                                // womanTrailReverse = womanTrail.Reverse();
                                    // originVertex, manTrail[0], manTrail[1], ..., manTrail[n], man.Position, womanTrailReverse[0], womanTrailReverse[1], ...,
                                    // womanTrailReverse[m].
                            //WritePathIDToConsole(originVertex, manTrail, womanTrail, man);
                            WritePathIDToConsoleFaster(originVertex, manTrail, womanTrail, man);
                        }
                    }
                }
                //foreach (var marriage in marriageList)
                //{
                    
                
                Parallel.ForEach(marriageList, marriage =>
                {
                    var manTrailCopy = manTrail.DeepClone();
                        // We must clone the trail here in the foreach loop to ensure we operate on the correct values.
                    var womanTrailCopy = womanTrail.DeepClone();
                    var man = marriage.Item1;
                    var woman = marriage.Item2;
                    var manTrailContainsMan = manTrailCopy.Any(t => t.Position == man.Position);
                    var womanTrailContainsWoman = womanTrailCopy.Any(t => t.Position == woman.Position);
                    var manTrailContainsWoman = manTrailCopy.Any(t => t.Position == woman.Position);
                    var womanTrailContainsMan = womanTrailCopy.Any(t => t.Position == man.Position);
                    if (!manTrailContainsMan && !womanTrailContainsWoman && !manTrailContainsWoman &&
                        !womanTrailContainsMan)
                    {
                        var manCopy = marriage.Item1.DeepClone();
                        var womanCopy = marriage.Item2.DeepClone();
                        var originVertexCopy = originVertex.DeepClone();
                        manCopy.Deregister();
                        // will this line screw everything up for the other objects? Not if we use a clone.
                        womanCopy.Deregister();
                        originVertexCopy.AdjacencyDirector.Register(manCopy);
                        originVertexCopy.AdjacencyDirector.Register(womanCopy);
                        manTrailCopy.Add(manCopy);
                        womanTrailCopy.Add(womanCopy);
                        // create a method that allows me to 
                        //Visit(originVertexCopy);
                        // Using the director on originVertexCopy, I need to get the edge between
                        //      manCopy and the most recent item in manTrail
                        // I need to either cut or choose.
                        var previousMan = manTrailCopy[manTrailCopy.Count - 2];
                        var previousWoman = womanTrailCopy[womanTrailCopy.Count - 2];

                        var manEdge = originVertexCopy.AdjacencyDirector.GetEdgeIncidentToBothVertices(manCopy.Position,
                            previousMan.Position);
                        manEdge.Choose();
                        var womanEdge =
                            originVertexCopy.AdjacencyDirector.GetEdgeIncidentToBothVertices(womanCopy.Position,
                                previousWoman.Position);
                        womanEdge.Choose();

                        previousMan.Deregister();
                        // I must reregister previousMan and previousWoman to use the originVertexCopy.AdjacencyDirector
                        originVertexCopy.AdjacencyDirector.Register(previousMan);
                        //      to ensure that queries/cuts performed by previousMan/previousWoman affect the correct data.
                        previousWoman.Deregister();
                        originVertexCopy.AdjacencyDirector.Register(previousWoman);

                        // I need to determine which edges to cut.
                        // I can get the vertices that previousMan is adjacent to, filter them to the ones that do not have a chosen edge,
                        // At this moment, the visitor's Visit(..) method is responsible for performing cuts.
                        //previousMan.ChosenEdges
                        //    previousMan.UnchosenEdgesThatDontOrphanTargetVertex

                        // Once a vertex is incident to two chosen edges, then any remaining unchosen edges may be cut.
                        var previousManElementsToCut = previousMan.UnchosenEdgesWithUnchosenVertices;

                        // and cut those edges. (This works

                        Visit(manCopy);
                        Visit(womanCopy);
                        //var finalPositionsAreAdjacent = originVertexCopy.AdjacencyDirector.AdjacencyProvider.AreVerticesBothAdjacent(
                        //      manCopy.Position, womanCopy.Position);
                        //if (finalPositionsAreAdjacent)
                        //{
                        //    Console.Write("Yay!");
                        //}
                        ////Console.WriteLine("Control returned, counts are: {0} and {1}", manTrailCopy.Count,
                        //// womanTrailCopy.Count);
                        //var sb = new StringBuilder();
                        //sb.AppendLine("Men are: ");
                        //foreach (var manElement in manTrailCopy)
                        //{
                        //    sb.Append(manElement.Position + ", ");
                        //}
                        //sb.Append(" Women are: ");
                        //foreach (var womanElement in womanTrailCopy)
                        //{
                        //    sb.Append(womanElement.Position + ", ");
                        //}
                        //Console.WriteLine(sb.ToString());
                        //if (manTrailCopy.Count >= 9)
                        //{
                        //    var finalPositionsAreAdjacent = originVertexCopy.AdjacencyDirector.AdjacencyProvider.AreVerticesBothAdjacent(
                        //       manCopy.Position, womanCopy.Position);
                        //    if (finalPositionsAreAdjacent)
                        //    {
                        //        Console.Write("Yay!");
                        //    }
                        //    //Console.WriteLine("Control returned, counts are: {0} and {1}", manTrailCopy.Count,
                        //    // womanTrailCopy.Count);
                        //    var sb = new StringBuilder();
                        //    sb.AppendLine("Men are: ");
                        //    foreach (var manElement in manTrailCopy)
                        //    {
                        //        sb.Append(manElement.Position + ", ");
                        //    }
                        //    sb.Append(" Women are: ");
                        //    foreach (var womanElement in womanTrailCopy)
                        //    {
                        //        sb.Append(womanElement.Position + ", ");
                        //    }
                        //    Console.WriteLine(sb.ToString());
                        //    // It would be good to check which of these have the last two vertices as adjacent.
                        //}
                        Walk(originVertexCopy, manCopy, womanCopy, manTrailCopy, womanTrailCopy, FirstStepTaken.Yes,
                            depth);
                        
                        //Console.WriteLine("Control returned, counts are: {0} and {1}", manTrailCopy.Count,
                        //    womanTrailCopy.Count);
                    }
                });
                //}
            }
        }
        //private static string ConstructPathID(IAdjacencyDirectableVisitable originVertex,
        //    List<IAdjacencyDirectableVisitable> manTrail, List<IAdjacencyDirectableVisitable> womanTrail,
        //    IAdjacencyDirectableVisitable man)
        //{
        //    var womanTrailPositions = womanTrail.Select(t => t.Position);
        //    var womanTrailReverse = womanTrailPositions.Reverse();
        //    var allPositions = new List<int>((manTrail.Count + womanTrail.Count) * 3);
        //    allPositions.Add(originVertex.Position);
        //    foreach (var manItem in manTrail)
        //    {
        //        allPositions.Add(manItem.Position);
        //    }
        //    allPositions.Add(man.Position);
        //    foreach (var womanPosition in womanTrailReverse) // skip the first because it should be the same as the last man.
        //    {
        //        allPositions.Add(womanPosition);
        //    }

        //    var sb = new StringBuilder((manTrail.Count + womanTrail.Count) * 3);
        //    foreach (var item in allPositions)
        //    {
        //        sb.Append(item + ", ");
        //    }
        //    sb.Append(originVertex);
        //}
        private static void WritePathIDToConsoleFaster(IAdjacencyDirectableVisitable originVertex, List<IAdjacencyDirectableVisitable> manTrail, List<IAdjacencyDirectableVisitable> womanTrail,
            IAdjacencyDirectableVisitable man)
        {
            var womanTrailPositions = womanTrail.Select(t => t.Position);
            var womanTrailReverse = womanTrailPositions.Reverse();
            var sb = new StringBuilder((manTrail.Count + womanTrail.Count) * 3);
            sb.Append(originVertex.Position + ", ");
            foreach (var manItem in manTrail)
            {
                sb.Append(manItem.Position + ", ");
            }
            sb.Append(man.Position + ", ");
            foreach (var womanPosition in womanTrailReverse) // skip the first because it should be the same as the last man.
            {
                sb.Append(womanPosition + ", ");
            }
            sb.Append(originVertex.Position);
            Console.WriteLine(sb.ToString());
        }

       
        public enum FirstStepTaken
        {
            Yes,
            No
        }
    }
    
}