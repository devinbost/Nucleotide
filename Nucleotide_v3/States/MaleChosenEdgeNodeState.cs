using System;

namespace Nucleotide_v3.States
{
    [Serializable]
    public class MaleChosenEdgeNodeState : ChosenEdgeNodeState
    {
        private static volatile MaleChosenEdgeNodeState instance = null;

        private MaleChosenEdgeNodeState()
        {

        }

        public static MaleChosenEdgeNodeState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MaleChosenEdgeNodeState();
                }
                return instance;
            }
        }
    }
}