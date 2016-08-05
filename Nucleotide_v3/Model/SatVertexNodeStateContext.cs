using System;
using System.Collections.Generic;
using System.Diagnostics;
using Nucleotide_v3.States;

namespace Nucleotide_v3.Model
{
    [DebuggerDisplay("Position={Position}, State={State}, Value={Value}, Clause={Clause}")]
    [Serializable]
    public class SatVertexNodeStateContext : VertexNodeStateContext
    {
        protected internal override List<E> GetIncidentEdgeNodeStateContexts<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetIncidentEdgeNodeStateContexts(nodeStateContextMediator);
        }

        protected internal override List<E> GetIncidentEdgeNodeStateContextsWithMatchingState<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator,
            NodeState state)
        {
            return base.GetIncidentEdgeNodeStateContextsWithMatchingState(nodeStateContextMediator, state);
        }

        protected internal override List<E> GetIncidentEdgeNodeStateContextsWithNotMatchingState<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator,
            NodeState state)
        {
            return base.GetIncidentEdgeNodeStateContextsWithNotMatchingState(nodeStateContextMediator, state);
        }

        protected internal override List<E> GetIncidentEdgeNodeStateContextsWhereStateIsNotCut<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetIncidentEdgeNodeStateContextsWhereStateIsNotCut(nodeStateContextMediator);
        }

        protected internal override bool WouldCutOrphanVertex<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.WouldCutOrphanVertex(nodeStateContextMediator);
        }

        protected internal override IEnumerable<E> GetIncidentUncutEdges<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetIncidentUncutEdges(nodeStateContextMediator);
        }

        protected internal override Dictionary<int, bool> WouldCutToIncidentUnchosenEdgesOrphanTargetVertexDictionary<E, V>(
            NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.WouldCutToIncidentUnchosenEdgesOrphanTargetVertexDictionary(nodeStateContextMediator);
        }

        protected internal override IEnumerable<E> GetUnchosenEdgesThatCauseOrphans<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetUnchosenEdgesThatCauseOrphans(nodeStateContextMediator);
        }

        protected internal override int GetNumberOfIncidentEdgesThatOrphanTargetVertex<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetNumberOfIncidentEdgesThatOrphanTargetVertex(nodeStateContextMediator);
        }

        protected internal override int GetUncutEdgeCount<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetUncutEdgeCount(nodeStateContextMediator);
        }

        protected internal override bool IsUncutEdgeCountAboveTwo<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.IsUncutEdgeCountAboveTwo(nodeStateContextMediator);
        }

        protected internal override int NumberOfEdgesThatCanBeCut<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.NumberOfEdgesThatCanBeCut(nodeStateContextMediator);
        }

        protected internal override IEnumerable<E> GetIncidentUnchosenEdgeNodeStateContexts<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetIncidentUnchosenEdgeNodeStateContexts(nodeStateContextMediator);
        }

        protected internal override void CutRemainingUnchosenEdges2<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            base.CutRemainingUnchosenEdges2(nodeStateContextMediator);
        }

        protected internal override void CutRemainingUnchosenEdges<E, V>(NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            base.CutRemainingUnchosenEdges(nodeStateContextMediator);
        }

        protected internal override List<E> GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone<E, V>(
            NodeStateContextMediator<E, V> nodeStateContextMediator)
        {
            return base.GetEdgesThatCutWouldOrphanIfAnyOrGetDefaultUnchosenEdgesIfNone(nodeStateContextMediator);
        }

        public override Node Node { get; set; }
        public override VertexNodeState State { get; set; }
        public override void Reset()
        {
            base.Reset();
        }

        public override void ChooseAsMale()
        {
            base.ChooseAsMale();
        }

        public override void ChooseAsFemale()
        {
            base.ChooseAsFemale();
        }

        public override void ChooseAsOrigin()
        {
            base.ChooseAsOrigin();
        }
    }
}