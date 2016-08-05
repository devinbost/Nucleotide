using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleotide_v2.Direct;

namespace Nucleotide_v2
{
    /// <summary>
    /// This object is responsible for constructing a WalkPathID from its items. This object is utilized by the Visitor's 
    /// Walk(..) method, by the EdgeStateContext during Flyweight-based object construction and/or state retrieval.
    /// </summary>
    public class WalkPath
    {
        IAdjacencyDirectableVisitable originVertex { get; set; }
        IAdjacencyDirectableVisitable manCurrentVertex { get; set; }
        IAdjacencyDirectableVisitable womanCurrentVertex { get; set; }
        List<IAdjacencyDirectableVisitable> manTrail { get; set; }
        List<IAdjacencyDirectableVisitable> womanTrail { get; set; }

        public WalkPath(IAdjacencyDirectableVisitable originVertex, IAdjacencyDirectableVisitable manCurrentVertex, IAdjacencyDirectableVisitable womanCurrentVertex, List<IAdjacencyDirectableVisitable> manTrail, List<IAdjacencyDirectableVisitable> womanTrail)
        {
            this.originVertex = originVertex;
            this.manCurrentVertex = manCurrentVertex;
            this.womanCurrentVertex = womanCurrentVertex;
            this.manTrail = manTrail;
            this.womanTrail = womanTrail;
        }
    }
}
