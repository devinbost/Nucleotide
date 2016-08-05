using System;
using System.Collections.Generic;
using System.Linq;
using Nucleotide_v3.States;

namespace Nucleotide_v3.Model
{
    [Serializable]
    public class NodeStateContextContainerFacade<E,V> where E : EdgeNodeStateContext, new() where V:VertexNodeStateContext, new()
    {
        protected internal EdgeNodeStateContextContainer<E> EdgeNodeStateContextContainer { get; set; }
        protected internal VertexNodeStateContextContainer<V> VertexNodeStateContextContainer { get; set; }
        //NodeStateContextContainerFacade Copy<T>(NodeStateContextContainerFactory<T>)
        public NodeStateContextContainerFacade()
        {
            EdgeNodeStateContextContainer = new EdgeNodeStateContextContainer<E>();
            VertexNodeStateContextContainer = new VertexNodeStateContextContainer<V>();
        }
        public NodeStateContextContainerFacade(EdgeNodeStateContextContainer<E> edgeNodeStateContextContainer,
            VertexNodeStateContextContainer<V> vertexNodeStateContextContainer)
        {
            EdgeNodeStateContextContainer = edgeNodeStateContextContainer;
            VertexNodeStateContextContainer = vertexNodeStateContextContainer;
        }
        //public NodeStateContextContainerFacade Copy()
        //{
        //    var edgeContainerCopy = EdgeNodeStateContextContainer.Copy();
        //    var vertexContainerCopy = VertexNodeStateContextContainer.Copy();
        //    var facadeCopy = new NodeStateContextContainerFacade(edgeContainerCopy, vertexContainerCopy);
        //}
        //public IEnumerable<EdgeNodeStateContext> GetEdgeNodeStateContexts(EdgeNodeState edgeNodeState)
        //{
        //    var states = this.EdgeNodeStateContextContainer.GetNodesWithState(edgeNodeState).Select(t => t as EdgeNodeStateContext).Where(item => item != null);
        //    return states;
        //}
        //public IEnumerable<VertexNodeStateContext> GetVertexNodeStateContexts(VertexNodeState vertexNodeState)
        //{
        //    var states = this.VertexNodeStateContextContainer.GetNodesWithState(vertexNodeState).Select(t => t as VertexNodeStateContext).Where(item => item != null);
        //    return states;
        //}
        protected internal Dictionary<int, E> EdgeNodeStateContexts
        {
            get { return this.EdgeNodeStateContextContainer.Values; }
        }
        protected internal Dictionary<int, V> VertexNodeStateContexts
        {
            get { return this.VertexNodeStateContextContainer.Values; }
        }
        public IEnumerable<E> GetEdgeNodesWithState(EdgeNodeState edgeNodeState)
        {
            return this.EdgeNodeStateContextContainer.GetEdgeNodesWithState(edgeNodeState);
        }
        public IEnumerable<V> GetVertexNodesWithState(VertexNodeState edgeNodeState)
        {
            return this.VertexNodeStateContextContainer.GetVertexNodesWithState(edgeNodeState);
        }

        public V GetVertexNodeStateContextByPosition(int vertexPosition)
        {
            return this.VertexNodeStateContextContainer.GetNodeByPosition(vertexPosition);
        }
        public E GetEdgeNodeStateContextByPosition(int edgePosition)
        {
            return this.EdgeNodeStateContextContainer.GetNodeByPosition(edgePosition);
        }

        protected internal virtual void AddVertex(int vertexPosition, VertexNodeStateContextFactory<V> factory)
        {
            this.VertexNodeStateContextContainer.Add(vertexPosition, factory.ConstructDefaultNodeContext(vertexPosition));
        }
        protected internal virtual void AddVertex(int vertexPosition, int vertexValue, int vertexClause, VertexNodeStateContextFactory<V> factory)
        {
            var context = factory.ConstructDefaultNodeContext(vertexPosition);
            context.Node.Value = vertexValue;
            context.Node.Clause = vertexClause;
            this.VertexNodeStateContextContainer.Add(vertexPosition, context);
        }
        protected internal virtual void AddEdge(int edgePosition, EdgeNodeStateContextFactory<E> factory)
        {
            this.EdgeNodeStateContextContainer.Add(edgePosition, factory.ConstructDefaultNodeContext(edgePosition));
        }
        /// <summary>
        /// This method is useful for performance optimizations because we can perform construction of the context 
        /// (via the factory) outside of when we need to set a lock on the NodeStateContextContainerFacade.
        /// </summary>
        /// <param name="edgePosition"></param>
        /// <param name="edgeNodeStateContext"></param>
        protected internal virtual void AddEdge(int edgePosition, E edgeNodeStateContext)
        {
            this.EdgeNodeStateContextContainer.Add(edgePosition, edgeNodeStateContext);
        }
        public NodeStateContextContainerFacade<E,V> Copy(
            NodeStateContextContainerFacadeFlyweightFactory<E,V> flyweightFactory)
        {
            return flyweightFactory.Copy(this);
        }
        public virtual void ChooseEdgeAsMale(E context)
        {
            this.EdgeNodeStateContextContainer.ChooseAsMale(context);
        }

        public virtual void ChooseEdgeAsFemale(E context)
        {
            this.EdgeNodeStateContextContainer.ChooseAsFemale(context);
        }
        public virtual void ResetEdge(E context)
        {
            this.EdgeNodeStateContextContainer.Reset(context);
        }

        public virtual void CutEdge(E context)
        {
            this.EdgeNodeStateContextContainer.Cut(context);
        }
        
    //
        public virtual void ChooseVertexAsMale(V context)
        {
            this.VertexNodeStateContextContainer.ChooseAsMale(context);
        }
        public virtual void ChooseVertexAsFemale(V context)
        {
            this.VertexNodeStateContextContainer.ChooseAsFemale(context);
        }
        public virtual void ChooseVertexAsOrigin(V context)
        {
            this.VertexNodeStateContextContainer.ChooseAsOrigin(context);
        }
        public virtual void ResetVertex(V context)
        {
            this.VertexNodeStateContextContainer.Reset(context);
        }

        public virtual void CutVertex(V context)
        {
            throw new System.NotImplementedException();
            //this.VertexNodeStateContextContainer.Cut(context);
        }
    }
}