using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Nucleotide_v2.Deprecated;
using Nucleotide_v2.Direct;
using Nucleotide_v2.Exceptions;
using Nucleotide_v2.Factory;
using Nucleotide_v2.Visit;

namespace Nucleotide_v2
{
    [Serializable]
    [DebuggerDisplay("Position={Position}, Value={Value}, Weight={Weight}")]
    public class VertexNode<T> : Node<T>, IAdjacencyDirectableVisitable, IEquatable<VertexNode<T>>, IChoosable
    {
        //private NodeFactory<T> edgeFactory;
        //private SynchronizedCollection<VertexNode<T>> _adjacentVertices;
        //private SynchronizedCollection<EdgeNode<T>> _incidentEdges;
        // From a given vertex, I need to be able to efficiently generate an AdjacencyTree.
        public VertexNode(int position)
        {
            this.Chosen = false;
            this.Position = position;
        }
        public VertexNode(T value, int position)
        {
            this.Chosen = false;
            this.Value = value;
            this.Position = position;
        }
        public VertexNode(T value, int position, IAdjacencyDirector director)
        {
            this.Chosen = false;
            this.Value = value;
            this.Position = position;
            if (director == null)
            {
                throw new NullReferenceException("Director cannot be null when constructing VertexNode!");
            }
            this.AdjacencyDirector = director;
            this.AdjacencyDirector.Register(this);
        }
        public IDictionary<int, IAdjacencyDirectableVisitable> AdjacentVertices(IAdjacencyDirector director)
        {
            var elements = director.RequestAdjacentElements(this.Position);
            var convertedElements = elements.Select(t => ((VertexNode<T>)t.Value).ToVisitable).ToDictionary(t => t.Position, t => t);
            return convertedElements;
        }

        public IAdjacencyDirectableVisitable ToVisitable
        {
            get
            {
                var castElement = (IAdjacencyDirectableVisitable)this;
                return castElement;
            }
        }

        // Should the vertex know of its position in the matrix?
        /// <summary>
        /// Come to think of it, I should be able to construct the list of incident edges from my AdjacentVertices.
        /// For each item in AdjacentVertices, I can call a factory method.
        /// This implies that the factory needs to be either provided to the vertex as a method or constructor parameter.
        /// If the factory is a singleton, then all of my vertices will be referencing the same instance of the factory.
        /// This could make it easier to keep track of the objects.
        /// </summary>
        //public SynchronizedCollection<EdgeNode<T>> IncidentEdges
        //{
        //    get
        //    {
        //        if (_incidentEdges != null)
        //        {
        //            return _incidentEdges;
        //        }
        //        else
        //        {
        //            foreach (var adjacentVertex in AdjacentVertices)
        //            {

        //            }
        //            _incidentEdges = edgeFactory.CreateNode(this, adjacentVertex);
        //            return _incidentEdges;
        //        }
        //    }
        //    set { _incidentEdges = value; }
        //}
        
        // Each vertex should be constructed with the list of vertices it is adjacent to.
        // From the list of these, we should be able to construct the adjacency matrix?
        public void Accept(IVertexNodeVisitor visitor, int depth, Queue<int> positionQueue)
        {
            // Perhaps this is where we need to raise an event here to indicate that the vertex has indeed been visited.
            visitor.Visit(this, depth, positionQueue);
            //throw new NotImplementedException();
        }
        /// <summary>
        /// I could use an event instead here perhaps.
        /// </summary>
        public bool Chosen { get; set; }
        /// <summary>
        /// This method allows us to perform cuts on vertices on our path once they have two adjacent chosen elements.
        /// The vertices that are cut are only the ones that do not create orphans. Therefore,
        /// this method only works sufficiently for graphs that are hamiltonian for all vertices.
        /// For non-hamiltonian graphs, we would need to improve this method.
        /// </summary>
        public void Choose()
        {
            
            this.Chosen = true;
            // Once this VertexNode is chosen, its AdjacentChosenElements need to be checked because if any of them
            // now have AdjacentChosenElements.Count == 2, then their AdjacentUnchosenElements can be cut.
            // they may 
            foreach (var adjacentChosenElement in AdjacentChosenElements)
            {
                if (adjacentChosenElement.Value.HasTwoAdjacentChosenElements)
                {
                    adjacentChosenElement.Value.CutAllAdjacentUnchosenElementsThatDoNotOrphanTarget();
                }
                
            }
        }

