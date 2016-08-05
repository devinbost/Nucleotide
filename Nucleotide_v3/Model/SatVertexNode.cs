namespace Nucleotide_v3.Model
{
    /// <summary>
    /// This vertex node is used for a SAT-based graph representation. If clauses DO NOT match AND if values are not opposites,
    /// then an edge should be created. So, we will need a way to easily compare two SatVertexNode objects to determine if an edge
    /// should be created.  
    /// </summary>
    public class SatVertexNode : VertexNode
    {
        public SatVertexNode(int position, int value, int clause) : base(position)
        {
            Value = value;
            Clause = clause;
        }

        public int Value { get; set; }
        public int Clause { get; set; }
        // Add comparison method.
        public SatVertexNode(int value, int clause)
        {
            Value = value;
            Clause = clause;
        }

        public SatVertexNode() : base()
        {
            
        }
    }
}