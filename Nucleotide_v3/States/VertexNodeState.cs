//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Nucleotide_v3.Model;

namespace Nucleotide_v3.States
{
    [Serializable]
    public abstract class VertexNodeState : NodeState
    {
        
        //public virtual List<int> IncidentChosenEdgePositions(NodeStateContextMediator contextMediator)
        //{
        //    //contextMediator.
        //    throw new System.NotImplementedException();
        //}

        //public virtual List<int> IncidentUnchosenEdgePositions(NodeStateContextMediator contextMediator)
        //{
        //    throw new System.NotImplementedException();
        //}
        [Obsolete("Warning: Use the other overload. This affects a flyweight.")]
        protected internal virtual void Reset(VertexNodeStateContext context)
        {
            context.ChangeState(UnchosenVertexNodeState.Instance);
        }
        protected internal virtual void Reset<V>(V context, VertexNodeStateContextContainer<V> contextContainer) where V : VertexNodeStateContext, new()
        {
            contextContainer.ChangeStateContext(context, UnchosenVertexNodeState.Instance);
            //context.ChangeState(UnchosenVertexNodeState.Instance);
        }
        [Obsolete("Warning: Use the other overload. This affects a flyweight.")]
        protected internal virtual void Choose(VertexNodeStateContext context, NodeGender gender)
        {
            if (gender == NodeGender.Male)
            {
                context.ChangeState(MaleChosenVertexNodeState.Instance);
            }
            if (gender == NodeGender.Female)
            {
                context.ChangeState(FemaleChosenVertexNodeState.Instance);
            }
            // Should this method be empty?
        }
        protected internal virtual void Choose<V>(V context, NodeGender gender, VertexNodeStateContextContainer<V> contextContainer) where V:VertexNodeStateContext, new()
        {
            if (gender == NodeGender.Male)
            {
                contextContainer.ChangeStateContext(context, MaleChosenVertexNodeState.Instance);
                //context.ChangeState(MaleChosenVertexNodeState.Instance);
            }
            if (gender == NodeGender.Female)
            {
                contextContainer.ChangeStateContext(context, FemaleChosenVertexNodeState.Instance);
                //context.ChangeState(FemaleChosenVertexNodeState.Instance);
            }
            // Should this method be empty?
        }
        [Obsolete("Warning: Use the other overload. This affects a flyweight.")]
        protected internal virtual void ChooseAsOrigin(VertexNodeStateContext context)
        {
            context.ChangeState(OriginChosenVertexNodeState.Instance);
        }
        protected internal virtual void ChooseAsOrigin<V>(V context, VertexNodeStateContextContainer<V> contextContainer) where V : VertexNodeStateContext, new()
        {
            contextContainer.ChangeStateContext(context, OriginChosenVertexNodeState.Instance);
            //context.ChangeState(OriginChosenVertexNodeState.Instance);
        }
        protected internal virtual void ChooseAsMale<V>(V context, VertexNodeStateContextContainer<V> contextContainer) where V : VertexNodeStateContext, new()
        {
            contextContainer.Choose(context, NodeGender.Male);
        }
        protected internal virtual void ChooseAsFemale<V>(V context, VertexNodeStateContextContainer<V> contextContainer) where V : VertexNodeStateContext, new()
        {
            contextContainer.Choose(context, NodeGender.Female);
        }
        

       
    }
}

