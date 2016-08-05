using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v3.Model
{
    public class NodeStateContextContainerFacadeFactory<E, V>
        where E : EdgeNodeStateContext, new()
        where V : VertexNodeStateContext, new()
    {
        public EdgeNodeStateContextFactory<E> EdgeNodeStateContextFactory { get; set; }
        public VertexNodeStateContextFactory<V> VertexNodeStateContextFactory { get; set; }

        public NodeStateContextContainerFacadeFactory(EdgeNodeStateContextFactory<E> edgeNodeStateContextFactory, VertexNodeStateContextFactory<V> vertexNodeStateContextFactory)
        {
            if (edgeNodeStateContextFactory == null)
            {
                throw new NullReferenceException("edgeNodeStateContextFactory cannot be null");
            }
            EdgeNodeStateContextFactory = edgeNodeStateContextFactory;
            if (vertexNodeStateContextFactory == null)
            {
                throw new NullReferenceException("vertexNodeStateContextFactory cannot be null");
            }
            VertexNodeStateContextFactory = vertexNodeStateContextFactory;
        }

        public NodeStateContextContainerFacade<E, V> Copy(NodeStateContextContainerFacade<E, V> nodeStateContextContainerFacade)
        {
            var edgeNodeFactory = EdgeNodeFactory.GetFactory();
            var vertexNodeFactory = VertexNodeFactory.GetFactory();
            var edgeContainer =
                nodeStateContextContainerFacade.EdgeNodeStateContextContainer.Copy(this.EdgeNodeStateContextFactory);
            var vertexContainer =
                nodeStateContextContainerFacade.VertexNodeStateContextContainer.Copy(this.VertexNodeStateContextFactory);
            var newFacade = new NodeStateContextContainerFacade<E, V>(edgeContainer, vertexContainer);
            return newFacade;
        }
    }
    public class NodeStateContextContainerFacadeFlyweightFactory<E, V> where E : EdgeNodeStateContext, new()
        where V : VertexNodeStateContext, new()
    {
        public EdgeNodeStateContextFlyweightFactory<E> EdgeNodeStateContextFactory { get; set; }
        public VertexNodeStateContextFlyweightFactory<V> VertexNodeStateContextFactory { get; set; }

        public NodeStateContextContainerFacadeFlyweightFactory(
            EdgeNodeStateContextFlyweightFactory<E> edgeNodeStateContextFactory,
            VertexNodeStateContextFlyweightFactory<V> vertexNodeStateContextFactory)
        {
            if (edgeNodeStateContextFactory == null)
            {
                throw new NullReferenceException("edgeNodeStateContextFactory cannot be null");
            }
            EdgeNodeStateContextFactory = edgeNodeStateContextFactory;
            if (vertexNodeStateContextFactory == null)
            {
                throw new NullReferenceException("vertexNodeStateContextFactory cannot be null");
            }
            VertexNodeStateContextFactory = vertexNodeStateContextFactory;
        }

        public NodeStateContextContainerFacade<E, V> Copy(
            NodeStateContextContainerFacade<E, V> nodeStateContextContainerFacade)
        {
            var edgeNodeFactory = EdgeNodeFactory.GetFactory();
            var vertexNodeFactory = VertexNodeFactory.GetFactory();
            var edgeContainer =
                nodeStateContextContainerFacade.EdgeNodeStateContextContainer.Copy(this.EdgeNodeStateContextFactory);
            var vertexContainer =
                nodeStateContextContainerFacade.VertexNodeStateContextContainer.Copy(this.VertexNodeStateContextFactory);
            var newFacade = new NodeStateContextContainerFacade<E, V>(edgeContainer, vertexContainer);
            return newFacade;
        }
    }
}
