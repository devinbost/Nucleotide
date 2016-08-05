using System.Collections.Generic;

namespace Nucleotide_v3.Model
{
    public class SatVertexNodeFactory : NodeFactory<SatVertexNode>
    {
        private SatVertexNodeFactory() // defeats instantiation outside of GetFactory() method.
        {
            if (this.Values == null)
            {
                this.Values = new Dictionary<int, SatVertexNode>();
            }
        }

        public static SatVertexNodeFactory GetFactory()
        {
            if (Instance == null)
            {
                Instance = new SatVertexNodeFactory();

            }
            return (SatVertexNodeFactory) Instance;
        }

        public override SatVertexNode ConstructNode(int nodePosition)
        {
            return base.ConstructNode(nodePosition);
        }
        /// <summary>
        /// We need to test this method to determine if it is successfully changing the node properties in the backend storage or not.
        /// </summary>
        /// <param name="nodePosition"></param>
        /// <param name="nodeValue"></param>
        /// <param name="nodeClause"></param>
        /// <returns></returns>
        public SatVertexNode ConstructNode(int nodePosition, int nodeValue, int nodeClause)
        {
            var node = base.ConstructNode(nodePosition);
            node.Clause = nodeClause;
            node.Value = nodeValue;
            return node;
        }
    }
}