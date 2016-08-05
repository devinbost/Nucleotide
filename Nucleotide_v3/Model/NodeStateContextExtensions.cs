using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v3.Model
{
    /// <summary>
    /// I needed a generic NodeStateContext extension method for Copy().
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    public static class NodeStateContextExtensions
    {
        //public static VertexNodeStateContext Copy(this VertexNodeStateContext nodeStateContext, VertexNodeStateContextFactory factory)
        //{
        //    var nodeFactory = VertexNodeFactory.GetFactory();
        //    var context = factory.ConstructNodeContext(nodePosition: nodeStateContext.Node.Position,
        //        nodeState: nodeStateContext.State, nodeFactory: nodeFactory);
        //    return context;
        //}
        //public static EdgeNodeStateContext Copy(this EdgeNodeStateContext nodeStateContext, EdgeNodeStateContextFactory factory)
        //{
        //    var nodeFactory = EdgeNodeFactory.GetFactory();
        //    var context = factory.ConstructNodeContext(nodePosition: nodeStateContext.Node.Position,
        //        nodeState: nodeStateContext.State, nodeFactory: nodeFactory);
        //    return context;
        //}

        //public static VertexNodeStateContextContainer Copy(
        //    this VertexNodeStateContextContainer nodeStateContextContainer,
        //    VertexNodeStateContextFactory factory)
        //{
        //    var container = new VertexNodeStateContextContainer();
        //    foreach (var nodeStateContext in nodeStateContextContainer.Values)
        //    {
        //        container.Values.Add(nodeStateContext.Key, nodeStateContext.Value.Copy(factory));
        //    }
        //    return container;
        //}
        //public static EdgeNodeStateContextContainer Copy(
        //    this EdgeNodeStateContextContainer nodeStateContextContainer,
        //    EdgeNodeStateContextFactory factory)
        //{
        //    var container = new EdgeNodeStateContextContainer();
        //    foreach (var nodeStateContext in nodeStateContextContainer.Values)
        //    {
        //        container.Values.Add(nodeStateContext.Key, nodeStateContext.Value.Copy(factory));
        //    }
        //    return container;
        //}
        public static List<V> Copy<V>(
            this List<V> nodeStateContextList,
            VertexNodeStateContextFlyweightFactory<V> factory) where V:VertexNodeStateContext, new()
        {
            var container = new List<V>(nodeStateContextList.Count);
            foreach (var nodeStateContext in nodeStateContextList)
            {
                container.Add(nodeStateContext.Copy(nodeStateContext, factory));
            }
            return container;
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
        //public static NodeStateContextContainerFacade Copy(
        //    this NodeStateContextContainerFacade nodeStateContextContainerFacade,
        //    NodeStateContextContainerFacadeFlyweightFactory factory)
        //{
        //    return factory.Copy(nodeStateContextContainerFacade);
        //}

        ///// <summary>
        ///// Node: This method only clones the containerFacade and its contexts!
        ///// It does not clone the AdjacencyProvider or IncidenceProvider, 
        ///// so those providers use the existing object references!
        ///// </summary>
        ///// <param name="nodeStateContextMediator"></param>
        ///// <param name="facadeFactory"></param>
        ///// <returns></returns>
        //public static NodeStateContextMediator Copy(
        //    this NodeStateContextMediator nodeStateContextMediator,
        //    NodeStateContextContainerFacadeFlyweightFactory facadeFactory)
        //{
        //    var facadeCopy = nodeStateContextMediator.NodeStateContextContainerFacade.Copy(facadeFactory);
        //    var mediatorCopy = new NodeStateContextMediator
        //    {
        //        NodeStateContextContainerFacade = facadeCopy,
        //        AdjacencyProvider = nodeStateContextMediator.AdjacencyProvider,
        //        IncidenceProvider = nodeStateContextMediator.IncidenceProvider
        //    };
        //    return mediatorCopy;
        //}
    }
}
