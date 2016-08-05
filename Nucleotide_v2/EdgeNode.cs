using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nucleotide_v2
{
    /// <summary>
    /// This class must be provided an EdgeStateContext, and it must call a method on the EdgeStateContext (with
    /// a provided WalkPath object) to retrieve edge state.
    /// </summary>
    [Serializable]
    public class EdgeNode : Node<string>, IChoosable
    {
        public EdgeNode(int position)
        {
            this.Chosen = false;
            this.Weight = 0;
            this.Position = position;
        }
        
        public void Choose()
        {
            this.Chosen = true;
        }

        public bool Chosen { get; set; }
    }
    [Serializable]
    public class UndirectedEdgeNode : Node<string>
    {
        public UndirectedEdgeNode(int position) : base(position)
        {
            this.Weight = 0;
        }

        public UndirectedEdgeNode(int id, string value, int position) : base(id, value, position)
        {
        }

        public UndirectedEdgeNode(int position, string value) : base(position, value)
        {
        }

        public UndirectedEdgeNode(int id, int weight, string value, int position) : base(id, weight, value, position)
        {
        }
    }
}
