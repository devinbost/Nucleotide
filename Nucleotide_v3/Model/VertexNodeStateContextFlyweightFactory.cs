using System.Collections.Generic;
using Nucleotide_v3.States;

namespace Nucleotide_v3.Model
{
    public class VertexNodeStateContextFlyweightFactory<V> : VertexNodeStateContextFactory<V> where V : VertexNodeStateContext, new()
    {
        /// <summary>
        /// Note: The outer dictionary's key is the vertexNodeStateContexts's vertexNode's position.
        /// The inner dictionary key is the state object's hashcode. 
        /// </summary>
        public Dictionary<int, Dictionary<int, V>> NodeStateContextCache { get; set; }

        private static volatile VertexNodeStateContextFlyweightFactory<V> _instance = null;

        private VertexNodeStateContextFlyweightFactory() // private to defeat construction
        {
            this.NodeStateContextCache = new Dictionary<int, Dictionary<int,V>>();
        }

        public static VertexNodeStateContextFlyweightFactory<V> GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VertexNodeStateContextFlyweightFactory<V>();
                }
                return _instance;
            }
        }

        public override V ConstructNodeContext<N>(int nodePosition, NodeState nodeState, NodeFactory<N> nodeFactory)
        {
            lock (this.NodeStateContextCache)
            {
                var stateHash = nodeState.GetHashCode();
                if (this.NodeStateContextCache.ContainsKey(nodePosition))
                {
                    var stateHashSet = this.NodeStateContextCache[nodePosition];
                    if (stateHashSet.ContainsKey(stateHash))
                    {
                        return this.NodeStateContextCache[nodePosition][stateHash];
                    }
                    var constructedNodeContext = base.ConstructNodeContext(nodePosition, nodeState, nodeFactory);
                    this.NodeStateContextCache[nodePosition].Add(stateHash, constructedNodeContext);
                    return constructedNodeContext;
                }
                else
                {
                    var constructedNodeContext = base.ConstructNodeContext(nodePosition, nodeState, nodeFactory);
                    var newDictionary = new Dictionary<int,V>(){{stateHash, constructedNodeContext}};
                    this.NodeStateContextCache.Add(nodePosition, newDictionary);
                    return constructedNodeContext;
                }
            }
        }
    }
}