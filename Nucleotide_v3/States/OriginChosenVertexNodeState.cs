using System;

namespace Nucleotide_v3.States
{
    [Serializable]
    public class OriginChosenVertexNodeState : ChosenVertexNodeState
    {
        private static volatile OriginChosenVertexNodeState instance = null;

        //public virtual List<int> IncidentUnchosenVertexPositions
        //{
        //    get;
        //    set;
        //}

        private OriginChosenVertexNodeState()
        {

        }
        public static OriginChosenVertexNodeState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OriginChosenVertexNodeState();
                }
                return instance;
            }
        }

    }
}