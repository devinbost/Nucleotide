using System;

namespace Nucleotide_v3.States
{
    [Serializable]
    public class FemaleChosenEdgeNodeState : ChosenEdgeNodeState
    {
        private static volatile FemaleChosenEdgeNodeState instance = null;

        private FemaleChosenEdgeNodeState()
        {

        }

        public static FemaleChosenEdgeNodeState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FemaleChosenEdgeNodeState();
                }
                return instance;
            }
        }
    }
}