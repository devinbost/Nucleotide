using System;

namespace Nucleotide_v3.States
{
    [Serializable]
    public class FemaleChosenVertexNodeState : ChosenVertexNodeState
    {
        private static volatile FemaleChosenVertexNodeState instance = null;

        //public virtual List<int> IncidentUnchosenVertexPositions
        //{
        //    get;
        //    set;
        //}

        private FemaleChosenVertexNodeState()
        {

        }
        public static FemaleChosenVertexNodeState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FemaleChosenVertexNodeState();
                }
                return instance;
            }
        }

    }
}