        public List<int> IncidentEdgePositions
        {
            get { return this.AdjacencyDirector.GetIncidentEdges(this.Position); }
        }
        public List<EdgeNode> IncidentEdgeNodes
        {
            get
            {
                return AdjacencyDirector.GetIncidentEdgeElements(this.Position);
            }
        }
        /// <summary>
        /// Note: If an edge is chosen, then its corresponding vertices MUST also be chosen. If not, then we have an exceptional case.
        /// </summary>
        /// <param name="vertexPosition1"></param>
        /// <param name="vertexPosition2"></param>
        /// <returns></returns>
        public bool IsEdgeChosen(int vertexPosition1, int vertexPosition2)
        {
            var incidentEdge = this.AdjacencyDirector.GetEdgeIncidentToBothVertices(vertexPosition1, vertexPosition2);
            return incidentEdge.Chosen;
        }
        public bool IsEdgeChosen(IAdjacencyDirectableVisitable vertex1, IAdjacencyDirectableVisitable vertex2)
        {
            var incidentEdgeResult = IsEdgeChosen(vertex1.Position, vertex2.Position);
            if (incidentEdgeResult)
            {
                //if (!vertex1.Chosen || !vertex2.Chosen)
                //{
                //    throw new ChosenException(vertex1.Position, vertex2.Position, "Check VertexNode's IsEdgeChosen(..) method.");
                //}
            }
            return incidentEdgeResult;
        }
        public bool HasTwoAdjacentChosenElements
        {
            get { return AdjacentChosenElements.Count == 2; }
        }
        /// <summary>
        /// Vertices can be adjacent and chosen if both vertices are chosen, even if the edge between them is not chosen.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> AdjacentChosenElements
        {
            get
            {
                var elements = DirectableList.Where(t => t.Value.Chosen == true )
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        /// <summary>
        /// Vertices are incident and chosen when they are adjacent and chosen and share an edge that is chosen.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> IncidentChosenElements
        {
            get
            {
                var elements = DirectableList.Where(t => t.Value.Chosen == true && IsEdgeChosen(t.Value, this))
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        /// <summary>
        /// These are vertices that were cut.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> UnchosenEdgesWithUnchosenVertices
        {
            get
            {
                var elements = DirectableList.Where(t => t.Value.Chosen == false && !IsEdgeChosen(t.Value, this))
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        /// <summary>
        /// These are the edges that we want to cut when this vertex already is incident to two chosen edges.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> UnchosenEdgesThatDontOrphanTargetVertex
        {
            get
            {
                var elements = DirectableList.Where(t => !IsEdgeChosen(t.Value, this) && !this.DoesCutOrphanVertex(t.Value))
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        public IDictionary<int, IAdjacencyDirectableVisitable> ChosenEdges
        {
            get
            {
                var elements = DirectableList.Where(t => IsEdgeChosen(t.Value, this) )
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        /// <summary>
        /// These can also often be safely cut.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> UnchosenEdgesWithChosenVertices
        {
            get
            {
                var elements = DirectableList.Where(t => t.Value.Chosen == true && !IsEdgeChosen(t.Value, this))
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        public IDictionary<int, IAdjacencyDirectableVisitable> ChosenEdgesWithChosenVertices
        {
            get
            {
                var elements = DirectableList.Where(t => t.Value.Chosen == true && IsEdgeChosen(t.Value, this))
                    .ToDictionary(t => t.Key, t => t.Value);

                return elements;
            }
        }
        /// <summary>
        /// These are the adjacent elements (to this VertexNode) that have not yet been chosen.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> AdjacentUnchosenElements
        {
            get { return DirectableList.Where(t => t.Value.Chosen == false).ToDictionary(t => t.Key, t => t.Value); }
        }

        public IDictionary<int, IAdjacencyDirectableVisitable>
            AdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight
        {
            get
            {
                var lowestWeight = LowestWeightItemAmongAdjacentUnchosenElementsThatOrphanTarget;
                return
                    AdjacentUnchosenElementsThatOrphanTarget.Where(t => t.Value.Weight == lowestWeight)
                        .ToDictionary(t => t.Key, t => t.Value);
            }
        }
        public IDictionary<int, IAdjacencyDirectableVisitable>
            mAdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight(IDictionary<int,IAdjacencyDirectableVisitable> adjacentElements )
        {
            var lowestWeight = mLowestWeightItemAmongAdjacentUnchosenElementsThatOrphanTarget(adjacentElements);
                return
                    mAdjacentUnchosenElementsThatOrphanTarget(adjacentElements).Where(t => t.Value.Weight == lowestWeight)
                        .ToDictionary(t => t.Key, t => t.Value);
            
        }
        public IDictionary<int, IAdjacencyDirectableVisitable>
            AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight
        {
            get
            {
                var lowestWeight = LowestWeightItemAmongAdjacentUnchosenElementsThatDoNotOrphanTarget;
                return
                    AdjacentUnchosenElementsThatDoNotOrphanTarget.Where(t => t.Value.Weight == lowestWeight)
                        .ToDictionary(t => t.Key, t => t.Value);
            }
        }

        public bool MoreThanOneEquallyValidDecisionExists
        {
            get
            {
                if (!AdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight.Any())
                {
                    if (AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight.Count > 1)
                    {
                        // Then we have more than one equally valid decision.
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// This is the property that gets the values that consider which vertices will be affected by cuts and which ones should be chosen
        /// first (due to resulting orphans if not chosen and also due to equally lowest weight). It is independent of any metric used 
        /// for computing the weight values for vertices.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> DecideNext
        {
            get
            {
                if (AdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight.Count == 1)
                {
                    var item = AdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight.FirstOrDefault().Value;
                    var dict = new Dictionary<int, IAdjacencyDirectableVisitable> { { item.Position, item } };
                    return dict;
                }
                if (AdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight.Count > 1)
                {
                   // throw new OrphanedVertexException("Too many orphaned vertices exist for this graph to be hamiltonian!");
                }
                if (!AdjacentUnchosenElementsThatOrphanTargetWithEquallyLowestWeight.Any())
                {
                    // Then check those that don't orphan the target.
                    if (!AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight.Any())
                    {
                        throw new Exception("We are done!!!");
                    }
                    if (AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight.Count == 1)
                    {
                        //var item = AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight.FirstOrDefault().Value;
                        //var dict = new Dictionary<int, IAdjacencyDirectableVisitable> { { item.Position, item } };
                        //return dict;
                        return AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight;
                    }
                    if (AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight.Count > 1)
                    {
                        // Then we have more than one equally valid decision.
                        // Then what we can do is check if the count of DecideNext() is > 1. This will tell us if there were junctions.
                        return AdjacentUnchosenElementsThatDoNotOrphanTargetWithEquallyLowestWeight;
                    }
                }
                //throw new Exception("Not sure what to do. Can't decide on vertices because something went wrong in logic. Check VertexNode's DecideNext() method.");
             return new Dictionary<int, IAdjacencyDirectableVisitable>();
            }
        }
        
        public int LowestWeightItemAmongAdjacentUnchosenElementsThatOrphanTarget
        {
            get
            {
                var item = AdjacentUnchosenElementsThatOrphanTarget.OrderBy(t => t.Value.Weight).FirstOrDefault().Value;
                if (item == null)
                {
                    return -1;
                }
                return item.Weight;
            }
        }
        public int mLowestWeightItemAmongAdjacentUnchosenElementsThatOrphanTarget(IDictionary<int, IAdjacencyDirectableVisitable> adjacentElements)
        {
           var item = mAdjacentUnchosenElementsThatOrphanTarget(adjacentElements).OrderBy(t => t.Value.Weight).FirstOrDefault().Value;
                if (item == null)
                {
                    return -1;
                }
                return item.Weight;
            
        }
        public int LowestWeightItemAmongAdjacentUnchosenElementsThatDoNotOrphanTarget
        {
            get
            {
                var item = AdjacentUnchosenElementsThatDoNotOrphanTarget.OrderBy(t => t.Value.Weight).FirstOrDefault().Value;
                if (item == null)
                {
                    return -1;
                }
                return item.Weight;
            }
        }
        /// <summary>
        /// These are the adjacent elements (to this VertexNode) that have not yet been chosen but if
        /// cut, they will orphan their Target vertex. (This VertexNode instance is considered the Source vertex.)
        /// The purpose of this method is to determine which vertices CANNOT be safely cut without destroying the graph's 
        /// hamiltonicity (by creating vertices that are only adjacent to a single edge).
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> AdjacentUnchosenElementsThatOrphanTarget
        {
            get
            {
                return DirectableList.Where(t => t.Value.Chosen == false && this.DoesCutOrphanVertex(t.Value))
                    .ToDictionary(t => t.Key, t => t.Value);
            }
        }
        public IDictionary<int, IAdjacencyDirectableVisitable> mAdjacentUnchosenElementsThatOrphanTarget(IDictionary<int,IAdjacencyDirectableVisitable> adjacentElements )
        {
            return adjacentElements.Where(t => t.Value.Chosen == false && this.DoesCutOrphanVertex(t.Value))
                    .ToDictionary(t => t.Key, t => t.Value);
            
        }
        /// <summary>
        /// These are the vertices that can be safely cut.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> AdjacentUnchosenElementsThatDoNotOrphanTarget
        {
            get
            {
                return DirectableList.Where(t => t.Value.Chosen == false && !this.DoesCutOrphanVertex(t.Value))
                    .ToDictionary(t => t.Key, t => t.Value);
            }
        }

        
        public void CutAllAdjacentUnchosenElementsThatDoNotOrphanTarget()
        {
            foreach (var adjacencyDirectableVisitable in AdjacentUnchosenElementsThatDoNotOrphanTarget)
            {
                this.Cut(adjacencyDirectableVisitable.Value);
            }
        }
     
        /// <summary>
        /// This property represents the adjacent elements of this vertex.
        /// </summary>
        public IDictionary<int, IAdjacencyDirectableVisitable> DirectableList
        {
            get { return this.AdjacencyDirector.RequestAdjacentElements(this.Position); }
        }

        public void Register(IAdjacencyDirector director)
        {
            director.Register(this);
        }

        public void Cut(IAdjacencyDirectableVisitable adjacentVertexToCut)
        {
            adjacentVertexToCut.Weight -= this.Weight;
            if (adjacentVertexToCut.Weight < 0)
            {
                throw new AdjacencyException("The weight calculation is not valid! (Weight cannot be negative.)");
            }
            this.AdjacencyDirector.Cut(this.Position, adjacentVertexToCut.Position);
        }
        public IAdjacencyDirector AdjacencyDirector { get; set; }


        public IDictionary<int, IAdjacencyDirectableVisitable> AdjacentDirectables
        {
            get { return this.AdjacencyDirector.RequestAdjacentElements(this.Position); }
        }

        public IDictionary<int, IAdjacencyDirectableVisitable> RequestAdjacentDirectables(int initialPosition)
        {
            return this.AdjacencyDirector.RequestAdjacentElements(initialPosition);
        }

        public IDictionary<int, IAdjacencyDirectableVisitable> RequestDirectables(IAdjacencyDirector director)
        {
            return director.DirectableList;
        }
        public bool DoesCutOrphanVertex(IAdjacencyDirectableVisitable vertexTarget)
        {
            return this.AdjacencyDirector.DoesCutOrphanVertex(this.Position, vertexTarget.Position);
        }

        public void Deregister()
        {
            this.AdjacencyDirector.Deregister(this);
        }

        public bool DoesCutOrphanVertex(int vertexTargetPosition)
        {
            return this.AdjacencyDirector.DoesCutOrphanVertex(this.Position, vertexTargetPosition);
        }
        public bool Equals(VertexNode<T> other)
        {
            if (this.Position.Equals(other.Position))
            {
                if (this.Value.Equals(other.Value))
                {
                    return true;
                    //if (this.Weight.Equals(other.Weight))
                    //{
                    //    return true;
                    //}
                    //return false;
                }
                return false;
            }
            return false;
        }

        
    }
}