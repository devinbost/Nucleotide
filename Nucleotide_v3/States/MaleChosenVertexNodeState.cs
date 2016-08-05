using System;

namespace Nucleotide_v3.States
{
    [Serializable]
    public class MaleChosenVertexNodeState : ChosenVertexNodeState
    {
        private static volatile MaleChosenVertexNodeState instance = null;

        //public virtual List<int> IncidentUnchosenVertexPositions
        //{
        //    get;
        //    set;
        //}

        private MaleChosenVertexNodeState()
        {

        }
        public static MaleChosenVertexNodeState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaleChosenVertexNodeState();
                }
                return instance;
            }
        }

    }
}