//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nucleotide_v3.States;

namespace Nucleotide_v3.Model
{
    [DebuggerDisplay("Position={Position}, State={State}")]
    [Serializable]
    abstract public class NodeStateContext
    {
        public virtual NodeState State
        {
            get;
            set;
        }

        public virtual Node Node
        {
            get;
            set;
        }

        //public virtual void Choose(NodeStateContext context, NodeState.NodeGender gender)
        //{
        //    this.State.(this, gender);
        //}

        public void ChangeState(NodeState state)
        {
            this.State = state;
        }

        protected internal NodeStateContext(Node node, NodeState state)
        {
            if (node == null)
            {
                throw new NullReferenceException("Node cannot be null in NodeStateContext(..) constructor.");
            }
            Node = node;
            State = state;
        }
        //public NodeStateContext(NodeState State, Node node)
        //{
        //    State = State;
        //    Node = node;
        //}
        public NodeStateContext()
        {
            
        }
        
        public int Position
        {
            get { return this.Node.Position; }
        }
        
        public C Copy<C,N>(NodeStateContextFactory<C> contextFactory, NodeFactory<N> nodeFactory) 
            where C:NodeStateContext, new()
            where N:Node, new()
        {
            return contextFactory.ConstructNodeContext(this.Position, this.State, nodeFactory);
        }
    }
}
