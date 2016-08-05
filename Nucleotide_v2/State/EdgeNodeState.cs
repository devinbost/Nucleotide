using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.State;

namespace Nucleotide_v2.State
{
    public class EdgeNodeState<T> : INodeState<T>
    {
        public Node<T> Node { get; set; }
        public bool IsChosen { get; private set; }
        public bool IsCut { get; private set; }
        public bool IsUnchosen { get; private set; }

        public void ChangeState(NodeStateContextContainer<T> contextContainer, INodeState<T> edgeState )
        {
            throw new NotImplementedException();
        }

        public virtual void Cut(NodeStateContextContainer<T> contextContainer)
        {
            
        }
        public virtual void Choose(NodeStateContextContainer<T> contextContainer)
        {

        }

        public void ChangeState(INodeState<T> edgeState)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<INodeState<T>> GetNext()
        {
            throw new NotImplementedException();
        }

      
        protected EdgeNodeState(Node<T> node)
        {
            Node = node;
        }
    }
}
